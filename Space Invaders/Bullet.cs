using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    public class Bullet
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Speed { get; }
        public int Width { get; }
        public int Height { get; }
        public Image BulletImage { get; }

        public Bullet(int x, int y, int speed, int width, int height, Image image)
        {
            X = x;
            Y = y;
            Speed = speed;
            Width = width;
            Height = height;
            BulletImage = image;
        }

        public void Move()
        {
            Y -= Speed;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(BulletImage, X, Y, Width, Height);
        }
    }
}
