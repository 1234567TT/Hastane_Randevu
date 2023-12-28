using B201210597.Models.Domain;
using B201210597.Models.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace B201210597.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class APIRandevuAPIController : ControllerBase
	{
		private readonly DatabaseContext _db;

		public APIRandevuAPIController(DatabaseContext db)
		{
			_db = db;
		}

		// GET: api/<APIRandevuAPIController>
		[HttpGet]
		public List<Appointment> Get()
		{
			return _db.Appointments.ToList();
		}
		// GET api/<APIRandevuAPIController>/5
		[HttpGet("{id}")]
		public Appointment Get(int id)
		{

			var y = _db.Appointments.FirstOrDefault(x => x.AppointmentId== id);

			return y;
		}

		// POST api/<APIRandevuAPIController>
		[HttpPost]
		public void Post([FromBody] Appointment y)
		{
			_db.Appointments.Add(y);
			_db.SaveChanges();


		}

		// PUT api/<APIRandevuAPIController>/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] Appointment y)
		{
			var y1 = _db.Appointments.FirstOrDefault(x => x.AppointmentId == id);
			if (y1 != null)
			{
				return NotFound();
			}
			else
			{

				y1.AppointmentDateTime = y.AppointmentDateTime;
				y1.Kullanici = y.Kullanici;
				y1.KullaniciId = y.KullaniciId;
				y1.DoctorId = y.DoctorId;
				y1.Doctor = y.Doctor;

				_db.Update(y1);
				_db.SaveChanges();
				return Ok();
			}
		}

		// DELETE api/<APIRandevuAPIController>/5
		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			var y1 = _db.Appointments.FirstOrDefault(s => s.AppointmentId== id);
			if (y1 != null)
			{
				return NotFound();
			}
			else
			{

				_db.Remove(y1);
				_db.SaveChanges();
				return Ok();
			}
		}
	}
}
