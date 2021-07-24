using System;

namespace banco
{
    public class Account
    {
        public Person Client {get;set;}
        public double Balance {get;set;}
        private double Credit {get;set;}

        public Account(Person client, double balance, double credit){
            this.Client = client;
            this.Balance = balance;
            this.Credit = credit;
        }

        public bool WithdrawMoney(double valor){
            if (this.Balance + this.Credit >= valor){
                this.Balance -= valor;
                Console.WriteLine("Sucessful!!");
                Console.WriteLine($"{this.Client.Name}, you're balance is ${Math.Round(this.Balance, 2).ToString("0.00")} now");
                return true;
            }
            else {
                Console.WriteLine($"Insufficient Balance/Credit");
                return false;
            }
        }

        public void CashDeposit(double value){
            this.Balance += value;
            Console.WriteLine($"{this.Client.Name}, you're balance is ${Math.Round(this.Balance, 2).ToString("0.00")} now");
        }

        public void TransferMoney(Account account, double value){
            if (this.WithdrawMoney(value)){
                account.CashDeposit(value);
            }
        }
    }
}