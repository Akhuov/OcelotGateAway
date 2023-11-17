using Microsoft.EntityFrameworkCore;
using WepApi_2.Domain.Entities;

namespace WepApi_2.DataAccess.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Person> People { get; set; }
    }
}
