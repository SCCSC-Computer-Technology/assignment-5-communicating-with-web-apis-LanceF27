using ConsumeWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsumeWebAPI.Controllers
{
    public class StudentController : Controller
    {
        //Uri baseAddress = new Uri("https://localhost:44361/api");
        Uri baseAddress = new Uri("https://localhost:7120/api");

        private readonly HttpClient _client;

        public StudentController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]

        public IActionResult Index()
        {
            List<StudentModel> studentList = new List<StudentModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Student/Get").Result;

            if(response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                studentList = JsonConvert.DeserializeObject<List<StudentModel>>(data);
            }

            return View(studentList);
        }
    }
}
