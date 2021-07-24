using System;
using System.Collections.Generic;

namespace banco
{
    class Program
    {
        public static List<Account> accounts = new List<Account>();
        static void Main(string[] args)
        {   
            string option;
            double value;
            Account account;

            NewAccount("Diego", 300.00);
            NewAccount("Maria", 200.00);

            option = Menu();
            
            while (option != "X"){
                switch(Int16.Parse(option)){
                    case 1:
                        account = ChooseAccount();
                        Console.WriteLine("Quanto deseja sacar?");
                        value = Convert.ToDouble(Console.ReadLine());
                        account.WithdrawMoney(value);
                        break;
                    case 2:
                        account = ChooseAccount();
                        Console.WriteLine("Quanto deseja depositar?");
                        value = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine(value);
                        account.CashDeposit(value);
                        break;
                    case 3:
                        Console.WriteLine("Quem está enviando o dinheiro?");
                        Account accountSender = ChooseAccount();
                        Console.WriteLine("Para quem você deseja transferir?");
                        Account accountReceiver = ChooseAccount();
                        Console.WriteLine("Qual o valor da transferência?");
                        value = Convert.ToDouble(Console.ReadLine());
                        accountSender.TransferMoney(accountReceiver, value);
                        break;
                    case 4:
                        Console.WriteLine("Qual o seu nome?");
                        string name = Console.ReadLine();
                        Console.WriteLine("Qual o saldo inicial?");
                        double initialBalance = Convert.ToDouble(Console.ReadLine());
                        NewAccount(name, initialBalance);
                        break;
                    case 5:
                        IndexAccount();
                        break;
                }
                option = Menu();
            }
        }

        private static string Menu(){
            Console.WriteLine("Escolha a operação que você deseja realizar: ");
            Console.WriteLine("[1] Saque ");
            Console.WriteLine("[2] Depósito  ");
            Console.WriteLine("[3] Transferência ");
            Console.WriteLine("[4] Adicionar conta ");
            Console.WriteLine("[5] Listar Contas");
            Console.WriteLine("[X] Sair");

            string option = Console.ReadLine();
            return option.ToUpper();
        }

        private static void NewAccount(string name, double balance){
            // Creating account with standard birthdate
            Person person = new Person(name, "11/11/2000");
            Account account = new Account(person, balance, 50.00);
            accounts.Add(account);
        }

        private static void IndexAccount(){
            int index = 0;
            Console.WriteLine(" #  |   Name    ");
            foreach(Account account in accounts){
                Console.WriteLine($"[{index}] |   {account.Client.Name}  | {account.Balance}");
                index++;
            }
        }

        private static Account ChooseAccount(){
            IndexAccount();
            string option = Console.ReadLine().ToUpper();
            if (option != "X"){
                int accountOption = Convert.ToInt32(option);    
                return accounts[accountOption];
            }
            return null;
        }
    }
}
