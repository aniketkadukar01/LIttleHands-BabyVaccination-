namespace LittleHands.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int ChildrenID { get; set; }
        public required Children Children { get; set; }
        public int DoctorId { get; set; }
        public required User Doctor { get; set; }
        public DateOnly AppointmentDate { get; set; }
        public TimeOnly AppointmentTime { get; set; }
        public Status Status { get; set; }
        public int VaccineId { get; set; }
        public required VaccineType VaccineType { get; set; }
    }
}
