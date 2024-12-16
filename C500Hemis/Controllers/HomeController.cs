using C500Hemis.API;
using C500Hemis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;

namespace C500Hemis.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApiServices _apiServices;
        private readonly HemisContext _hemisContext;

        public HomeController(ILogger<HomeController> logger, ApiServices apiServices, HemisContext hemisContext)
        {
            _logger = logger;
            _apiServices = apiServices;
            _hemisContext = hemisContext;
        }

        public async Task<IActionResult> Index()
        {
            //List<TbNguoi> nguois = await _apiServices.GetAll<TbNguoi>("/api/Nguoi");
            //return Content(JsonConvert.SerializeObject(nguois));
            return View();
        }

        public IActionResult CB()
        {
            return View();
        }

        public IActionResult HTQT()
        {
            return View();
        }

        public IActionResult CSGD ()
        {
            return View();
        }

        public IActionResult CSVC()
        {
            return View();
        }

        public IActionResult CTDT()
        {
            return View();
        }

        public IActionResult KHCN()
        {
            return View();
        }

        public IActionResult NDT()
        {
            return View();
        }

        public IActionResult NH()
        {
            return View();
        }

        public IActionResult TCTS()
        {
            return View();
        }

        public IActionResult TS()
        {
            return View();
        }

        public IActionResult VB()
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
