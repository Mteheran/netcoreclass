using System;
namespace shared.Models
{
    public class UserUserType
    {
        public Guid IdUser_Type {get; set;}
        public string Description_Type {get; set;}
        public Guid IdUser { get; set;}       
        public string Username { get; set;}       
    }
}