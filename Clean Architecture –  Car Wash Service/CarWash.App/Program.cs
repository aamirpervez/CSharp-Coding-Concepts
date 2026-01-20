using CarWash.Application.DTOs;
using CarWash.Application.Interfaces;
using CarWash.Application.Services;
using CarWash.Infrasturcture.Repositories;
using CarWash.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CarWash.App
{
    class Program
    {
        //static IServiceDetailRepository serviceRepository = new ServiceDetailRepository();
        //static IRecordDetailRepository washRecordRepository = new RecordDetailRepository();
        //static ICarDetailService carDetalService = new CarDetailService(washRecordRepository, serviceRepository);
        //static IServiceDetailService serviceDetailService = new ServiceDetailService(serviceRepository);

        


        static void Main()
        {

            var serviceCollection = new ServiceCollection();

            //Register repositories
            serviceCollection.AddSingleton<IRecordDetailRepository, RecordDetailRepository>();
            serviceCollection.AddSingleton<IServiceDetailRepository, ServiceDetailRepository>();

            //Register services
            serviceCollection.AddTransient<ICarDetailService, CarDetailService>();
            serviceCollection.AddTransient<IServiceDetailService, ServiceDetailService>();

            //Build service provider..
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var carDetalService = serviceProvider.GetService<ICarDetailService>();
            var serviceDetailService = serviceProvider.GetService<IServiceDetailService>();

            while (true)
            {
                try
                {
                    Console.WriteLine("==== Welcome To Car Wash App ====\n");

                    DisplayModeMenu();
                    Console.Write("\nEnter Number: ");
                    int modeMenuInput = int.Parse(Console.ReadLine());

                    if (modeMenuInput <= 0 || modeMenuInput > 3)
                    {
                        throw new Exception("Input Out Of Range.");
                    }
                    Console.Clear();

                    if (modeMenuInput == 1) //Admin Menu
                    {
                        while (true)
                        {
                            try
                            {
                                DisplayAdminMenu();
                                Console.Write("\nEnter Number: ");
                                int adminMenuInput = int.Parse(Console.ReadLine());

                                if (adminMenuInput <= 0 || adminMenuInput > 6)
                                {
                                    throw new Exception("Input Out Of Range.");
                                }

                                if (adminMenuInput == 1)  //Add Service
                                {
                                    AddService(serviceDetailService);
                                }
                                else if (adminMenuInput == 2) //Delete Service
                                {
                                    DeleteService(serviceDetailService);
                                }
                                else if (adminMenuInput == 3) //Update Service
                                {
                                    UpdateService(serviceDetailService);
                                }
                                else if (adminMenuInput == 4) //View All Services
                                {
                                    string services = serviceDetailService.ViewAllServices();
                                    Console.WriteLine(services);
                                    ClearConsole();
                                }
                                else if (adminMenuInput == 5) //View All Car Wash Records
                                {
                                    string records = carDetalService.ViewAllCarWashRecords();
                                    Console.WriteLine(records);
                                    ClearConsole();
                                }
                                else if (adminMenuInput == 6) //Back to Main Menu
                                {
                                    Console.Clear();
                                    break;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Error: {e.Message}");
                                ClearConsole();
                            }
                        }
                    }  //Admin Menu
                    else if(modeMenuInput == 2) //Customer Menu
                    {
                        while (true)
                        {
                            try
                            {
                                DisplayCustomerMenu();
                                int customerMenuInput = int.Parse(Console.ReadLine());

                                if (customerMenuInput <= 0 || customerMenuInput > 3)
                                {
                                    throw new Exception("Input Out Of Range.");
                                }

                                if (customerMenuInput == 1) //Register Car Wash
                                {
                                    RegisterCarWash(serviceDetailService,carDetalService);
                                    ClearConsole();
                                }
                                else if (customerMenuInput == 2) //View Available Services
                                {
                                    string services = serviceDetailService.ViewAllServices();
                                    Console.WriteLine(services);
                                    ClearConsole();
                                }
                                else if (customerMenuInput == 3) //Back to Main Menu
                                {
                                    Console.Clear();
                                    break;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Error: {e.Message}");
                                ClearConsole();
                            }
                        }
                    }  //Customer Menu
                    else if (modeMenuInput == 3)  //Exit Program
                    {
                        Console.WriteLine("Exited");
                        break;
                    }  //Exit Program
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    ClearConsole();
                }
            }
        }


        static void DisplayModeMenu()
        {
            Console.WriteLine("Select Mode");
            Console.WriteLine("1: Admin");
            Console.WriteLine("2: Customer");
            Console.WriteLine("3: Exit");
        }


        static void DisplayAdminMenu()
        {
            Console.WriteLine("Admin Menu");
            Console.WriteLine("1: Add Service");
            Console.WriteLine("2: Delete Service");
            Console.WriteLine("3: Update Service");
            Console.WriteLine("4: View All Services");
            Console.WriteLine("5: View All Car Wash Records");
            Console.WriteLine("6: Back to Main Menu");

        }


        static void DisplayCustomerMenu()
        {
            Console.WriteLine("Customer Menu");
            Console.WriteLine("1: Register Car Wash");
            Console.WriteLine("2: View Available Services");
            Console.WriteLine("3: Back to Main Menu");
        }


        static void ClearConsole()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }


        static void AddService(IServiceDetailService serviceDetailService)
        {
            Console.WriteLine("===== Adding Service =====");

            Console.Write("\nEnter Service Name: ");
            string serviceName = Console.ReadLine();

            Console.Write("\nEnter Service Price: ");
            double servicePrice = int.Parse(Console.ReadLine());

            ServiceDetailDTO dto = new ServiceDetailDTO(serviceName, servicePrice);

            serviceDetailService.AddService(dto);
            Console.WriteLine("\nService Added Successfully!\n");
            ClearConsole();
        }


        static void DeleteService(IServiceDetailService serviceDetailService)
        {
            Console.WriteLine("===== Deleting Service =====");

            Console.Write("\nEnter Service ID: ");
            int serviceId = int.Parse(Console.ReadLine());

            serviceDetailService.DeleteService(serviceId);
            Console.WriteLine("\nService Deleted Successfully\n");
            ClearConsole();
        }


        static void UpdateService(IServiceDetailService serviceDetailService)
        {
            Console.WriteLine("===== Updating Service =====");

            Console.Write("\nEnter Service ID: ");
            int serviceId = int.Parse(Console.ReadLine());

            string existService = serviceDetailService.ServiceExists(serviceId);
            Console.WriteLine(existService);

            Console.WriteLine("\nEnter New Details");
            Console.Write("\nEnter Service Name: ");
            string serviceName = Console.ReadLine();

            Console.Write("\nEnter Service Price: ");
            double servicePrice = int.Parse(Console.ReadLine());

            ServiceDetailDTO dto = new ServiceDetailDTO(serviceName, servicePrice);

            serviceDetailService.UpdateService(dto,serviceId);
            Console.WriteLine("\nService Updated Successfully\n");
            ClearConsole();
        }


        static void RegisterCarWash(IServiceDetailService serviceDetailService, ICarDetailService carDetailService)
        {
            Console.WriteLine("===== Registering Car =====");

            Console.Write("\nEnter Car Number: ");
            string carNumber = Console.ReadLine();

            Console.Write("\nEnter Owner Name: ");
            string OwnerName = Console.ReadLine();

            string services = serviceDetailService.ViewAllServices();
            Console.WriteLine(services);

            Console.WriteLine("Select Which Service You Want.");

            Console.WriteLine("\nEnter ID: ");
            int serviceId = int.Parse(Console.ReadLine());

            CarDetailDTO dto = new CarDetailDTO(carNumber, OwnerName, serviceId);

            carDetailService.RegisterCarWash(dto);
            Console.WriteLine("\nCar Registered Successfully\n");
            ClearConsole();
        }
    }
}
