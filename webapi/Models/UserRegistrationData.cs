using System;
namespace webapi.Models
{
	public class UserRegistrationData
	{
		public string Username { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }

        public UserRegistrationData(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }

        public User CreateUserObject()
        {
            var user = new User(Username, Email);

            return user;
        }

        public UserCredentials CreateUserCredentialsObject(string userId)
        {
            var userCredentials = new UserCredentials(userId, Password);

            return userCredentials;
        }
    }
}

