using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;

namespace Reuse_Class
{
    static class TakeInput
    {
        public static void TakeInputNumber(out int num)
        {
            int input = 0;
            while (true)
            {
                try
                {
                    Console.Write("Enter: ");
                    input = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Invalid Value\n");
                }
                catch
                {
                    Console.WriteLine("Value is too long\n");
                }
            }
            num = input;
        }

        public static void TakeInputDouble(out double num)
        {
            double input = 0;
            while (true)
            {
                try
                {
                    Console.Write("Enter: ");
                    input = double.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Invalid Value\n");
                }
            }
            num = input;
        }

        public static void TakeInputSwitch(out int num,int length)
        {
            int Input = 0;
            while (true)
            {
                try
                {
                    Console.Write("Enter: ");
                    Input = int.Parse(Console.ReadLine());
                    if (Input > length || Input <= 0)
                    {
                        throw new Exception("Value out of range.");
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Invalid Value\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            num = Input;
        }

        public static void TakeInputString(out string str)
        {
            string input = "";
            while (true)
            {
                try
                {
                    Console.Write("Enter: ");
                    input = Console.ReadLine();
                    if (input == string.Empty)
                    {
                        throw new Exception("Value Can Not Be Empty.");
                    }
                    break;
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

            }
            str = input;
        }

        public static void TakeInputYesNo(out string str)
        {
            string input = "";
            while (true)
            {
                try
                {
                    Console.Write("Enter: ");
                    input = Console.ReadLine().ToLower();
                    if (input == string.Empty)
                    {
                        throw new Exception("Value Can Not Be Empty.");
                    }
                    else if (input != "yes" && input != "no")
                    {
                        throw new Exception("Value Only Be Yes/No");
                    }
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nError: {ex.Message}");
                }
            }
            str = input;
        }
    }
    static class TakeEnum
    {
        public static void TakeProductCategory(out ProductCategory cat,int choice)
        {
            switch (choice)
            {
                case 1:
                    cat = ProductCategory.Electronics;
                    break;
                case 2:
                    cat = ProductCategory.Clothing;
                    break;
                case 3:
                    cat = ProductCategory.Grocery;
                    break;
                case 4:
                    cat = ProductCategory.Sports;
                    break;
                case 5:
                    cat = ProductCategory.Beauty;
                    break;
                default:
                    cat = ProductCategory.Electronics;
                    break;
            }
        }

        public static void TakeProductStatus(out ProductStatus status, int choice)
        {
            switch (choice)
            {
                case 1:
                    status = ProductStatus.Active;
                    break;
                case 2:
                    status = ProductStatus.InActive;
                    break;
                case 3:
                    status = ProductStatus.OutOfStock;
                    break;
                default:
                    status = ProductStatus.Active;
                    break;
            }
        }
    }
}
