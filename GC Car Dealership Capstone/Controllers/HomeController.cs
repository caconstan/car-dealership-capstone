using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GC_Car_Dealership_Capstone.Models;
using GC_Car_Dealership_Capstone.Data;

namespace GC_Car_Dealership_Capstone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly InventoryDAL _dal;
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
            _dal = new InventoryDAL();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Cars> cars = await _dal.GetCars();
            return View(cars);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string make, string model, int year, string color)
        {
            List<Cars> cars = await _dal.GetCars(make, model, year, color);
            return View( cars );
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
