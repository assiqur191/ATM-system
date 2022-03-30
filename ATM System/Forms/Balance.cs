using ATM_System.Entities;
using ATM_System.Repositories;
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
    public partial class Balance : Form
    {
        int accountno;
        string name;
        public Balance()
        {
            InitializeComponent();
        }
        public Balance(int accountno, string name)
        {
            InitializeComponent();
            this.accountno = accountno;
            this.name = name;
        }

        private void Balance_Load(object sender, EventArgs e)
        {
            lblName.Text = name;

            UserRepo ur = new UserRepo();
            User u = ur.CheckBalance(accountno);

            label9.Text = u.Name;
            label10.Text = u.AccountNo.ToString();
            label11.Text = u.Balance.ToString();
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
    }
}
