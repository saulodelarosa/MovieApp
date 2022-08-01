using Antra.CustomerCRM.WebAppMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Antra.CustomerCRM.WebAppMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            Employee employee = new Employee();
            employee.FirstName = "Daniel";
            employee.LastName = "Craig";
            employee.Salary = 6700;
            employee.Department = "IT";
            employee.Id = 7;

            return View(employee);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}