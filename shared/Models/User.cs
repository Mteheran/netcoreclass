using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public string Email { get; set;}

        [ForeignKey("UserType")]
        public Guid IdUser_Type {get;set;} 
        public virtual UserType UserType {get;set;} 
    }
}