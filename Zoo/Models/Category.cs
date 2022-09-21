﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }


        public Category(int id , string name)
        {
            Id = id;
            Name= name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}

