using System;
using System.Collections.Generic;

namespace The_Winchester_API
{
    public partial class Product
    {
        public Product()
        {

        }

        public int ProductId { get; set; }
        public string ProdName { get; set; }
        public string ProdDesc { get; set; }
        public string ProdCategory { get; set; }
        public decimal ProdPrice { get; set; }
        public byte InUse { get; set; }
        public int Stock { get; set; }

    }
}
