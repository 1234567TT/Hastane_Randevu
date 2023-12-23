using System.Numerics;

namespace Hastane_Randevu.Models
{
    public class Clinic
    {
        public int ClinicId { get; set; }
        public string ClinicName { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public List<Doctor> Doctors { get; set; }
    }

}