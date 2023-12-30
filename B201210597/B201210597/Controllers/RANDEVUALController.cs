using B201210597.Models.Domain;
using B201210597.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace B201210597.Controllers
{
    [Authorize]
    public class RANDEVUALController : Controller
    {


        private readonly DatabaseContext _db;
		private object departmentId;

		public RANDEVUALController(DatabaseContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
			var tablesWithForeignKey = _db.Model.GetEntityTypes()
			   .Where(e => e.GetForeignKeys().Any(fk => fk.PrincipalKey.Properties.Any(p => p.Name == "DepartmentId")))
			   .Select(e => e.GetTableName())
			   .ToList();

			var tablesWithGivenForeignKey = new List<string>();

			foreach (var tableName in tablesWithForeignKey)
			{
				// Tablonun belirli bir DepartmentId'yi içerip içermediğini kontrol et
				var containsDepartmentId = _db.Set<object>().FromSqlRaw($"SELECT * FROM {tableName} WHERE DepartmentId = {departmentId}").Any();
				if (containsDepartmentId)
				{
					tablesWithGivenForeignKey.Add(tableName);
				}
			}

			return View(tablesWithGivenForeignKey);
		}

		//var Depart = _db.Departments.ToList();
		//         var Klinik = _db.Clinics.ToList();
		//         var doctors = _db.Doctors.ToList();

		//             var viewModel = new Appointment
		//             {

		//		Departments = Depart,
		//                 Clinics = Klinik,
		//                 Doctors = doctors,
		//             };

		//             return View(viewModel);

	}
    }

