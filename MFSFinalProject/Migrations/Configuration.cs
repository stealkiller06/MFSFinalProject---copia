namespace MFSFinalProject.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MFSFinalProject.Model;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<MFSFinalProject.Model.MFSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MFSFinalProject.Model.MFSContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );

            if(context.Users.Where(u=>u.UserName == "Admin").Count() == 0)
            {
                context.Roles.AddOrUpdate(new Role() { Name = "Admin" });
                context.Roles.AddOrUpdate(new Role() { Name = "Cajero" });
                context.Roles.AddOrUpdate(new Role() { Name = "Almacen" });

                context.Users.AddOrUpdate(new User()
                {
                    Name = "Admin",
                    LastName = "Admin",
                    Role = context.Roles.Where(r => r.Name == "Admin").First(),
                    UserName = "Admin",
                    PassWord = "Admin",
                    Phone = "999-999-9999",

                });
            }
             
           

        }
    }
}
