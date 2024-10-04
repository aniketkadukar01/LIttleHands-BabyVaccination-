using LittleHands.Validators;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LittleHands.Models
{
    public class User
    {       
        public int Id { get; set; }       
        public required string FirstName { get; set; }       
        public required string LastName { get; set; }       
        public required string ContactNumber { get; set; }     
        public required string Email { get; set; }
        public required string Password { get; set; }
        public Role Role { get; set; }     
    }
}
