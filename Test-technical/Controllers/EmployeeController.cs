using Microsoft.AspNetCore.Mvc;
using Test_technical.Models;

namespace Test_technical.Controllers
{
    [Route("api")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly ContextDB _contextdb;
        public IActionResult Index()
        {
            return View();
        }
        public EmployeeController(ContextDB context)
        {
            _contextdb = context;
        }

        [HttpGet("employee")]
        public string ViewEmployee()
        {
            var employee = _contextdb.tblEmployee.ToList();

            Console.WriteLine(employee);

            return "Hello World";
        }
    }
}
