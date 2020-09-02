using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using shared.Models;

namespace api.DBContext
{
    public class StoreContext : DbContext
    {
        public DbSet<Category> Categories {get;set;}
        public DbSet<Invoice> Invoices {get;set;}
        public DbSet<Product> Products {get;set;}
        public DbSet<Sale> Sales {get;set;}
        public DbSet<UserType> UserTypes {get;set;}
        DbSet<User> Users {get;set;}

        public StoreContext(DbContextOptions<StoreContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>()
                                .ToTable("Category")
                                .HasKey(p=> p.IdCategory);

            builder.Entity<Category>().HasData(StoreInitializer.GetCategories());

            builder.Entity<Invoice>()
                                .ToTable("Invoice")
                                .HasKey(p=> p.IdInvoice);

            builder.Entity<Product>()
                                .ToTable("Product")
                                .HasKey(p=> p.IdProduct);

            builder.Entity<UserType>()
                                .ToTable("UserType")
                                .HasKey(p=> p.IdUser_Type);
            builder.Entity<Sale>()
                                .ToTable("Sale")
                                .HasKey(p=> p.IdSale);   
            builder.Entity<User>()
                                .ToTable("User")
                                .HasKey(p=> p.IdUser);                  

            
        }

        
    }
}