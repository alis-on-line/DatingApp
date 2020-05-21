using System.Collections.Generic;
using System.Linq;
using DatingApp.API.Models;
using DatingApp.API.Services;
using Newtonsoft.Json;

namespace DatingApp.API.Data {
    public static class Seed {

        public static void SeedUsers(DataContext context) {
            if (!context.Users.Any()) {
                var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");
                var users = JsonConvert.DeserializeObject<List<User>>(userData);
                foreach (var user in users) {
                    AuthServiceHelper.CreatePasswordHash("password", out var passwordHash, out var passwordSalt);

                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;
                    user.Username = user.Username.ToLower();
                    context.Users.Add(user);
                }

                context.SaveChanges();
            }
        }
    }
}