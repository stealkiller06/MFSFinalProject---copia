﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MFSFinalProject.Model
{
    class MFSContext : DbContext
    {
        public MFSContext() :base("name=MFSFinalProjectConnectionString")
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Measurement> Measurements { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Suplier> Supliers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
    }
}
