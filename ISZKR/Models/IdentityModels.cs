using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ISZKR.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser 
    {
        public int UsersChronicleID { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Element authenticationType musi pasować do elementu zdefiniowanego w elemencie CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Dodaj tutaj niestandardowe oświadczenia użytkownika
            return userIdentity;
        }
    }

    public class ISZKRDbContext : IdentityDbContext
    {
        public ISZKRDbContext()
            : base("DefaultConnection")
        {
        }
        
        public static ISZKRDbContext Create()
        {
            return new ISZKRDbContext();
        }
        public DbSet<Person> Person { get; set; }
        public DbSet<Chronicle> Chronicle { get; set; }
        public DbSet<EducationHistory> EducationHistory { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Photo> Photo { get; set; }
        public DbSet<ProfessionHistory> ProfessionHistory { get; set; }
        public DbSet<ResidenceHistory> ResidenceHistory { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}