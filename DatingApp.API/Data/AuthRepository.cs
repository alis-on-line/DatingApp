using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DatingApp.API.Data
{
    public class AuthRepository : IAuthRepository {
        private readonly DataContext context;

        public AuthRepository(DataContext context) {
            this.context = context;
        }
        public async Task<User> Login(string username, string password) {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Username == username);

            if (user == null) {
                return null;
            }

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt)) {
                return null;
            }

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt) {
            using (var hmac = new HMACSHA512(passwordSalt)) {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (var i = 0; i < computedHash.Length; i++) {
                    if (computedHash[1] != passwordHash[1]) {
                        return false;
                    }
                }
            }
            return true;
        }

        public async Task<User> Register(User user, string password) {
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt) {
            using (var hmac = new HMACSHA512()){
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username) {
            if (await context.Users.AnyAsync(x => x.Username == username)) {
                return true;
            }
            return false;
        }
    }
}