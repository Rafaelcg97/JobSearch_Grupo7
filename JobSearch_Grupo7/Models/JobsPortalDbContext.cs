using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using JobSearch_Grupo7.Models;

namespace JobSearch_Grupo7.Models
{
    public class JobsPortalDbContext : DbContext
    {
        public JobsPortalDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Area> Area { get; set; }
        public DbSet<Application> Application { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<CompanyOpinion> companyOpinion { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<InterfaceObject> InterfaceObject { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<JobComment> JobComment {get;set;}
        public DbSet<JobType> JobType { get; set; }
        public DbSet<JobSearch_Grupo7.Models.sources_pages>? sources_pages { get; set; }
    }
}
