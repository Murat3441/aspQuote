namespace aspQuote.Migrations
{
    using aspQuote.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    internal sealed class Configuration : DbMigrationsConfiguration<aspQuote.Models.Model1>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(aspQuote.Models.Model1 context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole("Admin");
                roleManager.Create(role);
            }

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser
            {
                UserName = "admin",
                Email = "admin@admin.com"
            };

            string userPassword = "admin123";
            var checkUser = userManager.Create(user, userPassword);

            if (checkUser.Succeeded)
            {
                userManager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
