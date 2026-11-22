using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public partial class Categories
    {
       public int Id { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Products> Products { get; set; }=new List<Products>();

    }
}
