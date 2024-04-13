using aspWebAPPMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace aspWebAPPMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory clientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            clientFactory = httpClientFactory;
        }
        /*
        public async Task<IActionResult> Students(int id)
        {
            string uri;
            if (id > 0)
            {
                ViewData["Title"] = $"Student";
                uri = $"api/StudentProfiles/?Id={id}";
            }
            else
            {
                ViewData["Title"] = "All Students";
                uri = "api/StudentProfiles/";
            }

            HttpClient client = clientFactory.CreateClient(name: "StudentProfileWebApi");

            HttpRequestMessage request = new(method: HttpMethod.Get, requestUri: uri);
            HttpResponseMessage response = await client.SendAsync(request);

            IEnumerable<StudentProfile>? model = await response.Content.ReadFromJsonAsync<IEnumerable<StudentProfile>>();
            return View(model);
    }*/
        public async Task<IActionResult> StudentsAll(int id)
        {
            string uri;

            ViewData["Title"] = "All Students";
            uri = "api/StudentProfiles/";

            HttpClient client = clientFactory.CreateClient(name: "StudentProfileWebApi");

            HttpRequestMessage request = new(method: HttpMethod.Get, requestUri: uri);
            HttpResponseMessage response = await client.SendAsync(request);

            IEnumerable<StudentProfile>? model = await response.Content.ReadFromJsonAsync<IEnumerable<StudentProfile>>();
            return View(model);
        }

        public async Task<IActionResult> StudentsByID(int id)
        {
            string uri;

            ViewData["Title"] = $"Students By ID";
            uri = $"api/StudentProfiles/?ID={id}";

            HttpClient client = clientFactory.CreateClient(name: "StudentProfileWebApi");

            HttpRequestMessage request = new(method: HttpMethod.Get, requestUri: uri);
            HttpResponseMessage response = await client.SendAsync(request);

            IEnumerable<StudentProfile>? model = await response.Content.ReadFromJsonAsync<IEnumerable<StudentProfile>>();
            return View(model);
        }

        public async Task<IActionResult> StudentsByName(string name)
        {
            string uri;

            ViewData["Title"] = $"Students By Name";
            uri = $"api/StudentProfiles/?Name={name}";

            HttpClient client = clientFactory.CreateClient(name: "StudentProfileWebApi");

            HttpRequestMessage request = new(method: HttpMethod.Get, requestUri: uri);
            HttpResponseMessage response = await client.SendAsync(request);

            IEnumerable<StudentProfile>? model = await response.Content.ReadFromJsonAsync<IEnumerable<StudentProfile>>();
            return View(model);
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
