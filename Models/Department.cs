namespace Hastane_Randevu.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public List<Clinic> Clinics { get; set; }
    }

}
