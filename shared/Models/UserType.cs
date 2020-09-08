using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shared.Models
{
    public class UserType
    {
        [Key]
        [Required]
        public Guid IdUser_Type {get; set;} = new Guid();

        [MaxLength(250)]
        public string Description_Type {get; set;}

         //[JsonIgnore]
        public virtual ICollection<User> PrUsouser {get;set;} 
        
    }
}