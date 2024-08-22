using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class NewProfile : Form
    {
        SqlConnection con=new DB().DBconnect();
        public NewProfile()
        {
            InitializeComponent();
        }

        private void LoadNext(object sender, EventArgs e)
        {
            Select_Profile play=new Select_Profile();
            play.Show();
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
                    string query = "insert into Details values(@User_ID,@Score)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@User_ID", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Score", score);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account created successfuly");
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error"+ex);
                con.Close();
            }
        }
    }
}
