using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Models
{
    public class Category
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        #endregion

        #region Methods
        public override string ToString()
        {
            return Name.ToString();
        }
        #endregion
    }
}

