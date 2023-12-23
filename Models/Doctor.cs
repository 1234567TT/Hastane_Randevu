namespace Hastane_Randevu.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string WorkingDays { get; set; }
        public string WorkingHours { get; set; }

        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }

        public List<Appointment> Appointments { get; set; }
    }

}