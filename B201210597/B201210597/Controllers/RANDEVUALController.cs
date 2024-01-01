using B201210597.Models.Domain;
using B201210597.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace B201210597.Controllers
{
    [Authorize]

    public class RandevuAlController : Controller
    {

        private readonly DatabaseContext _db;

        public RandevuAlController(DatabaseContext db)
        {
            _db = db;
        }
        public IActionResult cikis()
        {
            return RedirectToAction("Logout", "UserAuthentication");
        }

        public IActionResult Index()
        {
            Appointment viewModel = new Appointment
            {
                Departments = _db.Departments.ToList(),
                Clinics = _db.Clinics.ToList(),
                Doctors = _db.Doctors.ToList()
                
            };

            return View(viewModel);
        }
       
    }
}
