using System;
using System.Collections.Generic;

namespace The_Winchester
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int OrderId { get; set; }
        public int? UserId { get; set; }
        public int TableNumber { get; set; }
        public DateTime? TimeOrdered { get; set; }
        public byte Completed { get; set; }
        public DateTime? TimeCompleted { get; set; }
        public byte Preparing { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
