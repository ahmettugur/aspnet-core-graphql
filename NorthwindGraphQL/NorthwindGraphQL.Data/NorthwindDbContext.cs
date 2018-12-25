using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NorthwindGraphQL.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NorthwindGraphQL.Data
{
    public class NorthwindDbContext : DbContext
    {
        public IConfigurationRoot Configuration { get; set; }
        public virtual DbSet<OrderDetailView>  OrderDetailView { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var builder = new ConfigurationBuilder()
            //    .SetBasePath(AppContext.BaseDirectory)
            //    .AddJsonFile("appsettings.json");

            //Configuration = builder.Build();


            //string connectionString = Configuration.GetConnectionString("NorthwindDbContext");

            optionsBuilder.UseSqlServer("Data Source=AHMETTU-NB\\SQLEXPRESS;Initial Catalog=Northwind;User ID=sa;Password=Admin123456;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products", schema: "dbo");
            modelBuilder.Entity<Category>().ToTable("Categories", schema: "dbo");
            modelBuilder.Entity<Supplier>().ToTable("Suppliers", schema: "dbo");
            modelBuilder.Entity<Order>().ToTable("Orders", schema: "dbo");
            modelBuilder.Entity<OrderDetailView>(entity => { entity.HasKey(e => e.OrderID); });
            //modelBuilder.Query<OrderDetailView>().ToView("OrderDetailView", schema: "dbo");
            base.OnModelCreating(modelBuilder);
        }
    }
}
