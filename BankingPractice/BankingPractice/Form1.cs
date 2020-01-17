using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingPractice
{
    public partial class Form1 : Form
    {
        Customer customer; Bank bank;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            customer = new Customer(CustomerInput.Text, 0);
            bank = new Bank(BankInput.Text, 200000);

            CustomerNameLabel.Text = CustomerInput.Text;
            BankNameLabel.Text = BankInput.Text;

            // 確認後則無法再做修改
            button1.Enabled = false;
            CustomerInput.Enabled = false;
            BankInput.Enabled = false;

            // 開啟借還錢按鈕
            BorrowButton.Enabled = true;
            RePayButton.Enabled = true;

            BorrowButton.Text = customer.Name + " 跟 " + bank.Name + " 銀行借 1000 元";
            RePayButton.Text = customer.Name + " 還給 " + bank.Name + " 銀行 1000 元";
        }

        private void BorrowButton_Click(object sender, EventArgs e)
        {
            customer.borrow(bank, 1000);
            updateDollar();
        }

        private void RePayButton_Click(object sender, EventArgs e)
        {
            customer.repay(bank, 1000);
            updateDollar();
        }
        private void updateDollar()
        {
            CustomerDollarLabel.Text = "" + customer.Money;
            BankDollarLabel.Text = "" + bank.Money;
        }
    }
}
