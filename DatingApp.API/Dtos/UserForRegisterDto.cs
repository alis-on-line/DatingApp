using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dtos {
    public class UserForRegisterDto {
        public UserForRegisterDto(string username, string password) {
            Username = username;
            Password = password;
        }
        
        [Required]
        public string Username { get; }

        [Required]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "You must specify password between 4 and 10 characters.")]
        public string Password { get; }
    }
}