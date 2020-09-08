
using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
namespace shared.Models
{
    public class Invoice
    {
        [Key]
        [Required]
        public Guid IdInvoice {get;set;} 

        [Required]
        public DateTime CreateTime {get;set;}

        public Guid IdUser {get;set;} 

        public virtual User User {get;set;} 

    }
}