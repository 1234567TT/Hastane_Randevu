using Hastane_Randevu.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Hastane_Randevu.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Hastane_Randevu.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult _Admin_()
        {
            return View();
        }
        private readonly HospitalDbContext _dbcontext;
        public AccountController(HospitalDbContext context)
        {
            _dbcontext = context;


        }


        public IActionResult A()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new Register());
        }
        public IActionResult Viewss()
        {


            return View();
        }




        [HttpPost]
        public IActionResult Register(Register user)
        {
            var existingUser = _dbcontext.Registers.FirstOrDefault(x => x.Email == user.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError(nameof(user.Email), "Bu e-posta adresi zaten kullanımda.");
                return View(user);
            }

            if (ModelState.IsValid)
            {
                _dbcontext.Registers.Add(user);
                _dbcontext.SaveChanges();
                return RedirectToAction("Login", "Account");
            }

            return View(user);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                if(model.Email== "B201210597@sakarya.edu.tr"&&model.Password=="sau")
                {
                    return RedirectToAction("Doktor", "Admin");

                }
                var users = _dbcontext.Registers.FirstOrDefault(x => x.Email == model.Email);
                if (users != null && users.Password == model.Password)
                {
                   return RedirectToAction("A", "Account");
                }
                else
                {

                    ModelState.AddModelError("", "Yanlis");
                }
            }
            
            return View();
        }
    }
}
