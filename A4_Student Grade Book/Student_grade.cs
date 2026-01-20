using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace Student
{
    //Student class of grades
    class Student
    {
        //propertie for seting name
        public string StudentName { get; set; }

        //propertie list to store grades
        private List<double> GradeNumbers { get; set; } = new List<double>(3);

        public List<string> Subjects { get; set; } = new List<string>();

        //method to store grades in list
        public void AddGrades(double grade)
        {
            //adding grade in list
            GradeNumbers.Add(grade);
            
        }

        //method to get average of all grades
        private double CalculateAverage()
        {
            //sum all and store in a variable
            double sumAll = GradeNumbers[0] + GradeNumbers[1] + GradeNumbers[2];

            // divide all sum grades with 3 to get avverage and return it
            return sumAll / 3;
        }

        //student display method to show all required data
        public void DisplayInfo()
        {
            Console.WriteLine("Results");
            Console.WriteLine($"Student: {StudentName}");
            Console.WriteLine($"Grades: {GradeNumbers[0]}, {GradeNumbers[1]}, {GradeNumbers[2]}");
            Console.WriteLine($"Average: {CalculateAverage():f}");
        }
    }

    //main program class
    class Program
    {
        //main entry point method
        static void Main(string[] args)
        {
            //// create one object of std1 
            //Student std1 = new Student();

            //// set name to propertie
            //std1.Name = "Ali";

            ////using method to add grades and display result
            //std1.AddGrades(78, 93, 88);
            //std1.DisplayInfo();

            //Console.WriteLine();

            //// create one object of std1 
            //Student std2 = new Student();

            //// set name to propertie
            //std2.Name = "Usman";

            ////using method to add grades and display result
            //std2.AddGrades(73.22, 83.57, 79.81);
            //std2.DisplayInfo();

            Console.WriteLine("How many Students Grade book you want");
            Console.Write("Number of Student: ");
            int student = int.Parse( Console.ReadLine() );

            for( int i = 0; i < student; i++ )
            {
                Student std = new Student();

                Console.WriteLine($"\nStudent no: {i+1}");

                Console.Write("Enter Name: ");
                string studentName = Console.ReadLine();
                std.StudentName = studentName;

                Console.Write("Enter English Number: ");
                int engNum = int.Parse( Console.ReadLine() );
                Console.Write("Enter Urdu Number: ");
                int urduNum = int.Parse( Console.ReadLine() );
                Console.Write("Enter Maths Number: ");
                int mathNum = int.Parse( Console.ReadLine() );

                std.AddGrades( engNum );
                std.AddGrades( urduNum );
                std.AddGrades( mathNum );

                Console.WriteLine();
                std.DisplayInfo();
            }


        }
    }
}