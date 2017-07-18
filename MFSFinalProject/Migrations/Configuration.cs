namespace MFSFinalProject.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MFSFinalProject.Model;

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
            //
            #region DataSeed Users
            List<User> Users = new List<User>()
            {
                new User()
                {
                    Name = "Frank",
                    LastName = "Peña",
                    UserName = "stealkiller",
                    PassWord = "popodevaca963",
                    Phone = "908",
                    Remove = 0,

                }
            };
            #endregion
            #region DataSeed Products
            List<Product> Products = new List<Product>()
            {
                new Product()
                {
                    Cost = 12.3m,
                    SellPrice = 15.5m,
                    Name = "Guayaba",
                    MinStock = 10,
                    Remove = 0,
                    User = new User()
                    {
                        Name = "Frank",
                        LastName = "Peña",
                        UserName = "stealkiller",
                        PassWord = "popodevaca963",
                        Phone = "908",
                        Remove = 0,
                    },
                    Category = new Category()
                    {
                        CategoryName = "Example",
                        CategoryRemove = 0,
                        User = context.Users.Find(1)
                    },

                }
            };
            #endregion

            context.Users.AddRange(Users);
            context.Products.AddRange(Products);
        }
    }
}
