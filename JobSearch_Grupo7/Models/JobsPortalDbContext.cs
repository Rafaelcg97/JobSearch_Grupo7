using Microsoft.EntityFrameworkCore;

namespace JobSearch_Grupo7.Models
{
    public class JobsPortalDbContext:DbContext
    {
        public JobsPortalDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<InterfaceObject> InterfaceObject { get; set; }
    }
}
