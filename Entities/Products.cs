using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public partial class Products
    { 
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public virtual Categories Category { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();


    }
}
