using ATM_System.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_System.Forms
{
    public partial class Home : Form
    {
        int accountno;
        string name;
        public Home()
        {
            InitializeComponent();
        }
        public Home(User ue)
        {
            InitializeComponent();
            this.accountno = ue.AccountNo;
            this.name = ue.Name;
        }
        public Home(int accountno, string name)
        {
            InitializeComponent();
            this.accountno = accountno;
            this.name = name;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            
        }

        private void lblExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Balance b = new Balance(accountno, name);
            b.Show();
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            this.Hide();
            Transaction t = new Transaction(accountno, name);
            t.Show();
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Deposit d = new Deposit(accountno, name);
            d.Show();
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            this.Hide();
            Withdraw w = new Withdraw(accountno, name);
            w.Show();
        }

        private void btnChangePin_Click(object sender, EventArgs e)
        {
            this.Hide();
            ConfirmPin cp = new ConfirmPin(accountno, name);
            cp.Show();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            Profile p = new Profile(accountno, name);
            p.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            lblName.Text = name;
        }
    }
}
