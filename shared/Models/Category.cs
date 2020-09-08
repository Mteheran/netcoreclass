
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace shared.Models
{
    public class Category
    {
        [Key]
        [Required]
        public Guid IdCategory {get;set;} = new Guid();

        [MaxLength(250)]
        [Required]
        public string Description_Category {get;set;}

        //[JsonIgnore]
        public virtual ICollection<Product> Products {get;set;} 
    }
}