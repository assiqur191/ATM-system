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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.Show();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtAccountNo.Text == "" || txtName.Text == "" || txtMobile.Text == "" || txtAddress.Text == "" || txtPin.Text == "") 
            {
                MessageBox.Show("Missing Information.");
            }
            else
            {
                int accno = Convert.ToInt32(txtAccountNo.Text);
                UserRepo cka = new UserRepo();
                int getResult = cka.CheckAccount(accno);
                if(getResult == 1)
                {
                    MessageBox.Show("Enter a valid Account Number.");
                }
                else
                {
                    int accountno = accno;
                    string name = txtName.Text;
                    int mobile = Convert.ToInt32(txtMobile.Text);
                    string address = txtAddress.Text;
                    int pin = Convert.ToInt32(txtPin.Text);
                    string birthday = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                    int balance = 0;

                    UserRepo ur = new UserRepo();
                    int result = ur.AddNewUser(accountno, name, mobile, address, pin, birthday, balance);
                    if (result > 0)
                    {
                        MessageBox.Show("Data Inserted");
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                }
            }
        }

        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
