using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Test_technical.Models;

namespace Test_technical.Controllers
{
    [Route("api")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly ContextDB _contextdb;
        private readonly HttpClient _noSslVerificationClient;
        public IActionResult Index()
        {
            return View();
        }
        public EmployeeController(ContextDB context, IHttpClientFactory httpClientFactory)
        {
            _contextdb = context;
            this._noSslVerificationClient = httpClientFactory.CreateClient("NoSSLVerification");
        }

        [HttpGet("employee")]
        public List<EmployeesDB> ViewEmployee([FromQuery] string bysearch = "")
        {
            if (string.IsNullOrWhiteSpace(bysearch))
            {
                return _contextdb.tblEmployee.ToList();
            }

            // Filtra los registros por nombre o apellido que coincidan con bysearch
            var filteredEmployees = _contextdb.tblEmployee
                .Where(e => e.Nombre.Contains(bysearch) || e.Apellidos.Contains(bysearch))
                .ToList();

            return filteredEmployees;
        }

        [HttpPost("employee")]
        public IActionResult InsertEmployee([FromBody] EmployeesDB employeesdb)
        {
            // Validar el correo electrónico utilizando una expresión regular
            if (!isValidEmail(employeesdb.Email))
            {
                return BadRequest("El formato del correo electrónico no es válido.");
            }

            var employee = new EmployeesDB
            {
                Documento = employeesdb.Documento,
                Nombre = employeesdb.Nombre,
                Apellidos = employeesdb.Apellidos,
                Teléfono = employeesdb.Teléfono,
                Dirección = employeesdb.Dirección,
                Email = employeesdb.Email,
                Género = employeesdb.Género
            };

            _contextdb.tblEmployee.Add(employee);
            _contextdb.SaveChanges();

            return Ok("Empleado añadido");
        }

        public bool isValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            // Utiliza una expresión regular para validar el formato del correo electrónico
            var emailRegex = new Regex(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$");
            return emailRegex.IsMatch(email);
        }
    }
}
