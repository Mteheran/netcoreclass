
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shared.Models
{
    public class Product
    {
        public Guid IdProduct {get;set;} = Guid.NewGuid();
        public string DescriptionProduct {get;set;}


        [Range(0, 9999999999999999.99)]
        public decimal Price {get;set;} 

        [ForeignKey("Category")]
        public Guid IdCategory {get;set;} 
        public virtual Category Category {get;set;} 

    }
}