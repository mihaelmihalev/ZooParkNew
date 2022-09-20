using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Zoo.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public string password { get; set; }
        public string username { get; set; }

        public User()
        {

        }
    }
}


