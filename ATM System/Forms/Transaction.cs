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
    public partial class Transaction : Form
    {
        int accountno;
        string name;
        public Transaction()
        {
            InitializeComponent();
        }
        public Transaction(int accountno, string name)
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

        private void Transaction_Load(object sender, EventArgs e)
        {
            lblName.Text = name;

            TransactionRepo tr = new TransactionRepo();
            dataGridView1.DataSource = tr.GetAllTransaction(accountno);
        }

        private void Transaction_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
