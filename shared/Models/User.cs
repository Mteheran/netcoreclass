using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace shared.Models
{
    public class User
    {
        [Key]
        [Required]
        public Guid IdUser { get; set;} = Guid.NewGuid();

        [Required]
        [MaxLength(50)]
        public string Username { get; set;}

        [Required]
        [MaxLength(100)]
        public string Password { get; set;}

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set;}
        public Guid IdUser_Type {get;set;} 
        public virtual UserType UserType {get;set;} 

        public virtual ICollection<Invoice> Invoices {get;set;} 
    }
}