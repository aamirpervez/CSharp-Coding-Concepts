using Enums;
using Store_Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCart_Classes
{
    class Customer //this class store customer details
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }
    }
    
    class CartItem //this class represent as products in cart
    {
        public Product Product { get; set; }  //  product from store
        public int Quantity { get; set; }  // quantity of product
    }

    class Cart  //this class is a customer cart and store cartitem object
    {
        public List<CartItem> ItemsInCart { get; set; } = new List<CartItem>();  // this is a cart list that contains all products and its quantity's

        public void AddItemToCart(Product productFromStore, int quantity)  // this method take product object and quantity and store in cart list
        {
            if (productFromStore != null)  // checking that product is not null
            {
                bool checkItem = ItemsInCart.Select(p => p.Product).Contains(productFromStore);  //filtering cart items to find that coming product is already contains in list.
                if (checkItem == false) // if not contains
                {
                    if (quantity > productFromStore.ProductStock)  // checking that quantity is greater than product's stock
                    {
                        Console.WriteLine($"\nThe Product Stock is Out of Range in This Quantity Currunt Remaining Stock is \"{productFromStore.ProductStock}\"");
                    }
                    else if (productFromStore.ProductStatus != ProductStatus.Active)  // checking that product is active
                    {
                        Console.WriteLine($"\nThis Product is Not Currently Active.");
                    }
                    else // creating caritem and set properties as method parameters and add to cart list
                    {
                        CartItem cartItem = new CartItem();
                        cartItem.Product = productFromStore;
                        cartItem.Quantity = quantity;
                        ItemsInCart.Add(cartItem);
                        Console.WriteLine($"\"{productFromStore.ProductName}\" Added To Cart.");
                    }
                }
                else  //if contains
                {
                    Console.WriteLine($"\nThis Item is Already in Your Cart.");
                }
            }
            else  // if product is null
            {
                Console.WriteLine("\nProduct Not Found in Store.");
            }
        }

        public void RemoveItemFromCart(int productID)  // this method check is product in cart and remove it. 
        {
            bool checkItem = ItemsInCart.Select(p => p.Product.ProductID).Contains(productID);

            if (checkItem == true)
            {
                var item = ItemsInCart.Where(cI => cI.Product.ProductID == productID).First();
                Console.WriteLine($"\n{item.Product.ProductName} Removed From Cart.");
                ItemsInCart.Remove(item);
            }
            else
            {
                Console.WriteLine($"\nItem Not Found in Your Cart With This ID: {productID}");
            }
        }
    }
}
