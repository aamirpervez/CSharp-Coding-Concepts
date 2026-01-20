using CustomerCart_Classes;
using Enums;
using Order_Checkout;
using Reuse_Class;
using Store_Classes;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;

namespace E_Commerce_Store
{
    class Program
    {
        static async Task Main(string[] args)
        {
            CultureInfo pakCulture = new CultureInfo("en-PK");
            CultureInfo.DefaultThreadCurrentCulture = pakCulture;
            CultureInfo.DefaultThreadCurrentUICulture = pakCulture;


            bool modeMenu = true;
            while (modeMenu)
            {
                Console.WriteLine("======== Welcome to My E-Commerce Store ========\n");

                Console.WriteLine("Please Select Your Mode.");
                Console.WriteLine("-----------------------");
                Console.WriteLine("1: => Enter as Admin");
                Console.WriteLine("2: => Enter as Customer");
                Console.WriteLine("3: => Exit");
                Console.WriteLine("-----------------------");

                TakeInput.TakeInputSwitch(out int modeChoice, 3);
                switch (modeChoice)
                {
                    case 1:
                        bool adminMenu = true;
                        while (adminMenu)
                        {
                            Console.WriteLine("\n============ Admin Menu ===========");
                            Console.WriteLine("1: => Add Product");
                            Console.WriteLine("2: => Update Product");
                            Console.WriteLine("3: => Delete Product");
                            Console.WriteLine("4: => View All Products");
                            Console.WriteLine("5: => Search Products");
                            Console.WriteLine("6: => Save Products File");
                            Console.WriteLine("7: => Load Products File");
                            Console.WriteLine("8: <- Back To Mode");
                            Console.WriteLine("===================================");

                            TakeInput.TakeInputSwitch(out int adminChoice, 8);
                            switch (adminChoice)
                            {
                                case 1:
                                    Console.WriteLine("\n===== Adding Product =====");

                                    //taking product name
                                    Console.WriteLine("Set Product Name");
                                    TakeInput.TakeInputString(out string productName);

                                    //taking product price
                                    Console.WriteLine("Set Product Price");
                                    TakeInput.TakeInputDouble(out double productPrice);

                                    //taking product stock
                                    Console.WriteLine("Set Product Stock");
                                    TakeInput.TakeInputNumber(out int productStock);

                                    //taking product category
                                    Console.WriteLine("\nSelect Product Category.");
                                    Console.WriteLine("1: Electronics");
                                    Console.WriteLine("2: Clothing");
                                    Console.WriteLine("3: Grocery");
                                    Console.WriteLine("4: Sports");
                                    Console.WriteLine("5: Beauty\n");
                                    TakeInput.TakeInputSwitch(out int categoryChoice, 5);
                                    TakeEnum.TakeProductCategory(out ProductCategory productCategory, categoryChoice);

                                    //taking product status
                                    Console.WriteLine("\nSelect Product Status.");
                                    Console.WriteLine("1: Active");
                                    Console.WriteLine("2: Inactive");
                                    Console.WriteLine("3: Out Of Stock\n");
                                    TakeInput.TakeInputSwitch(out int statusChoice, 3);
                                    TakeEnum.TakeProductStatus(out ProductStatus newStatus, statusChoice);

                                    Product newProduct = new Product()
                                    {
                                        ProductName = productName,
                                        ProductPrice = productPrice,
                                        ProductStock = productStock,
                                        ProductCategory = productCategory,
                                        ProductStatus = newStatus,
                                    };

                                    Store.AddProductInStore(newProduct);

                                    break;  // add Products to store
                                case 2:
                                    Console.WriteLine("Updating Product");
                                    Console.WriteLine("Enter Product ID");
                                    TakeInput.TakeInputNumber(out int updateID);
                                    await Store.UpdateProductInStore(updateID);
                                    break;  // update store product
                                case 3:
                                    Console.WriteLine("Deleting Product");
                                    Console.WriteLine("Enter Product ID");
                                    TakeInput.TakeInputNumber(out int DeleteID);
                                    Store.DeleteProductInStore(DeleteID);
                                    break;  // delete store product
                                case 4:
                                    var storeProducts = Store.GetAllProducts();
                                    if (storeProducts.Any())
                                    {
                                        Console.WriteLine("\n=========================== All Store Products ===========================");
                                        foreach(var item in storeProducts)
                                        {
                                            Console.WriteLine($"Name: {item.ProductName} | ID: {item.ProductID} | Price: {item.ProductPrice:c} | Status: {item.ProductStatus} | Category: {item.ProductCategory} | Stock: {item.ProductStock}");
                                            Console.WriteLine("-------------------------------------------------------------------------------------------");
                                            await Task.Delay(100);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\n Store is Empty.");
                                    }
                                        break;  // view all store products
                                case 5:
                                    bool searchMenu = true;
                                    while (searchMenu)
                                    {
                                        Console.WriteLine("\n========== Product Searching Menu ==========");
                                        Console.WriteLine("1 => Search By Name");
                                        Console.WriteLine("2 => Search By Category");
                                        Console.WriteLine("3 => Search By Status");
                                        Console.WriteLine("4 <- Back");
                                        Console.WriteLine("==============================================");

                                        TakeInput.TakeInputSwitch(out int searchChoice, 4);
                                        switch (searchChoice)
                                        {
                                            case 1:
                                                Console.WriteLine("\nEnter Product Name to Search.");

                                                TakeInput.TakeInputString(out string nameSearch);
                                                var productWithSearchName = Store.SearchByName(nameSearch);

                                                if (productWithSearchName.Any())
                                                {
                                                    Console.WriteLine($"\n===== Products With \'{nameSearch}\' =====");
                                                    Console.WriteLine("--------------------------------");
                                                    foreach(var item in productWithSearchName)
                                                    {
                                                        Console.WriteLine($"Name: {item.ProductName} | ID: {item.ProductID}");
                                                        Console.WriteLine("--------------------------------");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\nProduct Not Found With This Name.");
                                                }
                                                    break;  // search by name
                                            case 2:
                                                Console.WriteLine("\nSelect Category to Search.");
                                                Console.WriteLine("1: Electronics");
                                                Console.WriteLine("2: Clothing");
                                                Console.WriteLine("3: Grocery");
                                                Console.WriteLine("4: Sports");
                                                Console.WriteLine("5: Beauty\n");

                                                TakeInput.TakeInputSwitch(out int searchCategoryChoice, 5);
                                                TakeEnum.TakeProductCategory(out ProductCategory categorySearch, searchCategoryChoice);

                                                var productWithSearchCategory = Store.SearchByCategory(categorySearch);

                                                if (productWithSearchCategory.Any())
                                                {
                                                    Console.WriteLine($"\n===== Products With Category: \'{categorySearch}\' =====");
                                                    Console.WriteLine("--------------------------------");
                                                    foreach (var item in productWithSearchCategory)
                                                    {
                                                        Console.WriteLine($"Name: {item.ProductName} | ID: {item.ProductID}");
                                                        Console.WriteLine("--------------------------------");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\nProducts Not Found In This Category.");
                                                }
                                                break;  // search by category
                                            case 3:
                                                Console.WriteLine("\nSelect Status To Search.");
                                                Console.WriteLine("1: Active");
                                                Console.WriteLine("2: Inactive");
                                                Console.WriteLine("3: Out Of Stock\n");

                                                TakeInput.TakeInputSwitch(out int searchStatusChoice, 3);
                                                TakeEnum.TakeProductStatus(out ProductStatus statusSearch, searchStatusChoice);

                                                var productWithSearchStatus = Store.SearchByStatus(statusSearch);

                                                if (productWithSearchStatus.Any())
                                                {
                                                    Console.WriteLine($"\n===== Products With Status: \'{statusSearch}\' =====");
                                                    Console.WriteLine("--------------------------------");
                                                    foreach (var item in productWithSearchStatus)
                                                    {
                                                        Console.WriteLine($"Name: {item.ProductName} | ID: {item.ProductID}");
                                                        Console.WriteLine("--------------------------------");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\nProducts Not Found With This Status.");
                                                }

                                                break;  // search by status
                                            case 4:
                                                searchMenu = false;
                                                break;  // back
                                        }
                                    }
                                    searchMenu = true;
                                    break;  // search products
                                case 6:
                                    await Store.SaveToFileAsync();
                                    break;  // save product's file
                                case 7:
                                    await Store.LoadFromFileAsync();
                                    break;  // load product's file
                                case 8:
                                    adminMenu = false;
                                    break;  // back to mode menu
                            }
                        }
                        adminMenu = true;

                        break;  // admin options
                    case 2:
                        Cart customerCart = new Cart();
                        bool customerMenu = true;
                        while (customerMenu)
                        {
                            Console.WriteLine("\n============ Customer Menu ===========");
                            Console.WriteLine("1: => Add Product To Cart");
                            Console.WriteLine("2: => Remove Product From Cart");
                            Console.WriteLine("3: => Proceed To Cart");
                            Console.WriteLine("4: <- Back To Mode");
                            Console.WriteLine("======================================");


                            TakeInput.TakeInputSwitch(out int customerChoice, 4);  // input for customer switch choice
                            switch (customerChoice)  // customer switch
                            {
                                case 1:
                                    while (true)  // hold the purchase menu
                                    {
                                        Console.WriteLine("\n==== Select Which Types Of Products You Want. ====");
                                        Console.WriteLine("-----------------------");
                                        Console.WriteLine("1: => Electronics");
                                        Console.WriteLine("2: => Clothing");
                                        Console.WriteLine("3: => Grocery");
                                        Console.WriteLine("4: => Sports");
                                        Console.WriteLine("5: => Beauty");
                                        Console.WriteLine("-----------------------");
                                        Console.WriteLine("6: <- Back\n");

                                        TakeInput.TakeInputSwitch(out int customerCategoryChoice, 6);
                                        if(customerCategoryChoice == 6)
                                        {
                                            break;
                                        }
                                        TakeEnum.TakeProductCategory(out ProductCategory categoryChoice, customerCategoryChoice);

                                        var categoryProducts = Store.SearchByCategory(categoryChoice);

                                        if (categoryProducts.Any())
                                        {
                                            Console.WriteLine($"\n====== \'{categoryChoice}\' Items ======\n");
                                            foreach (var item in categoryProducts)
                                            {
                                                Console.WriteLine($"Name: {item.ProductName} | Price: {item.ProductPrice:c} | ID: {item.ProductID}\n");
                                                await Task.Delay(10);
                                            }
                                            while (true)  //purchase menu
                                            {
                                                Console.WriteLine("--------------------");
                                                Console.WriteLine("1: => Buy");
                                                Console.WriteLine("2: <- Back");
                                                Console.WriteLine("--------------------");
                                                TakeInput.TakeInputNumber(out int buyChoice);

                                                if (buyChoice == 1)
                                                {
                                                    Console.WriteLine("\nEnter Product ID To Add in Cart.");
                                                    TakeInput.TakeInputNumber(out int purchaseProductID);

                                                    Product getProduct = Store.GetProductByID(purchaseProductID);

                                                    Console.WriteLine($"\nEnter \'{getProduct.ProductName}\' Quantity.");
                                                    TakeInput.TakeInputNumber(out int purchaseProductQuantity);


                                                    customerCart.AddItemToCart(getProduct, purchaseProductQuantity);
                                                }
                                                else if (buyChoice == 2)
                                                {
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Error: Value Out Of Range");
                                                }
                                            }  //purchase menu

                                        }
                                        else
                                        {
                                            Console.WriteLine("\nSorry Currently We Dont Have Any Products in This Category.");
                                        }

                                    }  // hold the purchase menu
                                    break;  // Add products in cart
                                case 2:
                                    Console.WriteLine("\nEnter Product ID to Remove.");
                                    TakeInput.TakeInputNumber(out int removeProductID);
                                    customerCart.RemoveItemFromCart(removeProductID);
                                    break;  // remove products from cart
                                case 3:
                                    //customerCart.ProceedToCart();
                                    var cartItems = customerCart.ItemsInCart;
                                    if (cartItems.Any())
                                    {
                                        Console.WriteLine("\n======================= Cart Items =======================");
                                        foreach (var item in cartItems)
                                        {
                                            Console.WriteLine($"\nName: {item.Product.ProductName} | Price: {item.Product.ProductPrice:c} | Quantity: {item.Quantity} | Total: {item.Product.ProductPrice * item.Quantity:c}\n");
                                            Console.WriteLine("----------------------------------------------------------");
                                            await Task.Delay(10);
                                        }

                                        Console.WriteLine("--------------------");
                                        Console.WriteLine("Checkout (Yes/No)");
                                        TakeInput.TakeInputYesNo(out string yesNoCheckout);

                                        if(yesNoCheckout == "yes")
                                        {
                                            StoreCounter checkout = new StoreCounter();

                                            await checkout.CheckoutAsync(customerCart);
                                            customerMenu = false;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nCart is empty.");
                                    }
                                    break;  // proceed to cart
                                case 4:
                                    if (customerCart.ItemsInCart.Any())
                                    {
                                        Console.WriteLine("\nWarning if you go back your Cart will be empty.");
                                        Console.WriteLine("\nDo you Really Want To Go Back (Yes/No)");

                                        TakeInput.TakeInputYesNo(out string yesNoBack);
                                        if (yesNoBack == "yes")
                                        {
                                            customerMenu = false;
                                        }
                                    }
                                    else
                                    {
                                        customerMenu = false;
                                    }
                                        break;  // back to mode menu
                            }  // customer switch
                        }
                        customerMenu = true;
                        break;  // customer options
                    case 3:
                        modeMenu = false;
                        break;  // Exit Program
                }
            }
        }
    }
}