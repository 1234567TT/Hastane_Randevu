using Hastane_Randevu.Data;
using Hastane_Randevu.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hastane_Randevu.Controllers
{
    public class AdminController : Controller
    {
        private readonly HospitalDbContext _dbcontext;
        public AdminController(HospitalDbContext context)
        {
            _dbcontext = context;
        }
        public IActionResult Doktor()
        {
            IEnumerable<Doctor> Opject = _dbcontext.Doctors;
            return View(Opject);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
