
using System;
using System.ComponentModel.DataAnnotations;

namespace shared.Models
{
    public class Category
    {
        [Key]
        [Required]
        public Guid IdCategory {get;set;} = new Guid();

        [MaxLength(250)]
        public string Description_Category {get;set;} 
    }
}