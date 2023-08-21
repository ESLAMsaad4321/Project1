using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectMVC.Models;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

namespace ProjectMVC.Controllers
{

    public class AccountController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:64957/api");
        private readonly HttpClient _Client;
        public AccountController()
        {
            _Client = new HttpClient();
            _Client.BaseAddress = baseAddress;
            
        }
        private void AddTokenHeader()
        {
            string? authToken = HttpContext.Session.GetString("JWT");
            _Client.DefaultRequestHeaders.Clear();
            _Client.DefaultRequestHeaders.Add("Authorization", "Bearer "+ authToken);
        }
        [HttpGet]
        
        public IActionResult Index()
        {
            AddTokenHeader();
            _Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            List<AccountViewModel> Account = new List<AccountViewModel>();
            HttpResponseMessage response = _Client.GetAsync(baseAddress + "/Account/GetAccounts").Result;
            if (response.IsSuccessStatusCode)
            {

                string data = response.Content.ReadAsStringAsync().Result;
                Account = JsonConvert.DeserializeObject<List<AccountViewModel>>(data);
            }
            return View(Account);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AccountViewModel model)
        {
            try
            {
                AddTokenHeader();

                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _Client.PostAsync(baseAddress + "/Account/AddAccount", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["sucess massege"] = "Account Added";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["error massege"] =ex.Message;
                return View();
                
            }
            return View();
        }
       
        public IActionResult Search(int id)
        {
            try
            {
                
                AccountViewModel Account = new AccountViewModel();
                HttpResponseMessage response = _Client.GetAsync(baseAddress + "/Account/GetAccountsById/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    Account = JsonConvert.DeserializeObject<AccountViewModel>(data);
                }
                return View(Account);

            }
            catch (Exception ex)
            {
                TempData["errormMssege"] = ex.Message;
                return View();
            }

        }
        [HttpGet]
        public IActionResult Edit(int id) 
        {
            try
            {
                
                AccountViewModel account = new AccountViewModel();
                HttpResponseMessage response = _Client.GetAsync(baseAddress + "/Account/GetAccountsById/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    account = JsonConvert.DeserializeObject<AccountViewModel>(data);
                }
                return View(account);

            }
            catch (Exception ex)
            {
                TempData["errormMssege"] = ex.Message;
                return View();
            }
            
        }

        [HttpPost]
        public IActionResult Edit(AccountViewModel model, int id)
        {
            try
            {
               
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _Client.PutAsync(baseAddress + "/Account/UpdateAccount/" + id, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["sucess massege"] = "Account Update";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errormMssege"] = ex.Message;
                return View();
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                AccountViewModel account = new AccountViewModel();
                HttpResponseMessage response = _Client.GetAsync(baseAddress + "/Account/GetAccountsById/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    account = JsonConvert.DeserializeObject<AccountViewModel>(data);
                }
                return View(account);

            }
            catch (Exception ex)
            {
                TempData["errormMssege"] = ex.Message;
                return View();
            }
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                
                HttpResponseMessage response = _Client.DeleteAsync(baseAddress + "/Account/DeleteAccount/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["sucess massege"] = "Account Deleted";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errormMssege"] = ex.Message;
                return View();
            }
            return View();
        }
    }
}
