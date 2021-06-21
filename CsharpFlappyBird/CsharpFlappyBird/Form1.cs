using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsharpFlappyBird
{
    public partial class Form1 : Form
    {
        int speed = 8;
        int gravity = 5;
        int score = 0;



        public Form1()
        {
            InitializeComponent();
        }  

        private void myTimer_Tick(object sender, EventArgs e)
        {
            //The game timer event//link fla
            bird.Top += gravity;
            //now moving the pipe ..what is going to pull from the end of the screen to the other end 
            pipeBottom.Left -= speed;
            pipeTop.Left -= speed;
            scoreText.Text = "score:" + score;
            //find a way to bring the pipes back once they have passed
            if (pipeBottom.Left< -150)
            {
                pipeBottom.Left = 1200;
                score++;
                scoreText.Text = score.ToString();// will convert score integer to string
            }
            if (pipeTop.Left< -180)
            {
                pipeTop.Left = 1250;
                score++;
            }
            if (bird.Bounds.IntersectsWith(pipeBottom.Bounds) || bird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                bird.Bounds.IntersectsWith(ground.Bounds) || bird.Top < -25// bounds are the borders
                )
            {
                endGame();
            }
            //increase the speed after 5 successful points 
            if (score >5)
            {
                speed = 15;
            }
            //stop from cheating--2nd alternative
            //if (bird.Top<-25)
            //{
            //    endGame();
            //}
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Space)
            {
                gravity = -5;

            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 5;

            }
        }
         private void endGame()
        {
            ///game will end when you hit any of the pipes
            myTimer.Stop();
            scoreText.Text += "Oops! Game over! ";
        }
       
    }
}
