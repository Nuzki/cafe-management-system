using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Select_Profile : Form
    {
        string Id;
        SqlConnection con = new DB().DBconnect();
        public Select_Profile()
        {
            InitializeComponent();
        }


        private void LoadNewProfile(object sender, EventArgs e)
        {
            NewProfile newProfile = new NewProfile();
            newProfile.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (textBox1.Text == "")
                {
                    MessageBox.Show("ID cannot be null");
                }
                else
                {
                    con.Open();
                    int score = 0;
                    string id = textBox1.Text;
                    string query = "select * from Details where User_ID=@User_ID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@User_ID", textBox1.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    cmd.ExecuteNonQuery();
                    if (dataTable.Rows.Count > 0)
                    {
                        MessageBox.Show("Login successfuly");
                        Play play = new Play(id);
                        play.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("User ID not found");
                        textBox1.Clear();
                        textBox1.Focus();
                    }
                    con.Close();
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }
}
