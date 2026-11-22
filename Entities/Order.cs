using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public partial class Order
    {
        public int Id { get; set; }
        public DateOnly OrderDate { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int TotalPrice { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
