using Microsoft.EntityFrameworkCore;

namespace Test_technical.Models
{
    public class ContextDB : DbContext
    {
        public DbSet<EmployeesDB> tblEmployee { get; set; }

        public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        {

        }
    }
}
