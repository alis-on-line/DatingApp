namespace DatingApp.API.Dtos {
    public class UserForLoginDto {
        public UserForLoginDto(string username, string password) {
            Username = username;
            Password = password;
        }
        
        public string Username { get; }

        public string Password { get; }
    }
}