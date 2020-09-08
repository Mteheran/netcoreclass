using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shared.Models;

namespace api.DBContext
{
    public static class StoreInitializer
    {
        private static IEnumerable<Category> Categories;
        private static IEnumerable<Product> Products;
        private static IEnumerable<UserType> UserTypes;
        private static IEnumerable<User> Users;
        private static IEnumerable<Invoice> Invoices;

        public static IEnumerable<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            
            categories.Add(new Category()
            {
                IdCategory = Guid.NewGuid(),
                Description_Category = "Category 1"
            });

             
            categories.Add(new Category()
            {
                IdCategory = Guid.NewGuid(),
                Description_Category = "Category 2"
            });

             
            categories.Add(new Category()
            {
                IdCategory = Guid.NewGuid(),
                Description_Category = "Category 3"
            });

            Categories = categories;
            return Categories;
        } 

         public static IEnumerable<Product> GetProducts()
        {
            if(Categories == null) Categories = GetCategories();

            List<Product> products = new List<Product>();

            foreach(var item in  Categories)
            {
                    products.Add(new Product()
                    {
                      IdCategory = item.IdCategory,
                      DescriptionProduct = "Producto" + DateTime.Now.Millisecond,
                      Price = Decimal.Parse((new Random().NextDouble() * 1000).ToString())
                    });

                products.Add(new Product()
                    {
                      IdCategory = item.IdCategory,
                      DescriptionProduct = "Producto" + DateTime.Now.Millisecond,
                      Price = Decimal.Parse((new Random().NextDouble() * 1000).ToString())
                    });
            }

            Products = products;
            return Products;
        } 

        public static IEnumerable<UserType> GetUserTypes()
        {
            List<UserType> usertypes = new List<UserType>();
            
            usertypes.Add(new UserType()
            {
                IdUser_Type = Guid.NewGuid(),
                Description_Type = "Tipo Usuario 1"
            });

             
            usertypes.Add(new UserType()
            {
                IdUser_Type = Guid.NewGuid(),
                Description_Type = "Tipo Usuario 2"
            });

            usertypes.Add(new UserType()
            {
                IdUser_Type = Guid.NewGuid(),
                Description_Type = "Tipo Usuario 3"
            });

            UserTypes = usertypes;
            return UserTypes;
        } 


        public static IEnumerable<User> GetUsers()
        {
            if(UserTypes == null) UserTypes = GetUserTypes();

            List<User> users = new List<User>();

            foreach(var item in  UserTypes)
            {
                    users.Add(new User()
                    {
                      IdUser_Type = item.IdUser_Type,
                      Username = "Usuario" + DateTime.Now.Millisecond,
                      Password = "Pass" + DateTime.Now.Millisecond,
                      Email = "correo" + DateTime.Now.Millisecond +"@correo.com"
                    });

                    users.Add(new User()
                    {
                      IdUser_Type = item.IdUser_Type,
                      Username = "Usuario" + DateTime.Now.Millisecond,
                      Password = "Pass" + DateTime.Now.Millisecond,
                      Email = "correo" + DateTime.Now.Millisecond +"@correo.com"
                    });
            }

            Users = users;
            return Users;
        }

        public static IEnumerable<Invoice> GetInvoices()
        {
            if(Users == null) Users = GetUsers();

            List<Invoice> invoices = new List<Invoice>();

            foreach(var item in  Users)
            {
                    invoices.Add(new Invoice()
                    {
                      IdUser = item.IdUser,
                      CreateTime = DateTime.Now                      
                    });

                    
            }

            Invoices = invoices;
            return Invoices;
        }  
        
    }
}