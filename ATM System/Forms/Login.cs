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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Register rg = new Register();
            rg.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtAccountNo.Text == "" || txtPin.Text == "")
            {
                MessageBox.Show("AccountNO or Pin can not be empty.");
            }
            else
            {
                int accountno = Convert.ToInt32(txtAccountNo.Text);
                int pin = Convert.ToInt32(txtPin.Text);

                User ue = new User();
                ue.AccountNo = accountno;
                ue.Pin = pin;

                UserRepo ur = new UserRepo();
                User result = ur.UserLogin(ue);

                if (result == null)
                {
                    MessageBox.Show("Invalid Account and Pin");
                }
                else
                {
                    this.Hide();
                    Home h = new Home(result);
                    h.Show();
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
