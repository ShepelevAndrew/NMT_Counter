using Microsoft.AspNetCore.Mvc;
using NMT_Counter.BLL.BusinessModels;
using NMT_Counter.BLL.Services.Interfaces;
using NMT_Counter.Models;
using System.Diagnostics;

namespace NMT_Counter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICounterService _counterService;

        public HomeController(ILogger<HomeController> logger, ICounterService counterService)
        {
            _logger = logger;
            _counterService = counterService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromBody] CounterViewModel model)
        {
            double nmtMark = _counterService.Count(model.Marks, model.Coefficient);

            return Json(nmtMark);
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