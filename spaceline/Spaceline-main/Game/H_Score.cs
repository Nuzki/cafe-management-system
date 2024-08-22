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
    public partial class H_Score : Form
    {
        SqlConnection con = new DB().DBconnect();
        public H_Score()
        {
            InitializeComponent();
        }

        private void H_Score_Load(object sender, EventArgs e)
        {
            con.Open();
            int score = 0;

            string query = "SELECT * FROM Details order by Score desc";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            cmd.ExecuteNonQuery();
            dataGridView1.DataSource = dataTable;
            con.Close();
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
                    string query = "Delete from Details where User_ID=@User_ID ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@User_ID", textBox1.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account Deleted successfuly");
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Play play = new Play(textBox1.Text);
            play.Show();
            this.Hide();

        }

    }
}
