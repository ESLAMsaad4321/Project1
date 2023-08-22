using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Common;
using ProjectMVC.Models;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace ProjectMVC.Controllers
{
    public class HomeController : Controller
    {

       
        Uri baseAddress = new Uri("https://localhost:44349/api");
        private readonly HttpClient _Client;

        public HomeController()
        {
            _Client = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true });

            _Client.BaseAddress = baseAddress;
        }
    [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
            [HttpPost]
        public IActionResult Index(AdminLoginViewModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _Client.PostAsync(baseAddress + "/Admin/LogIn/login", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = response.Content.ReadAsStringAsync().Result;

                    // Deserialize the response content to extract the token
                    var tokenResponse = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseContent);

                    if (tokenResponse.TryGetValue("token", out string token))
                    {
                        HttpContext.Session.SetString("JWT", token);
                        return Redirect("~/Account/Index");
                    }
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                TempData["error massege"] = ex.Message;
                return View();

            }
            return View();
        }
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return Redirect("~/Home/Index");
        }
        public IActionResult done()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AdminRegisterViewModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _Client.PostAsync(baseAddress + "/Admin/Regestier/register", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["sucess massege"] = "Admin Added";
                    return RedirectToAction("done");
                }
               
            }
            catch (Exception ex)
            {
                TempData["error massege"] = ex.Message;
                return View();

            }
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