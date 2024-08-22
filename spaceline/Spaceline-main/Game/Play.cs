using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Game
{
    public partial class Play : Form
    {
        string ID;
        SqlConnection con = new DB().DBconnect();
        public Play(string id)
        {
            InitializeComponent();
            ID=id;
        }

        private void LoadPlay(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(ID);
            form1.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?", "Exit message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            H_Score h_Score = new H_Score();
            h_Score.Show();
            this.Hide();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }
}
