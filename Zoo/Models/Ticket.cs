using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Models
{
    public class Ticket
    {
        #region Properties
        public int Id { get; set; } 
        public string Type { get; set; }
        public decimal Price { get; set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return Type.ToString();
        }
        #endregion
    }
}
