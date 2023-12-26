using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace B201210597.Controllers
{
    public class AdminController : Controller
    {

        [Authorize(Roles = "admin")]
        public IActionResult Display()
        {
            return View();
        }
    }
}
