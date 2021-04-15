//  -------------------------------------------------------------------------
//  <copyright file="Form1.cs"  author="Rajesh Thomas | iamrajthomas" >
//      Copyright (c) 2021 All Rights Reserved.
//  </copyright>
// 
//  <summary>
//       Form for Car Race and All Code Behind Goes Here
//  </summary>
//  -------------------------------------------------------------------------

namespace CarRacingGame
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class form_CarRacing : Form
    {
        public int GameSpeed = 5;
        public int GameScore = 0;
        public bool IsMyGameOver = false;
        public bool IsMyGamePaused = false; 
        private Random _random = new Random();

        public form_CarRacing()
        {
            InitializeComponent();

            InitizalizeGameData();
        }

        public void InitizalizeGameData()
        {
            lbl_GameOver.Visible = false;
            lbl_GameDescription.Visible = false;
            btn_Exit.Visible = false;
            btn_PlayAgain.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (!IsMyGameOver && !IsMyGamePaused)
            {
                MoveTheLine(GameSpeed);
                MoveEnemy(GameSpeed);
                MoveCoin(GameSpeed);
                IsGameOver();
                CollectGoldCoins();
            }
        }

        private void MoveTheLine(int Velocity)
        {
            pictureBox1.Top = pictureBox1.Top < 580 ? pictureBox1.Top + Velocity : 0;
            pictureBox2.Top = pictureBox2.Top < 580 ? pictureBox2.Top + Velocity : 0;
            pictureBox3.Top = pictureBox3.Top < 580 ? pictureBox3.Top + Velocity : 0;
            pictureBox4.Top = pictureBox4.Top < 580 ? pictureBox4.Top + Velocity : 0;
        }
        
        private void MoveEnemy(int Velocity)
        {
            if(img_Enemy1.Top >= 600)
            {
                img_Enemy1.Location = new Point(_random.Next(10, 250), 0);
            }
            else
            {
                img_Enemy1.Top += Velocity;
            }

            if (img_Enemy2.Top >= 600)
            {
                img_Enemy2.Location = new Point(_random.Next(40, 250), 0);
            }
            else
            {
                img_Enemy2.Top += Velocity;
            }

            if (img_Enemy3.Top >= 600)
            {
                img_Enemy3.Location = new Point(_random.Next(70, 250), 0);
            }
            else
            {
                img_Enemy3.Top += Velocity;
            }
        }

        private void MoveCoin(int Velocity)
        {
            if (Coin1.Top >= 600)
            {
                Coin1.Location = new Point(_random.Next(10, 250), 0);
            }
            else
            {
                Coin1.Top += Velocity;
            }

            if (Coin2.Top >= 600)
            {
                Coin2.Location = new Point(_random.Next(10, 250), 0);
            }
            else
            {
                Coin2.Top += Velocity;
            }

            if (Coin3.Top >= 600)
            {
                Coin3.Location = new Point(_random.Next(10, 250), 0);
            }
            else
            {
                Coin3.Top += Velocity;
            }

            if (BitCoin.Top >= 600)
            {
                BitCoin.Location = new Point(_random.Next(10, 250), 0);
            }
            else
            {
                BitCoin.Top += Velocity;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!IsMyGameOver && !IsMyGamePaused)
            {
                //To Pause/Play The Game
                if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
                {
                    IsMyGamePaused = !IsMyGamePaused;
                    timer_GameTimer.Enabled = !timer_GameTimer.Enabled;
                }

                //To Move The Car To Left Side
                if (e.KeyCode == Keys.Left)
                {
                    if (img_RacingCar.Left > 15)
                        img_RacingCar.Left += -10;
                }

                //To Move The Car To Right Side
                if (e.KeyCode == Keys.Right)
                {
                    if (img_RacingCar.Right < 270)
                        img_RacingCar.Left += 10;
                }

                //To Speed-up the Game Speed
                if (e.KeyCode == Keys.Up)
                {
                    if (GameSpeed < 20 && GameSpeed < 100)
                    {
                        GameSpeed++;
                    }
                }

                //To Slow-down the Game Speed
                if (e.KeyCode == Keys.Down)
                {
                    if (GameSpeed > 0)
                    {
                        GameSpeed--;
                    }
                }
            }
        }

        private void IsGameOver()
        {
            if (img_RacingCar.Bounds.IntersectsWith(img_Enemy1.Bounds) ||
                img_RacingCar.Bounds.IntersectsWith(img_Enemy2.Bounds) ||
                img_RacingCar.Bounds.IntersectsWith(img_Enemy3.Bounds))
            {
                lbl_GameOver.Visible = true;
                lbl_GameDescription.Visible = true;
                IsMyGameOver = true;
                timer_GameTimer.Enabled = false;

                btn_Exit.Visible = true;
                btn_PlayAgain.Visible = true;
            }

        }

        private void CollectGoldCoins()
        {
            //For Car Hits Coins
            if (img_RacingCar.Bounds.IntersectsWith(Coin1.Bounds))
            {
                GameScore += 1;
                Coin1.Visible = false;
                Coin1.Location = new Point(_random.Next(10, 250), 0);
            }

            if (img_RacingCar.Bounds.IntersectsWith(Coin2.Bounds))
            {
                GameScore += 1;
                Coin2.Visible = false;
                Coin2.Location = new Point(_random.Next(10, 250), 0);
            }

            if (img_RacingCar.Bounds.IntersectsWith(Coin3.Bounds))
            {
                GameScore += 1;
                Coin3.Visible = false;
                Coin3.Location = new Point(_random.Next(10, 250), 0);
            }

            if (img_RacingCar.Bounds.IntersectsWith(BitCoin.Bounds))
            {
                GameScore += 3;
                BitCoin.Visible = false;
                BitCoin.Location = new Point(_random.Next(10, 250), 0);
            }

            //For Enemy 1 Hits Coins
            if (img_Enemy1.Bounds.IntersectsWith(Coin1.Bounds))
            {
                GameScore += 1;
                Coin1.Visible = false;
                Coin1.Location = new Point(_random.Next(10, 250), 0);
            }

            if (img_Enemy1.Bounds.IntersectsWith(Coin2.Bounds))
            {
                GameScore += 1;
                Coin2.Visible = false;
                Coin2.Location = new Point(_random.Next(10, 250), 0);
            }

            if (img_Enemy1.Bounds.IntersectsWith(Coin3.Bounds))
            {
                GameScore += 1;
                Coin3.Visible = false;
                Coin3.Location = new Point(_random.Next(10, 250), 0);
            }

            if (img_Enemy1.Bounds.IntersectsWith(BitCoin.Bounds))
            {
                GameScore += 3;
                BitCoin.Visible = false;
                BitCoin.Location = new Point(_random.Next(10, 250), 0);
            }

            //For Enemy 2 Hits Coins
            if (img_Enemy2.Bounds.IntersectsWith(Coin1.Bounds))
            {
                GameScore += 1;
                Coin1.Visible = false;
                Coin1.Location = new Point(_random.Next(10, 250), 0);
            }

            if (img_Enemy2.Bounds.IntersectsWith(Coin2.Bounds))
            {
                GameScore += 1;
                Coin2.Visible = false;
                Coin2.Location = new Point(_random.Next(10, 250), 0);
            }

            if (img_Enemy2.Bounds.IntersectsWith(Coin3.Bounds))
            {
                GameScore += 1;
                Coin3.Visible = false;
                Coin3.Location = new Point(_random.Next(10, 250), 0);
            }

            if (img_Enemy2.Bounds.IntersectsWith(BitCoin.Bounds))
            {
                GameScore += 3;
                BitCoin.Visible = false;
                BitCoin.Location = new Point(_random.Next(10, 250), 0);
            }

            //For Enemy 3 Hits Coins
            if (img_Enemy3.Bounds.IntersectsWith(Coin1.Bounds))
            {
                GameScore += 1;
                Coin1.Visible = false;
                Coin1.Location = new Point(_random.Next(10, 250), 0);
            }

            if (img_Enemy3.Bounds.IntersectsWith(Coin2.Bounds))
            {
                GameScore += 1;
                Coin2.Visible = false;
                Coin2.Location = new Point(_random.Next(10, 250), 0);
            }

            if (img_Enemy3.Bounds.IntersectsWith(Coin3.Bounds))
            {
                GameScore += 1;
                Coin3.Visible = false;
                Coin3.Location = new Point(_random.Next(10, 250), 0);
            }

            if (img_Enemy3.Bounds.IntersectsWith(BitCoin.Bounds))
            {
                GameScore += 3;
                BitCoin.Visible = false;
                BitCoin.Location = new Point(_random.Next(10, 250), 0);
            }

            lbl_CoinCount.Text = String.Format("Coins: {0}", GameScore);
        }

        private void btn_PlayAgain_Click(object sender, EventArgs e)
        {
            if (IsMyGameOver)
            {
                Application.Restart();
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
