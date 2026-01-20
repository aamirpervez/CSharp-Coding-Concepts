using System;

namespace Vehicle_System
{
    //base class
    class Vehicle
    {
        public string Make { get; set; }
        public string Modle { get; set; }
        public ushort Year { get; set; }

        public virtual void StartEngine()
        {
            Console.WriteLine("Engine Starting...");
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Make: {Make}");
            Console.WriteLine($"Modle: {Modle}");
            Console.WriteLine($"Year: {Year}");
        }
    }

    //Derived class inherit vehicle
    class Car : Vehicle
    {
        public int NumberOfDoors { get; set; }

        public override void StartEngine()
        {
            Console.WriteLine("Car Engine Starting...");
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Number of Doors: {NumberOfDoors}");
        }
    }

    class Motorcycle : Vehicle
    {
        public bool HasSideCar { get; set; }

        public override void StartEngine()
        {
            Console.WriteLine("Motorcycle Engine Starting...");
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Side Car: {HasSideCar}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car();
            car1.Make = "Car";
            car1.Year = 2015;
            car1.Modle = "Honda";
            car1.NumberOfDoors = 4;

            Car car2 = new Car();
            car2.Make = "Car";
            car2.Year = 1992;
            car2.Modle = "Supra Mk3";
            car2.NumberOfDoors = 2;

            Motorcycle bike1 = new Motorcycle();
            bike1.Make = "Motorcycle";
            bike1.Year = 2020;
            bike1.Modle = "Honda 125";
            bike1.HasSideCar = false;

            car1.StartEngine();
            car1.DisplayInfo();

            Console.WriteLine();

            car2.StartEngine();
            car2.DisplayInfo();

            Console.WriteLine();

            bike1.StartEngine();
            bike1.DisplayInfo();
        }
    }
}