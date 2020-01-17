using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingPractice
{
    class Customer
    {
        //Property
        public string Name;
        public int Money;

        // Contructor
        public Customer(string name, int money)
        {
            Name = name;
            Money = money;
        }
        public void borrow(Bank bank, int money)
        {
            if (bank.Money >= money)
            {
                bank.Money -= money;
                Money += money;
            }
            
        }
        public void repay(Bank bank, int money)
        {
            if (Money >= money)
            {
                bank.Money += money;
                Money -= money;
            }
            
        }
    }
}
