
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace shared.Models
{
    public class Invoice
    {
        [Key]
        [Required]
        public Guid IdInvoice {get;set;} = Guid.NewGuid(); 

        [Required]
        public DateTime CreateTime {get;set;}

        [ForeignKey("User")]
        public Guid IdUser {get;set;} 

        public virtual User User {get;set;} 

        public virtual ICollection<Sale> Sales {get;set;} 

    }
}