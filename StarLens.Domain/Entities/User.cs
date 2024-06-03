using System.Text.Json.Serialization;

namespace StarLens.Domain.Entities
{
    public class User : Entity
    {
        public User(string userName, string password, string email)
        {
            UserName = userName;
            Password = password;
            Email = email;
        }
        [JsonConstructor]
        public User(string userName, string password, string email, int status, int id)
        {
            UserName = userName;
            Password = password;
            Email = email;
            Status = status;
            Id = id;
        }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Status { get; set; } = 0;
    }
}
