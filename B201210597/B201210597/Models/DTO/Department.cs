﻿using B201210597.Models.DTO.Hastane_Randevu.Models;

namespace B201210597.Models.DTO
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public List<Clinic> Clinics { get; set; }
    }
}
