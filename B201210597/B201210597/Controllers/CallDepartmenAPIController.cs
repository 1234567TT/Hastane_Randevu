using B201210597.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace B201210597.Controllers
{
	public class CallDepartmenAPIController : Controller
	{
		[Authorize(Roles = "admin")]

		public async Task<IActionResult> Index()
		{
			var handler = new HttpClientHandler
			{
				ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
			};

			var client = new HttpClient(handler);
			var response = await client.GetAsync("https://localhost:7286/api/ApiDepartment");

			List<Department> Departments = new List<Department>();
			//var response = await client.GetAsync("https://localhost:7286/api/ApiDepartment");
			var jsonResponse = await response.Content.ReadAsStringAsync();
			Departments = JsonConvert.DeserializeObject<List<Department>>(jsonResponse);


			return View(Departments);
		}

        public async Task<IActionResult> Delete()
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            var client = new HttpClient(handler);
            var response = await client.GetAsync("https://localhost:7286/api/ApiDepartment");

            List<Department> Departments = new List<Department>();
            //var response = await client.GetAsync("https://localhost:7286/api/ApiDepartment");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            Departments = JsonConvert.DeserializeObject<List<Department>>(jsonResponse);


            return View(Departments);
        }

    }
}
