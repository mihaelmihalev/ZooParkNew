using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Category { get; set; }
       // public string Category { get; set; }
        
        // public Category Category { get; set; }
     
        public override string ToString()
        {
            return Category.ToString();
        }


    }

}
