using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shared.Models;

namespace api.DBContext
{
    public static class StoreInitializer
    {
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

            return categories;
        } 
        
    }
}