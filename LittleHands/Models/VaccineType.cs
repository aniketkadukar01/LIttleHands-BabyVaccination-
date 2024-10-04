namespace LittleHands.Models
{
    public class VaccineType
    {
        public int Id { get; set; }
        public required string VaccineName { get; set; }
        public required string VaccineDescription { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }

    }
}
