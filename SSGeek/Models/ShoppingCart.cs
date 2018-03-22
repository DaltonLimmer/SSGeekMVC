using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSGeek.Models
{
    public class ShoppingCart
    {
        public List<ShoppingCartItem> Items { get; } = new List<ShoppingCartItem>();

        public void AddToCart(Product p, int quantity)
        {
            //Add new item, if it doesn't exist; otherwise increase quantity by 1
            bool itemFound = false;
            foreach (ShoppingCartItem item in Items)
            {
                if (item.Product.ProductId == p.ProductId)
                {
                    item.Quantity += quantity;
                    itemFound = true;
                }
            }

            if (!itemFound)
            {
                Items.Add(new ShoppingCartItem() { Product = p, Quantity = quantity });
            }
        }

        public void RemoveFromCart( Product p)
        {
            ShoppingCartItem item = null;

            foreach (ShoppingCartItem itemToRemove in Items)
            {
                if(itemToRemove.Product.ProductId == p.ProductId)
                {

                    itemToRemove.Quantity--;
                    if (itemToRemove.Quantity <= 0)
                    {
                        item = itemToRemove;

                    }

                }

            }

            Items.Remove(item);
        }

        public double GetTotalCost()
        {
            double totalCost = 0;
            foreach (ShoppingCartItem item in Items)
            {
                totalCost += item.Quantity * item.Product.Price;

            }
            return totalCost;
        }

    }
}