using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Zoo.Models
{
    public class User
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        #endregion
    }
}


