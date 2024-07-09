using aspQuote.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace aspQuote.Models
{
    public class Model1 : IdentityDbContext<ApplicationUser>
    {
        public Model1()
            : base("name=Model1", throwIfV1Schema: false)
        {
        }

        public static Model1 Create()
        {
            return new Model1();
        }

        public DbSet<Insuree> Insurees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
