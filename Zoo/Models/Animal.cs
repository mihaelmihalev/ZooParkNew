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

        public string Description { get; set; }

        public byte[] Image { get; set; }
       
        public Animal (int id , string name , string category , string description , byte[] image)
        {
            Id = id;
            Name = name;
            Category = category;
            Description = description;
            Image = image;
        }
     
        public override string ToString()
        {
            return Category.ToString();
        }


    }

}
