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
            return categories;
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
        
    }
}