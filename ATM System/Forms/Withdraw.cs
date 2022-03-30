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
    public partial class Withdraw : Form
    {
        int accountno;
        string name;
        public Withdraw()
        {
            InitializeComponent();
        }
        public Withdraw(int accountno, string name)
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

        private void Withdraw_Load(object sender, EventArgs e)
        {
            lblName.Text = name;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtWithdrawAmmount.Text == "")
            {
                MessageBox.Show("Please, enter an ammount.");
            }
            else
            {
                int ammount = Convert.ToInt32(txtWithdrawAmmount.Text);

                TransactionRepo t = new TransactionRepo();
                User result = t.CheckBalanceForWithdraw(accountno);
                Int64 balance = result.Balance;

                if (ammount >= balance)
                {
                    MessageBox.Show("You have no enough balance to withdraw");
                }
                else
                {
                    TransactionRepo tr = new TransactionRepo();
                    tr.Withdraw(accountno, ammount);
                    MessageBox.Show(ammount + " BDT is Withdraw");

                    //Insert data in transaction table
                    string transactionType = "Withdraw";
                    int transactionAmmount = ammount;
                    //get balance
                    TransactionRepo trr = new TransactionRepo();
                    User u = trr.CheckBalanceForWithdraw(accountno);
                    Int64 balance1 = u.Balance;
                    //----
                    string dateAndTime = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
                    //-------------------------
                    TransactionRepo trap = new TransactionRepo();
                    int r = trap.InsertTransactionData(accountno, transactionType, transactionAmmount, balance1, dateAndTime);
                }
            }
        }
    }
}
