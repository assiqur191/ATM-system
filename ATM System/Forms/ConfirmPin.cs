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
    public partial class ConfirmPin : Form
    {
        int accountno;
        string name;
        public ConfirmPin()
        {
            InitializeComponent();
        }
        public ConfirmPin(int accountno, string name)
        {
            InitializeComponent();
            this.accountno = accountno;
            this.name = name;
        }
        private void ConfirmPin_Load(object sender, EventArgs e)
        {
            lblName.Text = name;
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(txtOldPin.Text == "")
            {
                MessageBox.Show("Textbox cannot be empty.");
            }
            else
            {
                UserRepo ur = new UserRepo();
                User u = ur.CheckOldPassword(accountno);
                if (u.Pin == Convert.ToInt32(txtOldPin.Text))
                {
                    this.Hide();
                    ChangePin cp = new ChangePin(accountno, name);
                    cp.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect password.");
                }
            }
        }

        private void ConfirmPin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
