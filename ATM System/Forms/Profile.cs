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
    public partial class Profile : Form
    {
        int accountno;
        string name;
        public Profile()
        {
            InitializeComponent();
        }
        public Profile(int accountno, string name)
        {
            InitializeComponent();
            this.accountno = accountno;
            this.name = name;
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

        private void Profile_Load(object sender, EventArgs e)
        {
            lblName.Text = name;

            UserRepo ur = new UserRepo();
            User u = ur.GetUserProfile(accountno);

            label10.Text = u.AccountNo.ToString();
            label11.Text = u.Name;
            label14.Text = "0" + u.Mobile.ToString() +"";
            label13.Text = u.Address;
            label12.Text = u.Birthday;
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
