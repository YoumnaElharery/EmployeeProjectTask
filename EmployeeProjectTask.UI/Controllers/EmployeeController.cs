using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using EmployeeProjectTask.Shared.Models;

namespace EmployeeProjectTask.UI.Controllers
{


    public class EmployeeController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public EmployeeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var response = await client.GetAsync("Employee");
            var employees = JsonConvert.DeserializeObject<List<Employee>>(await response.Content.ReadAsStringAsync());
            return View(employees);
        }

        public IActionResult Add() => View();

        [HttpPost]
        public async Task<IActionResult> Add(Employee employee)
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var response = await client.PostAsJsonAsync("Employee", employee);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View(employee);
        }
    }

}
