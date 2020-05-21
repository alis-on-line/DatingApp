using System.Security.Cryptography;
using System.Text;

namespace DatingApp.API.Services {
    public static class AuthServiceHelper {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt) {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt) {
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
    }
}