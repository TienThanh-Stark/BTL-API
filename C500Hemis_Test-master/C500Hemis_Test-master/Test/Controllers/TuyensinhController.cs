using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NuGet.Protocol;
using SQLitePCL;
using Test.Models;

namespace Test.Controllers
{
    [Route("[controller]/{action=Index}")]
    public class TuyensinhController : Controller
    {
        private readonly ILogger<TuyensinhController> _logger;

        public TuyensinhController(ILogger<TuyensinhController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            string raw_data = await send("/api/CaNhan/Noituyensinh");
            List<string> noits = JsonConvert.DeserializeObject<List<string>>(raw_data);
            ViewData["noits"] = new SelectList(noits);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index([Bind("cccd,name,gioitinh,namsinh,noituyensinh")] Tuyensinh tuyensinh) {
            return View("Details", tuyensinh);
        }
        public async Task<IActionResult> Thongtin(int id) {
            string raw_data = await send($"/api/CaNhan/Thongtin?id={id}");
            if (raw_data == "") return NotFound();
            return Content(raw_data);
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