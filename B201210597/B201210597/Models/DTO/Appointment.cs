using System.Numerics;

namespace B201210597.Models.DTO
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDateTime { get; set; }

        public int UsersId { get; set; }
        public Users Users { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
