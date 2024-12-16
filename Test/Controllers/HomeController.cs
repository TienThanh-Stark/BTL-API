using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Text.Json;
using Test.Models;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        private async Task<string> send(string url)
        {
            HttpClient HttpClient = new HttpClient()
            {
                BaseAddress = new Uri(@"http://localhost:5225"),
            };
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            HttpResponseMessage httpResponse = await HttpClient.GetAsync(url);
            if (httpResponse.IsSuccessStatusCode)
            {
                string raw_data = await httpResponse.Content.ReadAsStringAsync();
                return raw_data;
            }
            return "";
        }
        public async Task<IActionResult> Index()
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
