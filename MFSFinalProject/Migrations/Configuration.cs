namespace MFSFinalProject.Migrations
{
    using MFSFinalProject.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MFSFinalProject.Model.MFSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
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
            //
            User user = new User()
            {
                Name = "Frank",
                LastName = "Peña",
                UserName = "stealkiller06",
                PassWord = "popodevaca963",
                Phone = "809-918-9098"
            };
            context.Users.Add(user);
            context.SaveChanges();

            context.Categories.Add(new Category
            {
                CategoryName = "Clavos",
                User = context.Users.First()
            });
            context.Measurements.Add(new Measurement()
            {
                Name = "Unidades",
                User = context.Users.First()
            });
            context.SaveChanges();

            context.Products.Add(new Product()
            {
                Name = "clavos de madera",
                Mesurement = context.Measurements.First(),
                Category = context.Categories.First(),
                User = context.Users.First(),
                MinStock = 10,
                SellPrice = 20
                
            });
            context.SaveChanges();
        }
    }
}
