using System;
using System.Threading.Channels;

namespace Rectangle_Area_Calculator
{
    //rectangle blueprint class
    class Rectangle
    {
        //properties to get access from outside of class and store values
        public double Length { get; private set; }
        public double Width { get; private set; }

        // constructor to store values while creating the object
        // peremeterize constructor
        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }

        // this method return the area of length and width by multiplying values
        public double CalculateArea()
        {
            return Length * Width;
        }

        // this method return the perimeter of length and width by suming them and multiply by 2
        public double CalculatePerimeter()
        {
            return 2 * (Length + Width);
        }

        // this method check is both values are equal if yes it return ture that this is square
        public bool IsSquare()
        {
            if(Length == Width)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    // main program class
    class Program
    {
        // entry point method
        static void Main(string[] args)
        {
            //create first rectangle and pass the value to its constructor
            Rectangle rt1 = new Rectangle(2, 8);
            Console.WriteLine($"First Rectangle Area: {rt1.CalculateArea()}");
            Console.WriteLine($"First RectanglePerimeter: {rt1.CalculatePerimeter()}");
            Console.WriteLine($"First Rectangle is Square: {rt1.IsSquare()}\n");

            //create second rectangle and pass the value to its constructor
            Rectangle rt2 = new Rectangle(7, 7);
            Console.WriteLine($"Second Rectangle Area: {rt2.CalculateArea()}");
            Console.WriteLine($"Second RectanglePerimeter: {rt2.CalculatePerimeter()}");
            Console.WriteLine($"Second Rectangle is Square: {rt2.IsSquare()}\n");

            //create thered rectangle and pass the value to its constructor
            Rectangle rt3 = new Rectangle(6, 10);
            Console.WriteLine($"Threed Rectangle Area: {rt3.CalculateArea()}");
            Console.WriteLine($"Threed RectanglePerimeter: {rt3.CalculatePerimeter()}");
            Console.WriteLine($"Threed Rectangle is Square: {rt3.IsSquare()}");


        }
    }
}