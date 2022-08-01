using Microsoft.AspNetCore.Mvc;
using Antra.CustomerCRM.WebAppMVC.Models;

namespace Antra.CustomerCRM.WebAppMVC.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            List<Employee> lstEmployees = new List<Employee> { 
             new Employee() {Id=1, FirstName="Jane", LastName="Doe", Department="IT", Salary=6000},
             new Employee() {Id=2, FirstName="William", LastName="Bi", Department="HR", Salary=5000},
             new Employee() {Id=3, FirstName="Olivia", LastName="Saw", Department="QA", Salary=5500},
             new Employee() {Id=4, FirstName="James", LastName="Anderson", Department="Sales", Salary=4500},
             new Employee() {Id=5, FirstName="Brett", LastName="Lee", Department="IT", Salary=6000},
            };
            return View(lstEmployees);
        }
    }
}
