using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LittleHands.Models
{
    public class Children
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public BloodType BloodType { get; set; }
        public int ParentId { get; set; }
        public required virtual User Parent { get; set; } 
    }
}
