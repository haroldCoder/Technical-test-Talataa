using Microsoft.EntityFrameworkCore;

namespace Test_technical.Models
{
    public class ContextDB : DbContext // se crea el context para manejar la db
    {
        public DbSet<EmployeesDB> tblEmployee { get; set; } // esta es la tabla principal

        public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        {

        }
    }
}
