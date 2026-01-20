using Enums;
using Reuse_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store_Classes
{
    class Product   //Main Products Class Every Product Creation use this class
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public double ProductPrice { get; set; }
        public int ProductStock { get; set; }
        public ProductStatus ProductStatus { get; set; }
    }

    static class Store   //Store Class This class hold all products in store and manage the store
    {
        private static Dictionary<int, Product> ProductsCollection { get; set; } = new Dictionary<int, Product>();   //This Dictionary Store Products Collection with key of Product ID
        private static string SaveProductFilePath = @"C:\C# coding\E-Commerce Store\Store\Products.json";
        private static int GeneratedProductID = 0;


        public static void AddProductInStore(Product product)    //This Method Add Products in Store in the form of Product Collections
        {
            var dictionaryProduct = ProductsCollection.Select(p => p.Value).Select(n => n.ProductName).ToList();

            if (dictionaryProduct.Contains(product.ProductName))  //Checking product is already in Collection
            {
                Console.WriteLine($"\nThis Product is Already in a Store.");
            }
            else
            {
                GeneratedProductID++;
                product.ProductID = GeneratedProductID;
                ProductsCollection.Add(product.ProductID, product);
                Console.WriteLine($"\n{ProductsCollection[product.ProductID].ProductName}: Added to Store!");
            }
        }

        public static async Task UpdateProductInStore(int productID)  //This Method Update Product Details in Collection
        {
            if (ProductsCollection.ContainsKey(productID))  //Checking Product is Available in Collection
            {
                // Assign Contains Product in Variable
                var product = ProductsCollection[productID];

                // Asking User Want Changes in Product
                Console.WriteLine($"\nDo you Want Changes in \'{product.ProductName}\' ?(Yes/No)");
                TakeInput.TakeInputYesNo(out string changesYesNo);

                if(changesYesNo == "yes")
                {
                    bool updateMenu = true;
                    while (updateMenu)  //This Loop Hold Update Product Menu Until User Exit
                    {
                        //Menu For Which Details Want to Change
                        Console.WriteLine("\n============= Update Product ============");
                        Console.WriteLine($"Product: {product.ProductName}");
                        Console.WriteLine("Select Between These Options.");
                        Console.WriteLine("---------------------------");
                        Console.WriteLine("1: => Name");
                        Console.WriteLine("2: => Price");
                        Console.WriteLine("3: => Stock");
                        Console.WriteLine("4: => Category");
                        Console.WriteLine("5: => Status");
                        Console.WriteLine("6: => View Details");
                        Console.WriteLine("7: <- Back");
                        Console.WriteLine("---------------------------");

                        TakeInput.TakeInputSwitch(out int updateChoice,7);
                        switch (updateChoice)
                        {
                            case 1:
                                Console.WriteLine("New Name?");
                                TakeInput.TakeInputString(out string newName);
                                product.ProductName = newName;
                                Console.WriteLine($"Name Successfully Updated To {product.ProductName}");
                                break;  // Change Name
                            case 2:
                                Console.WriteLine("New Price?");
                                TakeInput.TakeInputDouble(out double newPrice);
                                product.ProductPrice = newPrice;
                                Console.WriteLine($"Price Successfully Updated To {product.ProductPrice:c}");
                                break;  // Change Price
                            case 3:
                                Console.WriteLine("New Stock?");
                                TakeInput.TakeInputNumber(out int newStock);
                                product.ProductStock = newStock;
                                Console.WriteLine($"Stock Successfully Updated To {product.ProductStock}");
                                break;  // Change Stock
                            case 4:
                                Console.WriteLine("\nSelect New Category.");
                                Console.WriteLine("1: Electronics");
                                Console.WriteLine("2: Clothing");
                                Console.WriteLine("3: Grocery");
                                Console.WriteLine("4: Sports");
                                Console.WriteLine("5: Beauty\n");

                                TakeInput.TakeInputSwitch(out int categoryChoice, 5);
                                TakeEnum.TakeProductCategory(out ProductCategory newCategory, categoryChoice);
                                product.ProductCategory = newCategory;
                                Console.WriteLine($"Catergory Successfully Updated To {product.ProductCategory}");
                                break;  // Change Category
                            case 5:
                                Console.WriteLine("\nSelect Status.");
                                Console.WriteLine("1: Active");
                                Console.WriteLine("2: Inactive");
                                Console.WriteLine("3: Out Of Stock\n");

                                TakeInput.TakeInputSwitch(out int statusChoice, 3);
                                TakeEnum.TakeProductStatus(out ProductStatus newStatus, statusChoice);
                                product.ProductStatus = newStatus;
                                Console.WriteLine($"Status Successfully Updated To {product.ProductStatus}");
                                break;  // Change Status
                            case 6:
                                Console.WriteLine("\nCurrent Product Details");
                                Console.WriteLine("---------------------------");
                                Console.WriteLine($"Name: {product.ProductName}");
                                Console.WriteLine($"ID: {product.ProductID}");
                                Console.WriteLine($"Category: {product.ProductCategory}");
                                Console.WriteLine($"Price: {product.ProductPrice:c}");
                                Console.WriteLine($"Stock: {product.ProductStock}");
                                Console.WriteLine($"Status: {product.ProductStatus}");
                                Console.WriteLine("---------------------------");
                                await Task.Delay(2000);
                                break;  // Show Current Product Details
                            case 7:
                                updateMenu = false;
                                break;  // Back
                        }
                    }
                    updateMenu = true;
                }
                else
                {
                    Console.WriteLine("Going Back.");
                }
            }
            else
            {
                Console.WriteLine("\nProduct Not Found in Store.");
            }
        }

        public static void DeleteProductInStore(int productID)  //This Method Delete the Product in Collection
        {
            if (ProductsCollection.Keys.Contains(productID))
            {
                Console.WriteLine($"\nName: {ProductsCollection[productID].ProductName} | ID: {ProductsCollection[productID].ProductID} ");
                Console.WriteLine("Do You Really Want To Delete This Product? (Yes/No)\n");
                TakeInput.TakeInputYesNo(out string yesNo);
                if(yesNo == "yes")
                {
                    ProductsCollection.Remove(productID);
                    Console.WriteLine("Product Deleted.");
                }
            }
        }

        public static Product GetProductByID(int productID)  //This method return the product from collection using product id
        {
            if (ProductsCollection.Keys.Contains(productID))
            {
                return ProductsCollection[productID];
            }
            else
            {
                return null;
            }
        }

        public static List<Product> GetAllProducts()
        {
            var products =ProductsCollection.Select(c => c.Value).ToList();
            return products;
        }

        public static List<Product> SearchByCategory(ProductCategory cat)   //get products by category
        {
            var productList = ProductsCollection.Values;
            var founded = productList.Where(p => p.ProductCategory.Equals(cat)).ToList();
            return founded;
        }

        public static List<Product> SearchByName(string name)   //get products by name
        {
            var productList = ProductsCollection.Values;
            var founded = productList.Where(p => p.ProductName.ToLower().Contains(name.ToLower())).ToList();
            return founded;
        }

        public static List<Product> SearchByStatus(ProductStatus sta)   //get products by status
        {
            var productList = ProductsCollection.Values;
            var founded = productList.Where(p => p.ProductStatus.Equals(sta)).ToList();
            return founded;
        }

        public static async Task SaveToFileAsync()  //save product json file in file path
        {
            if (ProductsCollection.Any())
            {
                Console.WriteLine("\nSaving Products File...");
                await Task.Delay(1500);

                var option = new JsonSerializerOptions()
                {
                    WriteIndented = true,
                };

                string jsonProductList = JsonSerializer.Serialize(ProductsCollection,option);
                await File.WriteAllTextAsync(SaveProductFilePath, jsonProductList);
                Console.WriteLine("Product File Saved successfully.\n");
            }
            else
            {
                Console.WriteLine("\nStore Does'nt Have Any Products To Save in File.");
            }
        }

        public static async Task LoadFromFileAsync()   //load product json file in collection
        {
            try
            {
                Console.WriteLine("\nLoading Products File....");
                await Task.Delay(100);
                string jsonData = await File.ReadAllTextAsync(SaveProductFilePath);
                var jsonProducts = JsonSerializer.Deserialize<Dictionary<int, Product>>(jsonData).Select(p => p.Value).ToList();
                var dictionaryProduct = ProductsCollection.Select(p=> p.Value).Select(n=>n.ProductName).ToList();

                Console.WriteLine("\n============ Loaded These Products ============\n");
                foreach (var item in jsonProducts)
                {
                    if (!dictionaryProduct.Contains(item.ProductName))
                    {
                        GeneratedProductID++;
                        item.ProductID = GeneratedProductID;
                        ProductsCollection.Add(item.ProductID, item);

                        Console.WriteLine($"Name: {item.ProductName} | Price: {item.ProductPrice:c}");
                        Console.WriteLine("--------------------------------------------");
                        await Task.Delay(100);
                    }
                    
                }
            }
            catch
            {
                Console.WriteLine("\nFile Not Found Loading Failed.\n");
            }

        }
    }

}
