namespace B201210597.Models.DTO
{
    public class SonRandevu
    {
       public int id { get; set; }
        public string Department { get; set; }
        public string Clinic { get; set; }
        public string Doctor { get; set; }
        public string IsGunler { get; set; }
        public string IsSaat { get; set; }
        public List<Department> Departments { get; internal set; }
        public List<Clinic> Clinics { get; internal set; }
        public List<Doctor> Doctors { get; internal set; }
    }
}
