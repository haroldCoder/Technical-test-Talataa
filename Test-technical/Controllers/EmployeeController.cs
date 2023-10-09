using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Test_technical.Models;
using Microsoft.AspNetCore.Cors;

namespace Test_technical.Controllers
{
    [Route("api")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")] // se le dice que el endpoint es api que el un ApiController, y que permita las cors.
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
            this._noSslVerificationClient = httpClientFactory.CreateClient("NoSSLVerification"); // configuracion para que ignore la verificacion ssl
        }

        [HttpGet("employee")]
        public List<EmployeesDB> ViewEmployee([FromQuery] string bysearch = "")
        {
            if (string.IsNullOrWhiteSpace(bysearch))
            {
                return _contextdb.tblEmployee.ToList(); //en caso de que no se le pasen query, se retornan todos los empleados
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
            }; // crear un objeto que instancia de EmployeesDB para que la informacion quede guardada en el objeto

            _contextdb.tblEmployee.Add(employee); // se guarda esos datos en la db
            _contextdb.SaveChanges(); // se guardan los cambios

            return Ok("Empleado añadido"); // si todo sale bien se envia un mensaje de exito
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
