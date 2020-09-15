using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace shared.Models
{
    public class UserType
    {
        [Key]
        [Required]
        public Guid IdUser_Type {get; set;} = new Guid();

        [Required]
        [MaxLength(250)]
        public string Description_Type {get; set;}

         //[JsonIgnore]
        public virtual ICollection<User> Users {get;set;} 
        
    }
}