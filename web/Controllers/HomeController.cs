using Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Abstraction;
using Service.Services.Concretes;
using System.Diagnostics;
using web.Models;

namespace web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPriceService priceService;
        private readonly IApiService apiService;

        public HomeController(ILogger<HomeController> logger, IPriceService priceService, IApiService apiService)
        {
            _logger = logger;
            this.priceService = priceService;
            this.apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            await apiService.GetData();
            var prices = await priceService.GetAllPrice();

            return View(prices);
   
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