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
    public partial class Pause : Form
    {
        string ID;
        SqlConnection con = new DB().DBconnect();
        public Pause(string id)
        {
            InitializeComponent();
            ID = id;
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(ID);
            form1.Show();
            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?", "Exit message", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
            {
                Application.Exit();
            }
         
            
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }
}
