using System;

namespace Basic_Calculator
{
    //Created a Class Calculator 
    class Calculator
    {
        //addition return method
        public int Addition(int x, int y)
        {
            return x + y;
        }

        //subtract return method
        public int Subtract(int x, int y)
        {
            return x - y;
        }

        //multiply return method
        public int Multiply(int x, int y)
        {
            return x * y;
        } 

        //divide return method
        public int Divide(int x, int y)
        {
            return x / y;
        }
    }

    //Main Class
    class Program
    {
        //Entry point Method
        static void Main(string[] args)
        {
            //created a object for calculator
            Calculator calculator = new Calculator();

            //massage for user
            Console.WriteLine("Enter 2 Number for Calculation");

            //asking user for first number
            Console.Write("First Number: ");
            int num1 = int.Parse(Console.ReadLine());

            //asking user for second number
            Console.Write("Second Number: ");
            int num2 = int.Parse(Console.ReadLine());

            ////calculating user input by passing values to method
            int addResult = calculator.Addition(num1, num2);
            int subResult = calculator.Subtract(num1, num2);
            int mulResult = calculator.Multiply(num1, num2);
            int divResult = calculator.Divide(num1, num2);

            //print all results
            Console.WriteLine($"{num1} + {num2} = {addResult}");
            Console.WriteLine($"{num1} - {num2} = {subResult}");
            Console.WriteLine($"{num1} * {num2} = {mulResult}");
            Console.WriteLine($"{num1} / {num2} = {divResult}");
        }
    }
}