using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Models
{
    public class Ticket
    {
        public int Id { get; set; } 
        public string Type { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return Type.ToString();
        }
    }
}
