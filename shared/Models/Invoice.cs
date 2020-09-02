
using System;
namespace shared.Models
{
    public class Invoice
    {
        public Guid IdInvoice {get;set;} 
        public DateTime CreateTime {get;set;}
        public Guid IdUser {get;set;} 

    }
}