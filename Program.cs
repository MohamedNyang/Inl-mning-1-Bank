namespace Inlämning_1_Bank
{
    using System;

    class BankAccount
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; private set; }

        public BankAccount(string accountNumber, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"Insättning lyckades. Nytt saldo: {Balance}");
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"Uttag lyckades. Nytt saldo: {Balance}");
            }
            else
            {
                Console.WriteLine("Otillräckligt saldo.");
            }
        }

        public void ShowBalance()
        {
            Console.WriteLine($"Saldo: {Balance}");
        }
    }

    class Program
    {
        static BankAccount personalAccount = new BankAccount("001", 1000m);
        static BankAccount savingsAccount = new BankAccount("002", 5000m);
        static BankAccount investmentAccount = new BankAccount("003", 10000m);

        static void Main()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n1. Sätt in pengar\n2. Ta ut pengar\n3. Visa saldo\n4. Avsluta");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Ange kontonummer (001, 002, 003): ");
                        string depositAccount = Console.ReadLine();
                        Console.Write("Ange belopp att sätta in: ");
                        decimal depositAmount = decimal.Parse(Console.ReadLine());
                        GetAccount(depositAccount).Deposit(depositAmount);
                        break;

                    case "2":
                        Console.Write("Ange kontonummer (001, 002, 003): ");
                        string withdrawAccount = Console.ReadLine();
                        Console.Write("Ange belopp att ta ut: ");
                        decimal withdrawAmount = decimal.Parse(Console.ReadLine());
                        GetAccount(withdrawAccount).Withdraw(withdrawAmount);
                        break;

                    case "3":
                        Console.Write("Ange kontonummer (001, 002, 003): ");
                        string balanceAccount = Console.ReadLine();
                        GetAccount(balanceAccount).ShowBalance();
                        break;

                    case "4":
                        running = false;
                        Console.WriteLine("Programmet avslutas.");
                        break;

                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        break;
                }
            }
        }

        static BankAccount GetAccount(string accountNumber)
        {
            return accountNumber switch
            {
                "001" => personalAccount,
                "002" => savingsAccount,
                "003" => investmentAccount,
                _ => null,
            };
        }
   