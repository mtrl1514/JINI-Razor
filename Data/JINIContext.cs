using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JINI.Models;

namespace JINI.Data
{
    public class JINIContext : DbContext
    {
        public JINIContext (DbContextOptions<JINIContext> options)
            : base(options)
        {
        }

        public DbSet<JINI.Models.Customer> Customers { get; set; }

        public DbSet<JINI.Models.Item> Items { get; set; }

        public DbSet<JINI.Models.Revenue> Revenues { get; set; }

        public DbSet<JINI.Models.SalesOrderItem> SalesOrderItems { get; set; }

        public DbSet<JINI.Models.SalesOrder> SalesOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Item>().ToTable("Item");
            modelBuilder.Entity<Revenue>().ToTable("Revenue");
            modelBuilder.Entity<SalesOrderItem>().ToTable("SalesOrderItem");
            modelBuilder.Entity<SalesOrder>().ToTable("SalesOrder");
        }
    }
}
