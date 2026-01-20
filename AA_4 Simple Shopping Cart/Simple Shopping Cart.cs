using System;

namespace Simple_Shopping_Cart
{
    class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

    }

    class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public decimal GetTotalPrice()
        {
            return Product.Price * Quantity;
        }
    }

    class ShoppingCart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public void AddItem(Product Product, int quantity)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].Product == Product)
                {
                    Items[i].Quantity = quantity;
                    Console.WriteLine($"This Item is Already in Your Cart The Quantity is Updated to: {Items[i].Quantity}");
                }
            }
            CartItem item = new CartItem();
            item.Product = Product;
            item.Quantity = quantity;
            Items.Add(item);
        }
        public void RemoveItem(int ProductId)
        {
            for(int i = 0; i < Items.Count; i++)
            {
                if (Items[i].Product.ProductId == ProductId)
                {
                    Console.WriteLine($"{Items[i].Product.Name} Has Been Removed From The Cart.");
                    Items.RemoveAt(i);
                }
            }
        }
        public decimal CalculateTotal()
        {
            decimal total = 0;
            for(int i =0; i< Items.Count; i++)
            {
                total += Items[i].GetTotalPrice();
            }
            return total;
        }
        public void Checkout()
        {
            for(int i = 0; i< Items.Count; i++)
            {
                Console.WriteLine($"Product: {Items[i].Product.Name}, Price: {Items[i].Product.Price:c}, Quantity: {Items[i].Quantity}, Total Price: {Items[i].GetTotalPrice():c}");
            }
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine($"Total Amount: {CalculateTotal():c}");
            Console.WriteLine("------------------------------------------------------------------------");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Product apple = new Product();
            apple.Name = "Apple (1 kg)";
            apple.ProductId = 201;
            apple.Price = 3.63M;

            Product potato = new Product();
            potato.Name = "Potato (1 kg)";
            potato.ProductId = 205;
            potato.Price = 0.98M;

            Product keyboard = new Product();
            keyboard.Name = "Mechanical Keyboard";
            keyboard.ProductId = 102;
            keyboard.Price = 119.50M;

            Product mango = new Product();
            mango.Name = "Mango (1 kg)";
            mango.ProductId = 207;
            mango.Price = 3.12M;

            Product onion = new Product();
            onion.Name = "Onion (1 kg)";
            onion.ProductId = 105;
            onion.Price = 6.19M;

            ShoppingCart cart = new ShoppingCart();

            cart.AddItem(onion,5);
            cart.AddItem(keyboard,1);
            cart.AddItem(mango, 3);
            cart.AddItem(apple, 2);
            cart.AddItem(potato, 1);

            cart.Checkout();

            cart.RemoveItem(102);

            cart.Checkout();

        }
    }
}