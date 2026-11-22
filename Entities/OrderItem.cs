using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public partial class OrderItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public virtual Products Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
