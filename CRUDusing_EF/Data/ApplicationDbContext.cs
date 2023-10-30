using CRUDusing_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDusing_EF.Data
{
    //added child class to get feature of Dbcontext class
    public class ApplicationDbContext:DbContext
    {
        //Dbcontextoption is used to override configuration --connection
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> op) : base(op) 
        {

        }

        public DbSet<Book> Books { get; set; }
       public DbSet<Student> Students { get; set; }
       public DbSet<EmployeeEF> EmpEF { get; set; }
    }


}
