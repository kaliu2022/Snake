using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{

    class flower
    {
        int x;
        int y;
        Random r = new Random();
        Image flowerImage;

        public flower(int x, int y, Image img)
        {
            this.x = x;
            this.y = y;
            flowerImage = img;
        }

        public void Reposition()
        {
            x = r.Next(10, 600);
            y = r.Next(10, 400);
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(flowerImage, x - flowerImage.Width/2, y - flowerImage.Height/2);
        }

        public Rectangle GetBounds()
        {
            return new Rectangle(x - flowerImage.Width / 2, y - flowerImage.Height / 2,
            flowerImage.Width, flowerImage.Height);
        }
    }

}
