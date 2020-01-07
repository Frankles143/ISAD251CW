using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace The_Winchester
{
    public partial class Product
    {
        
        public Product()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int ProductId { get; set; }
        public string ProdName { get; set; }
        public string ProdDesc { get; set; }
        public string ProdCategory { get; set; }
        public decimal ProdPrice { get; set; }
        public byte InUse { get; set; }
        public int Stock { get; set; }
        public IEnumerable<Product> Products { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
