﻿using System.Numerics;

namespace B201210597.Models.DTO
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDateTime { get; set; }

        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public List<Doctor> Doctors { get; internal set; }
        public List<Kullanici> KullaniciLer { get; internal set; }
        public List<Clinic> Clinics { get; internal set; }
        public List<Department> Departments { get; internal set; }
    }
}
