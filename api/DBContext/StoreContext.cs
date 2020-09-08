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
        public DbSet<User> Users {get;set;}

        public StoreContext(DbContextOptions<StoreContext> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Category>().HasKey(p=> p.IdCategory);

            builder.Entity<Category>()
                                .ToTable("Category")
                                .HasData(StoreInitializer.GetCategories());

            builder.Entity<Category>().HasMany<Product>("Products")
                                    .WithOne("Category")
                                    .OnDelete(DeleteBehavior.Cascade);

                                
            
            

            builder.Entity<Product>()
                                .ToTable("Product")
                                .HasKey(p=> p.IdProduct);

            builder.Entity<Product>().HasData(StoreInitializer.GetProducts());

            builder.Entity<Product>()
                                .HasOne<Category>("Category")
                                .WithMany("Products")
                                .HasForeignKey(p=> p.IdCategory)
                                .OnDelete(DeleteBehavior.Cascade);    


            builder.Entity<UserType>()
                                .ToTable("UserType")
                                .HasKey(p=> p.IdUser_Type);

            builder.Entity<UserType>()
                                .ToTable("UserType")
                                .HasData(StoreInitializer.GetUserTypes());

            builder.Entity<UserType>().HasMany<User>("Users")
                                    .WithOne("UserType")
                                    .OnDelete(DeleteBehavior.Cascade);
          
            builder.Entity<User>()
                                .ToTable("User")
                                .HasKey(p=> p.IdUser);          
            
            builder.Entity<User>().HasData(StoreInitializer.GetUsers());

            builder.Entity<User>()
                                .HasOne<UserType>("UserType");

            builder.Entity<User>().HasMany<Invoice>("Invoices")
                                    .WithOne("User")
                                    .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Invoice>()
                                .ToTable("Invoice")
                                .HasKey(p=> p.IdInvoice);
            builder.Entity<Invoice>().HasData(StoreInitializer.GetInvoices()); 
            builder.Entity<Invoice>()
                                .HasOne<User>("User")
                                .WithMany("Invoices")
                                .HasForeignKey(p=> p.IdUser)
                                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Sale>()
                                .ToTable("Sale")
                                .HasKey(p=> p.IdSale);   

            builder.Entity<Sale>()
                                .HasOne<Invoice>("Invoice");

            builder.Entity<Sale>()
                                .HasOne<Product>("Product");                                 
            
        }

        
    }
}