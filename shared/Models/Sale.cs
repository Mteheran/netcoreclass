using System.Security.Cryptography;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shared.Models
{
    public class Sale
    { 
        public Guid IdSale {get;set;} = Guid.NewGuid();      
        public Guid IdInvoice {get;set;}
        public Guid IdProduct {get;set;}
        public int Quantity {get;set;}
        public decimal Product_Price {get;set;}
        public virtual Invoice Invoice {get;set;}
        public virtual Product Product {get;set;}
        
    }
}