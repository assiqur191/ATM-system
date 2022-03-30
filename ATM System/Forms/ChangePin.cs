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
    public partial class ChangePin : Form
    {
        int accountno;
        string name;
        public ChangePin()
        {
            InitializeComponent();
        }
        public ChangePin(int accountno, string name)
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
            ConfirmPin h = new ConfirmPin(accountno,  name);
            h.Show();
        }

        private void ChangePin_Load(object sender, EventArgs e)
        {
            lblName.Text = name;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtNewPin.Text == "" || txtConfirm.Text == "")
            {
                MessageBox.Show("Textbox cann't be empty");
            }
            else
            {
                if (txtNewPin.Text == txtConfirm.Text)
                {
                    int pin = Convert.ToInt32(txtConfirm.Text);
                    UserRepo ur = new UserRepo();
                    int result = ur.ChangePin(accountno, pin);

                    if (result > 0)
                    {
                        MessageBox.Show("Your Pin is Updated.");
                        this.Hide();
                        Home h = new Home(accountno, name);
                        h.Show();
                    }
                    else
                    {
                        MessageBox.Show("Error!!");
                    }
                }
                else
                {
                    MessageBox.Show("new pin and confirm pin dosen't match");
                }
            }
        }

        private void ChangePin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
