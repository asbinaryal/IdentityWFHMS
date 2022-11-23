using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WFHMS.Data.Entities;

namespace WFHMS.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<ApplyForWFH> ApplyForWFHs { get; set; }
        //public DbSet<Worklog> Worklogs { get; set; }
        //public DbSet<Request> Requests { get; set; }
        //public DbSet<Configuration> Configurations { get; set; }
        //public DbSet<Notification> Notifications { get; set; }
        //public DbSet<UserNotification> UserNotifications { get; set; }



        /// <summary>
        /// Overriding OnModelCreating to modify the mapping of these types.
        /// </summary>
        /// <param name="modelbuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelbuilder) 
        {
            base.OnModelCreating(modelbuilder);
        }
    }
}