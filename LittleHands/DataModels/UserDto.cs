using LittleHands.Models;

namespace LittleHands.DataModels
{
    public class UserDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string ContactNumber { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public Role Role { get; set; }
    }
}
