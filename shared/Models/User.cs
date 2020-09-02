using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shared.Models
{
    public class User
    {
        public Guid IdUser { get; set;}

        public string Username { get; set;}

        public string Password { get; set;}

        public string Email { get; set;}

        public Guid IdUser_Type { get; set;}
    }
}