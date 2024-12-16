using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Test.Models;

namespace Test.Controllers
{
    [Route("[controller]/{action=Index}")]
    public class NguoiController : Controller
    {
        private readonly ILogger<NguoiController> _logger;

        public NguoiController(ILogger<NguoiController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            string human_raw = await send("/api/Human/nguoi");
            List<human>? human_list = JsonConvert.DeserializeObject<List<human>>(human_raw);
            if (human_list == null || human_list.Count == 0) return NotFound();
            return View(human_list);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
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
    }
}