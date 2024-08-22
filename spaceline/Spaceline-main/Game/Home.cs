using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void LoadStart(object sender, EventArgs e)
        {
            Select_Profile select_Profile = new Select_Profile();
            select_Profile.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?", "Exit message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void LoadHelp(object sender, EventArgs e)
        {
            Help help = new Help();
            help.Show();
            this.Hide();
        }

        private void LoadAbout(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
            this.Hide();
        }
    }
}
