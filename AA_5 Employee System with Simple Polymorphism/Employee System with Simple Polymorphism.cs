using System;
namespace Employee_System;

class Employee
{
    public string Name { get; set; }
    public int EmployeeId { get; set; }

    public virtual int CalculatePay()
    {
        return 0;
    }
}

class HourlyEmployee : Employee
{
    public int HourlyRate { get; set; }
    public int HoursWorked { get; set; }

    public override int CalculatePay()
    {
        return HourlyRate * HoursWorked;
    }
}

class SalariedEmployee : Employee
{
    public int MonthlySalary { get; set; }

    public override int CalculatePay()
    {
        return MonthlySalary;
    }
}

class Payroll
{
    public void ProcessPayment(Employee employee)
    {
        Console.WriteLine($"Pay: {employee.CalculatePay():c}");
    }
}

class Program 
{
    static void Main(string[] args)
    {
        HourlyEmployee hourly = new HourlyEmployee();
        hourly.Name = "Ali";
        hourly.EmployeeId = 8;
        hourly.HourlyRate = 5;
        hourly.HoursWorked = 56;

        SalariedEmployee monthly = new SalariedEmployee();
        monthly.Name = "Umar";
        monthly.EmployeeId = 4;
        monthly.MonthlySalary = 300;


        Console.WriteLine($"Hourly Employee");
        Console.WriteLine($"Name: {hourly.Name}");
        Console.WriteLine($"ID: {hourly.EmployeeId}");
        Console.WriteLine($"Hourly Rate: {hourly.HourlyRate}");
        Console.WriteLine($"Hours Worked: {hourly.HoursWorked}");
        Payroll hourpayroll = new Payroll();
        hourpayroll.ProcessPayment(hourly);
        Console.WriteLine();
        Console.WriteLine($"Monthly Employee");
        Console.WriteLine($"Name: {monthly.Name}");
        Console.WriteLine($"ID: {monthly.EmployeeId}");
        Console.WriteLine($"Monthly Salary: {monthly.MonthlySalary}");
        hourpayroll.ProcessPayment(monthly);
    }
}