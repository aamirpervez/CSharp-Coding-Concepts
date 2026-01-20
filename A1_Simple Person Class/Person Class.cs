using System;
namespace Person_class
{
    //Created a Person
    class Person 
    {
        //Set a short Properties for Person
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }



    //Main Program Class
    class Program 
    {
        //Main Method For Entry Point
        static void Main(string[] args)
        {
            //Create a New Object Of First Person p1 And Set All Properties
            Person p1 = new Person();
            p1.Name = "Usman";
            p1.Age = 22;
            p1.City = "Karachi";

            //Create a New Object of Second Person p2 and Set all Properties
            Person p2 = new Person();
            p2.Name = "Asad";
            p2.Age = 24;
            p2.City = "Hyderabad";

            //Create a New Object of Therd Person p2 and Set all Properties
            Person p3 = new Person();
            p3.Name = "Rafay";
            p3.Age = 27;
            p3.City = "Karachi";

            //Printing all Person
            Console.WriteLine($"Hello, I'm {p1.Name}, I'm {p1.Age} years old, and I live in {p1.City}");
            Console.WriteLine($"Hello, I'm {p2.Name}, I'm {p2.Age} years old, and I live in {p2.City}");
            Console.WriteLine($"Hello, I'm {p3.Name}, I'm {p3.Age} years old, and I live in {p3.City}");

        }
    }
}