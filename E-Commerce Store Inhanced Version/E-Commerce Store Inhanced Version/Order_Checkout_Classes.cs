using CustomerCart_Classes;
using Enums;
using Reuse_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Checkout
{
    class Order : Customer
    {
        public int OrderID { get; set; }
        public List<CartItem> OrderItemsList { get; set; } = new List<CartItem>();
        public double TotalAmount { get; set; }
        public int DiscountApplied { get; set; }
        public double FinalAmount { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public DateTime DateTime { get; set; }
    }
    class StoreCounter
    {
        private string OrdersFilePath = @"C:\C# coding\E-Commerce Store\Customer\Orders.txt";


        public async Task CheckoutAsync(Cart cart)
        {
            Console.WriteLine("\n=============== Checkout ===============");

            Console.WriteLine("\nEnter Your Name");
            TakeInput.TakeInputString(out string name);

            Console.WriteLine("\nEnter Your Email");
            TakeInput.TakeInputString(out string email);

            Console.WriteLine("\nEnter Your Address");
            TakeInput.TakeInputString(out string address);

            double subTotal = CalculateTotal(cart);
            double discountTotal = AskAndApplyDiscount(subTotal);

            Console.WriteLine("\n\nCreating Bill...");
            await Task.Delay(1000);


            DateTime dateTime = DateTime.Now;
            Random random = new Random();
            int orderID = random.Next(0, 100);

            Order order = new Order()
            {
                CustomerName = name,
                CustomerEmail = email,
                CustomerAddress = address,
                DateTime = dateTime,
                OrderID = orderID,
                OrderItemsList = new List<CartItem>(cart.ItemsInCart),
                DiscountApplied = 20,
                TotalAmount = subTotal,
                FinalAmount = discountTotal,
            };

            Console.WriteLine($"\nDate Created {order.DateTime:g}");
            Console.WriteLine("====================== Bill ======================");
            Console.WriteLine($"Items: ");
            foreach (var item in order.OrderItemsList)
            {
                Console.WriteLine($"  Name: {item.Product.ProductName} | Quantity: {item.Quantity} x Price: {item.Product.ProductPrice * item.Quantity:c}");
                Console.WriteLine("---------------------------------------------------");
                await Task.Delay(10);
            }
            if( order.FinalAmount > 0)
            {
                Console.WriteLine("Applied Discount 20% Off.");
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine($"             Total Amount: {order.FinalAmount:c}");
            }
            else
            {
                Console.WriteLine($"Total: {order.TotalAmount:c}");
            }
            Console.WriteLine($"\nDo you want to pay this bill now? (Yes/No)");

            TakeInput.TakeInputString(out string yesNo);
            if( yesNo == "yes")
            {
                order.PaymentStatus = PaymentStatus.Completed;
                Console.WriteLine("Order Compeleted.");
            }
            else
            {
                order.PaymentStatus = PaymentStatus.Pending;
                Console.WriteLine("Order Pending.");
            }

            await SaveOrderAsync(order);
        }

        private double CalculateTotal(Cart cart)
        {
            var sumPriceAllProduct = cart.ItemsInCart.Select(p => (p.Product.ProductPrice, p.Quantity)).Select(p => p.ProductPrice * p.Quantity).Sum();
            return sumPriceAllProduct;
        }

        private double AskAndApplyDiscount(double subTotal)
        {
            Console.WriteLine("\nWe Have Christmas 20% Off Discount On Card.");
            Console.WriteLine("Do You Have Card? (Yes/No)");
            TakeInput.TakeInputYesNo(out string yesNo);

            if (yesNo.ToLower() == "yes")
            {
                Console.WriteLine("\nEnter Card no:");
                TakeInput.TakeInputNumber(out int cardno);
                double average = subTotal * 0.2;
                double afterDiscount = subTotal - average;
                Console.WriteLine("\nGreat!");
                Console.WriteLine($"Applied Christmas 20% Off Discount Amount: {average:c}");
                Console.WriteLine($"Final Amount {afterDiscount:c}");
                return afterDiscount;
            }
            else
            {
                Console.WriteLine("Discount Canceled\n");
                return 0;
            }
        }

        private async Task SaveOrderAsync(Order order)
        {
            Console.WriteLine("\nSaving Order File...");
            await Task.Delay(1500);
            await File.AppendAllTextAsync(OrdersFilePath, "\n======================================================\n");
            await File.AppendAllTextAsync(OrdersFilePath, "                    ORDER RECEIPT\n");
            await File.AppendAllTextAsync(OrdersFilePath, "======================================================\n");
            await File.AppendAllTextAsync(OrdersFilePath, $"\nOrder Created At: {order.DateTime:g}\n");
            await File.AppendAllTextAsync(OrdersFilePath,"\nItems:\n");
            foreach (var i in order.OrderItemsList)
            {
                await File.AppendAllTextAsync(OrdersFilePath, $"  • {i.Product.ProductName}   x Quantity: {i.Quantity}\n");
            }
            await File.AppendAllTextAsync(OrdersFilePath, "\n------------------------------------------------------\n");
            if(order.FinalAmount > 0)
            {
                await File.AppendAllTextAsync(OrdersFilePath, $"Discount Applied: {order.DiscountApplied}% On: {order.TotalAmount:c}");
                await File.AppendAllTextAsync(OrdersFilePath, $"\nTotal Price: {order.FinalAmount:c}");
            }
            else
            {
                await File.AppendAllTextAsync(OrdersFilePath, $"\nTotal Price: {order.TotalAmount:c}");
            }
            await File.AppendAllTextAsync(OrdersFilePath, $"\nPayment: {order.PaymentStatus}");
            await File.AppendAllTextAsync(OrdersFilePath, "\n======================================================\n\n");
            Console.WriteLine("\nOrder File Saved.");
        }
    }
}
