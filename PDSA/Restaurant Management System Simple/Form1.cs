using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Restaurant_Management_System_Simple
{
    public partial class Form1 : Form
    {

        LinkedList<KeyValuePair<string, string>> users = new LinkedList<KeyValuePair<string, string>>();
        string connectionString = "Data Source=DESKTOP-TP6N7M4\\SQLEXPRESS;Initial Catalog=restro;Integrated Security=True;Encrypt=True";

        public Form1()
        {
            InitializeComponent();

            users.AddLast(new KeyValuePair<string, string>("admin", "123"));
            users.AddLast(new KeyValuePair<string, string>("guest", "guest123"));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGuest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Dashboard da = new Dashboard("Guest");
            da.Show();
            this.Hide();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                guna2MessageDialog2.Show("Please Enter Username");
                txtUsername.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                guna2MessageDialog2.Show("Please Enter Password");
                txtPassword.Focus();
                return;
            }
            var node = users.Find(user =>
                                    txtUsername.Text == user.Key &&
                                    txtPassword.Text == user.Value);

            if (node != null)  // Valid user found
            {
                Dashboard da = new Dashboard(node.Data.Key);
                da.Show();
                this.Hide();
            }
            else
            {
                guna2MessageDialog1.Show("Incorrect Username or Password!");
            }
        }
    }
 }

