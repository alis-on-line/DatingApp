using System.Threading.Tasks;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;
using DatingApp.API.Services;

namespace DatingApp.API.Data {
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

            if (!AuthServiceHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt)) {
                return null;
            }

            return user;
        }

        public async Task<User> Register(User user, string password) {
            AuthServiceHelper.CreatePasswordHash(password, out var passwordHash, out var passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> UserExists(string username) {
            if (await context.Users.AnyAsync(x => x.Username == username)) {
                return true;
            }
            return false;
        }
    }
}