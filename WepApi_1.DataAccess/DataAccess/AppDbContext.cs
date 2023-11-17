using Microsoft.EntityFrameworkCore;
using WepApi_1.Domain.Entities;

namespace WepApi_1.DataAccess.DataAccess
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
