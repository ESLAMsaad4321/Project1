using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectMVC.Models;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace ProjectMVC.Controllers
{
    public class HomeController : Controller
    {
        /*
        Uri baseAddress = new Uri("http://localhost:64957/api");
        private readonly HttpClient _Client;
        public HomeController()
        {
            _Client = new HttpClient();
        }    */
    
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        /*
        public async Task<IActionResult> LoginUser(Admin user)
        {
            using(var httpClient=new HttpClient())
            {
                string data = JsonConvert.SerializeObject(user);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _Client.PostAsync(baseAddress + "/Admin", content).Result;
                string Token = response.Content.ReadAsStringAsync().Result;
                HttpContext.Session.SetString("JWT", Token);
                return Redirect("~/View/Account/Index");

            }
        }
        */
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