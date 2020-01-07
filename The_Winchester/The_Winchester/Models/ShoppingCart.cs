using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using The_Winchester.Models;

namespace The_Winchester.Models
{
    public class ShoppingCart
    {
        private readonly ISAD251_JFranklinContext _JFranklinContext;

        private ShoppingCart(ISAD251_JFranklinContext jFranklinContext)
        {
            _JFranklinContext = jFranklinContext;
        }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }


        //Return a shopping cart
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<ISAD251_JFranklinContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        //Add items to our cart
        public void AddToCart(Product product, int amount)
        {
            var shoppingCartItem = _JFranklinContext.ShoppingCartItems.SingleOrDefault(
                s => s.Product.ProductId == product.ProductId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem{ShoppingCartId = ShoppingCartId, Product = product, Amount = 1};

                _JFranklinContext.ShoppingCartItems.Add(shoppingCartItem);
            } 
            else
            {
                shoppingCartItem.Amount++;
            }
            _JFranklinContext.SaveChanges();
        }

        //Remove items from our cart
        public int RemoveFromCart(Product product)
        {
            var shoppingCartItem = _JFranklinContext.ShoppingCartItems.SingleOrDefault(
                s => s.Product.ProductId == product.ProductId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            //If there is more than one, reduce by one, if 1 then remove completely
            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _JFranklinContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _JFranklinContext.SaveChanges();

            return localAmount;
        }

        //Returns our shopping list as a List, as long as it is not null
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _JFranklinContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId).Include(s => s.Product).ToList());
        }

        //Clears our entire cart
        public void ClearCart()
        {
            var cartItems = _JFranklinContext.ShoppingCartItems.Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _JFranklinContext.ShoppingCartItems.RemoveRange(cartItems);

            _JFranklinContext.SaveChanges();
        }

        //Returns the total cost of our cart
        public decimal GetShoppingCartTotal()
        {
            var total = _JFranklinContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId).Select(c => c.Product.ProdPrice * c.Amount).Sum();

            return total;
        }
    }
}
