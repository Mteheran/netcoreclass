
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace shared.Models
{
    public class Product
    {
        public Guid IdProduct {get;set;} = Guid.NewGuid();

        [Required]
        public string DescriptionProduct {get;set;}

        [Range(0, 10000)]
        public decimal Price {get;set;}

        [NotMapped]
        [JsonIgnore]
        public string Product_Prices => $"{DescriptionProduct} - {Price}";

        [ForeignKey("Category")]
        public Guid IdCategory {get;set;} 
        public virtual Category Category {get;set;} 

        public virtual ICollection<Sale> Sales {get;set;} 

    }
}