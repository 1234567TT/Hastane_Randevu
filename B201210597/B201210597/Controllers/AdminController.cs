using B201210597.Models.Domain;
using B201210597.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace B201210597.Controllers
{
    [Authorize(Roles = "admin")]

    public class AdminController : Controller
    {

        private readonly DatabaseContext _db;

        public AdminController(DatabaseContext db)
        {
            _db = db;
        }
        public IActionResult cikis()
        {
            return RedirectToAction("Logout", "UserAuthentication");
        }
        public IActionResult Display()
        {
            return View();
        }




        public IActionResult Doktor()
        {
			
			IEnumerable<Doctor> Opject = _db.Doctors;
            return View(Opject);

            
        }
        public IActionResult CreateDoctor()
        {
			Doctor doctor = new Doctor(); 
            doctor.Clinics=_db.Clinics.ToList();
			return View(doctor);

		}

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateDoctor(Doctor obj)
        {

                _db.Doctors.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Doktor created successfully";
                return RedirectToAction("Doktor");
            
          
        }


        public IActionResult EditDoktor(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Doctors.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditDoktor(Doctor obj)
        {

           
                _db.Doctors.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Doktor updated successfully";
                return RedirectToAction("Doktor");
           
        }

        public IActionResult DeleteDoktor(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Doctors.Find(id);
            
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //POST
        [HttpPost, ActionName("DeleteDoktor")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOSTDoktor(int? id)
        {
            var obj = _db.Doctors.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Doctors.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Doktor deleted successfully";
            return RedirectToAction("Doktor");

        }



    }
}
