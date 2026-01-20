using System;
using System.Threading.Tasks.Dataflow;
namespace Bank_Account
{
    //bank account class
    class BankAccount
    {

        //a public propertie to store account names
        public string AccountHolder { get; set; }

        //private propertie to store balance
        private double Balance { get; set; }

        //method to store money in accounts
        public void DepositBalance(double amount)
        {
            // if statment to check ammount accaptable 
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"Amount of {amount:c} Successfully Deposited to : {AccountHolder}");
            }
            else
            {
                Console.WriteLine("Invalid Amount Error Negative Amount");
            }
        }

        //method to withdraw money from accounts
        public void WithdrawBalance(double amount)
        {
            // if statment to check ammount accaptable
            if (Balance >= amount && amount > 0)
            {
                Balance -= amount;
                Console.WriteLine($"Amount of {amount:c} Successfully Withdrawal from : {AccountHolder}");
            }
            else
            {
                Console.WriteLine($"insufficient Balance in {AccountHolder}");
            }
        }

        //method to show current balance of account
        public void ShowBalance()
        {
            Console.WriteLine($"The Current Balance of {AccountHolder} is : {Balance:c}");
        }
    }

    //main class
    class Program
    {
        //program entry point method
        static void Main(string[] args)
        {
            //storing two account objects
            BankAccount account1 = new BankAccount();
            BankAccount account2 = new BankAccount();

            //giving names to accounts
            account1.AccountHolder = "Umar";
            account2.AccountHolder = "Ali";

            //using methods to see account1 actions
            account1.DepositBalance(100);
            account1.WithdrawBalance(40);
            account1.ShowBalance();
            account1.DepositBalance(50);
            account1.ShowBalance();

            //using methods to see account1 actions
            Console.WriteLine();
            account2.DepositBalance(130);
            account2.WithdrawBalance(25);
            account2.ShowBalance();
            account2.DepositBalance(80);
            account2.ShowBalance();
        }
    }
}