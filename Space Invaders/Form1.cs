using Space_Invaders.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Invaders
{
    using Res = Space_Invaders.Properties.Resources;
    public partial class Form1 : Form
    {
        PictureBox[] stars;
        int backgroundspeed;
        Random rnd;

        Bitmap Shuttle;
        bool goLeft, goRight;
        int speed = 10;
        int positionX = 375;
        int positionY = 600;
        int height = 50;
        int width = 50;

        bool currentlyAnimating = false;
        bool shotTaken = false;

        
        int bulletSpeed = 20;
        int bulletWidth = 5;
        int bulletHeight = 10;
        List<Bullet> bullets = new List<Bullet>();
        Image bulletImage = Resources.Munition_Blue;//Setzt aus suche, codesuche, Resources.resx Projektil ein

        private int secSincePlay = 0;


        public Form1()
        {
            InitializeComponent();

            Shuttle = new Bitmap(Resources.Lvl1_Raumschiff_1);//Setzt aus suche, codesuche, Resources.resx shuttle ein


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundspeed = 4;
            stars = new PictureBox[15];
            rnd = new Random();

            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new PictureBox();
                stars[i].BorderStyle = BorderStyle.None;
                stars[i].Location = new Point(rnd.Next(20, 500), rnd.Next(-10, 400));
                if (i % 2 == 1)
                {
                    stars[i].Size = new Size(2, 2);
                    stars[i].BackColor = Color.Wheat;
                }
                else
                {
                    stars[i].Size = new Size(3, 3);
                    stars[i].BackColor = Color.DarkGray;
                }
                this.Controls.Add(stars[i]);
            }
        }

        private void MoveBgTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < stars.Length / 2; i++)
            {
                stars[i].Top += backgroundspeed;

                if (stars[i].Top >= this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }

            for (int i = stars.Length / 2; i < stars.Length; i++)
            {
                stars[i].Top += backgroundspeed - 2;

                if (stars[i].Top >= this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }



        }

        private void TimerEvent(object sender, EventArgs e)
        {
            if(goLeft && positionX > 4 )
            {
                positionX -= speed;
            }
            if (goRight && positionX + width < this.ClientSize.Width)
            {
                positionX += speed;
            }
            this.Invalidate();

            



            // Move and draw bullets
            foreach (Bullet bullet in bullets)
            {
                bullet.Move();
            }

            this.Invalidate(); // Trigger repaint
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            else if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }

            if (e.KeyCode == Keys.Space && !shotTaken) // Handle bullet creation
            {
                int bulletX = positionX + width / 2; // Adjust the starting position of the bullet
                int bulletY = positionY;
                Bullet newBullet = new Bullet(bulletX, bulletY, bulletSpeed, bulletWidth, bulletHeight, bulletImage);
                bullets.Add(newBullet);
                shotTaken = true;

            }

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            else if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }

            if (e.KeyCode == Keys.Space)
            {
                shotTaken = false;
            }

        }



        //Shuttel Animation
        private void FromPaintEvent(object sender, PaintEventArgs e)
        {
            AnimateImage();
            ImageAnimator.UpdateFrames();
            Graphics Canvas = e.Graphics;
            Canvas.DrawImage(Shuttle, positionX, positionY, width, height);

            Graphics canvas = e.Graphics;

            // Draw the shuttle
            canvas.DrawImage(Shuttle, positionX, positionY, width, height);

            // Draw bullets
            foreach (Bullet bullet in bullets)
            {
                bullet.Draw(canvas);
            }
        }
        public void AnimateImage()
        {
            if (!currentlyAnimating)
            {

                //Begin the animation only once.
                ImageAnimator.Animate(Shuttle, new EventHandler(this.OnFrameChanged));
                currentlyAnimating = true;
            }
        }

        private void countUp(object sender, EventArgs e)
        {
            secSincePlay++;
            timer.Text = "Zeit: " + Convert.ToString(secSincePlay);
        }

        private void OnFrameChanged(object o, EventArgs e)
        {

            //Force a call to the Paint event handler.
            this.Invalidate();
        }
    }
}