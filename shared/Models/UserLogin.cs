using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace shared.Models
{
    public class UserLogin
    {
        [Required]
        [MaxLength(50)]
        public string Username { get; set;}

        [Required]
        [MaxLength(100)]
        public string Password { get; set;}      
    }
}