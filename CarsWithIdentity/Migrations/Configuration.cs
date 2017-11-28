namespace CarsWithIdentity.Migrations
{
    using CarsWithIdentity.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarsWithIdentity.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarsWithIdentity.Models.ApplicationDbContext context)
        {
            // Load the user and role managers with our custom models
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleMgr = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(context));

            // have we loaded roles already?
            if (roleMgr.RoleExists("admin"))
                return;

            // create the admin role
            roleMgr.Create(new ApplicationRole() { Name = "admin" });

            // create the default user
            var userAdmin = new ApplicationUser()
            {
                UserName = "admin"
            };

            // create the user with the manager class
            userMgr.Create(userAdmin, "testing123");

            // add the user to the admin role
            userMgr.AddToRole(userAdmin.Id, "admin");
        }
    }
}
