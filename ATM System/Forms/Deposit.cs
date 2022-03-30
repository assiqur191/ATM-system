using ATM_System.Entities;
using ATM_System.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_System.Forms
{
    public partial class Deposit : Form
    {
        int accountno;
        string name;
        public Deposit()
        {
            InitializeComponent();
        }
        public Deposit(int accountno, string name)
        {
            InitializeComponent();
            this.accountno = accountno;
            this.name = name;
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home h = new Home(accountno, name);
            h.Show();
        }

        private void Deposit_Load(object sender, EventArgs e)
        {
            lblName.Text = name;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(txtDepositAmmount.Text == "")
            {
                MessageBox.Show("Please, enter an ammount.");
            }
            else
            {
                int ammount = Convert.ToInt32(txtDepositAmmount.Text);

                TransactionRepo tr = new TransactionRepo();
                tr.Deposit(accountno, ammount);
                MessageBox.Show(ammount + " BDT is Deposited");

                //Insert data in transaction table
                string transactionType = "Deposit";
                int transactionAmmount = ammount;
                //get balance
                TransactionRepo trr = new TransactionRepo();
                User u = trr.CheckBalanceForWithdraw(accountno);
                Int64 balance = u.Balance;
                //----
                string dateAndTime = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
                //-------------------------
                TransactionRepo trap = new TransactionRepo();
                int result = trap.InsertTransactionData(accountno, transactionType, transactionAmmount, balance, dateAndTime);
            }
        }
    }
}
