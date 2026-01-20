using System;

namespace Bank_Account_Transaction_History
{
    class BankAccount
    {
        public int AccountNumber { get; set; }
        private int Balance {  get; set; }

        private List<string> TransactionHistory { get; set; } = new List<string>();

        public void Deposit(int amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                TransactionHistory.Add($"{DateTime.Now:g}: Deposit {amount:c}. New Balance:{Balance:c}");
                Console.WriteLine($"Amount of {amount:c} Successfully Deposited to: {AccountNumber}");
            }
            else
            {
                Console.WriteLine("Invalid Amount!");
            }
        }
        
        public void Withdraw(int amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                TransactionHistory.Add($"{DateTime.Now:g}: Withdrawal {amount:c}. New Balance:{Balance:c}");
                Console.WriteLine($"Amount of {amount:c} Successfully Withdrawal From: {AccountNumber}");
            }
            else
            {
                Console.WriteLine("Insufficiant Balance!");
            }
        }

        public void PrintStatement()
        {
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Current Balance: {Balance}");
            for (int i = 0; i < TransactionHistory.Count; i++)
            {
                Console.WriteLine(TransactionHistory[i]);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BankAccount account1 = new BankAccount();
            account1.AccountNumber = 123456;

            BankAccount account2 = new BankAccount();
            account2.AccountNumber = 987654;

            account1.Deposit(10000);
            Console.WriteLine();
            account1.Withdraw(1000);
            Console.WriteLine();
            account1.PrintStatement();

            Console.WriteLine();
            account2.Withdraw(3000);
            Console.WriteLine();
            account2.PrintStatement();
        }
    }
}