using Microsoft.EntityFrameworkCore;
using TargetProject.Models;

namespace TargetProject.Data
{
    public class TargetContext : DbContext
    {
        public TargetContext(DbContextOptions<TargetContext> options) : base(options)
        {
        }
        public DbSet<Person> People { get; set; }
    }
}
