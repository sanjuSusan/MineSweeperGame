using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeperGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Aim is to click 10 green boxes and you have 3 lifes", "Game Rule", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                Random rnd = new Random();
                int mine1 = rnd.Next(1, 12);
                int mine2 = rnd.Next(2, 4);
                int mine3 = rnd.Next(9, 13);
                int mine4 = rnd.Next(13, 18);
                int mine5 = rnd.Next(19, 25);
                int mine6 = rnd.Next(12, 20);
                int mine7 = rnd.Next(6, 15);

                for (int i = 1; i <= 25; i++)
                {
                    Button btnTemp = new Button();

                    btnTemp.Name = "btnTemp" + i.ToString();
                    btnTemp.Size = new System.Drawing.Size(40, 40);
                    btnTemp.Text = "$$";
                    btnTemp.UseVisualStyleBackColor = true;

                    if (mine1 == i || mine2 == i || mine3 == i || mine4 == i || mine5 == i || mine6 == i || mine7 == i)
                        btnTemp.Tag = true;
                    else
                        btnTemp.Tag = false;

                    btnTemp.Click += BtnTemp_Click;
                    flowLayoutPanel1.Controls.Add(btnTemp);
                }
            }
            else
                Close();
        }



        private void BtnTemp_Click(object sender, EventArgs e)
        {
            Button btnTemp = (Button)sender;
            bool tag = (bool)btnTemp.Tag;
            int life = int.Parse(lblLife.Text);
            int score = int.Parse(lblScore.Text);

            if (tag)
            {
                btnTemp.BackColor = Color.Red;
                life--;
                LostGame(life, score);

            }
            else
            {
                GoToNextMove(score, life);
                btnTemp.BackColor = Color.Green;

            }

        }

        public void LostGame(int life, int score)
        {

            if (life == 0)
            {
                DialogResult result = MessageBox.Show("Boom !!! You are lost\nRestart ?", "Game Result", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                if (result == DialogResult.Yes)
                    Application.Restart();
                else
                    Close();
            }
            else
            {
                score--;
                GoToNextMove(score, life);
            }
        }

        public void GoToNextMove(int score, int life)
        {
            score++;
            if (score >= 10)
            {
                DialogResult result = MessageBox.Show("Congrats!! You won the Game", "Game Result", MessageBoxButtons.YesNo, MessageBoxIcon.None);
                if (result == DialogResult.Yes)
                    Application.Restart();
                else
                    Close();
            }
            lblScore.Text = score.ToString();
            lblLife.Text = life.ToString();

        }
    }
}
