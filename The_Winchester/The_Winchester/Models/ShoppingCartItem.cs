using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Winchester.Models
{
    public class ShoppingCartItem
    {
        public int shoppingCartItemId { get; set; }

        public Product product { get; set; }

        public int amount { get; set; }

        public string shoppingCartId { get; set; }
    }
}
