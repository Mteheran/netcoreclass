
using System;
namespace shared.Models
{
    public class Invoice
    {
        [Key]
        [Required]
        public Guid IdInvoice {get;set;} 

        [Required]
        public DateTime CreateTime {get;set;}

        [ForeignKey("User")]
        public Guid IdUser {get;set;} 

        public virtual User User {get;set;} 

    }
}