using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Game
{
    public partial class Form1 : Form
    {
        string ID;
        SqlConnection con = new DB().DBconnect();

        int gravity = 10;
        int mountainSpeed = 8;
        int gameScore = 0;
        int energyCount = 3;
        int energyFreeTime = 0;
        bool gameOver = false;

        public Form1(string id)
        {
            InitializeComponent();
            ID = id;
        }


        private void gameTimeTickEvent(object sender, EventArgs e)
        {
            ufoFadingEffect();

            energyFreeTime += 20;
            ufo.Top += gravity;
            mountain_bottom.Left -= mountainSpeed;
            mountain_top.Left -= mountainSpeed;
            exEnergy.Left -= mountainSpeed;

            if(mountain_bottom.Left < -150)
            {
                mountain_bottom.Left = 750;
                gameScore++;
            }

            if (mountain_top.Left < -80)
            {
                mountain_top.Left = 950;
                gameScore++;
            }

            if(ufo.Bounds.IntersectsWith(mountain_top.Bounds) || ufo.Bounds.IntersectsWith(mountain_bottom.Bounds) || ufo.Bounds.IntersectsWith(ground.Bounds) || ufo.Bounds.IntersectsWith(sky.Bounds))
            {
                endGame();
            }

            if (ufo.Bounds.IntersectsWith(exEnergy.Bounds) && energyCount < 3)
            {
                extraEnergyFunction();               
            }

            if(exEnergy.Left < -10)
            {
                exEnergy.Left = 10000;
            }

            if(energyCount == 1)
            {
                energy1.Visible = true;
            }

            if (energyCount == 2)
            {
                energy2.Visible = true;
            }

            if (energyCount == 3)
            {
                energy3.Visible = true;
            }

            score_lbl.Text = "Score : " + gameScore;

        }

        private void KeyUpEvent(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = 10;
            }
            if(e.KeyCode == Keys.R && gameOver)
            {
                RestartGame();
                gameOverLabel.Visible = false;

            }
        }

        private void KeyDownEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -10;
            }
        }

        private void endGame()
        {
            if(ufo.Bounds.IntersectsWith(ground.Bounds) || ufo.Bounds.IntersectsWith(sky.Bounds))
            {
                game_time.Stop();
                gameOverLabel.Text = "Game Over!!! \n Your score is : " + gameScore + "\n Press 'R' to Restart";
                gameOverLabel.Visible = true;
                gameOver = true;

            }
            if(energyCount == 0 && energyFreeTime > 3000)
            {
                game_time.Stop();
                gameOverLabel.Text = "Game Over!!! \n Your score is : " + gameScore + "\n Press 'R' to Restart";
                gameOverLabel.Visible = true;
                try
                {
                    
                        con.Open();
                        int score = 0;
                        string query = "update Details set Score=@Score where User_ID=@User_ID";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Score", gameScore);
                        cmd.Parameters.AddWithValue("@User_ID", ID);
                        cmd.ExecuteNonQuery();
                        con.Close();
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex);
                    con.Close();
                }
            }
            else
            {
                switch (energyCount)
                {
                    case 3:
                        if(energyFreeTime > 2500)
                        {
                            energy3.Visible = false;
                            energyCount--;
                            energyFreeTime = 0;
                        }
                        break;

                    case 2:
                        if (energyFreeTime > 2500)
                        {
                            energy2.Visible = false;
                            energyCount--;
                            energyFreeTime = 0;
                        }
                        break;

                    case 1:
                        if (energyFreeTime > 2500)
                        {
                            energy1.Visible = false;
                            energyCount--;
                            energyFreeTime = 0;
                        }
                        break;
                }
                                       
            }
        }

        private void ufoFadingEffect()
        {
            if(ufo.Visible == true && energyFreeTime < 2500)
            {
                ufo.Visible = false;
            }

            else if (ufo.Visible == false && energyFreeTime < 2500)
            {
                ufo.Visible = true;
            }

            else
            {
                ufo.Visible = true;
            }
        }

        private void extraEnergyFunction()
        {
            if(energyCount < 3)
            {
                energyCount++;
                exEnergy.Left = 10000;
            }
        }

        private void CloseGame(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RestartGame()
        {
            gameOver = false;
            ufo.Location = new Point(12, 57);
            mountain_top.Left = 800;
            mountain_bottom.Left = 1200;
            gameScore = 0;
            mountainSpeed = 8;
            score_lbl.Text = "Score: 0";
            energyCount = 3;
            game_time.Start();
        }

        private void PauseMenu(object sender, EventArgs e)
        {
            Pause pause = new Pause(ID);
            pause.Show();
            this.Hide();
        }
    }
}
