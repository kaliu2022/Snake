using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    class Snake
    {
        int x;
        int y;
        const int SEGMENT_SIZE = 32;

        const int UP = 0;
        const int DOWN = 1;
        const int LEFT = 2;
        const int RIGHT = 3;

        int direction = RIGHT;
        int length = 3;
        Image segmentImage = global::Snake.Properties.Resources.segment;

        List<Point> segments = new List<Point>();

        public Snake()
        {
            Reset();
        }

        public int GetX() { return x; }
        public int GetY() { return y; }

        public void Reset()
        {
            x = 300;
            y = 200;
            segments.Clear();
            direction = RIGHT;
        }

        public void Draw(Graphics g)
        {
            foreach (Point p in segments)
            {
                g.DrawImage(segmentImage, p.X - segmentImage.Width / 2, p.Y - segmentImage.Height / 2);
            }

        }

        public void Grow()
        {
            length++;
        }

        public void Update()
        {
            Move();

            Point p = new Point(x, y); //make a new point where we are

            segments.Insert(0, p); //add to front of list

            if (segments.Count > length)
            {
                segments.RemoveAt(segments.Count - 1);
            }
        }

        private void Move()
        {
            if (direction == UP)
            {
                y -= SEGMENT_SIZE;
            }
            else if (direction == DOWN)
            {
                y += SEGMENT_SIZE;
            }
            else if (direction == LEFT)
            {
                x -= SEGMENT_SIZE;
            }
            else if (direction == RIGHT)
            {
                x += SEGMENT_SIZE;
            }
        }

        public void GoUp()
        {
            if (direction != DOWN)
            {
                direction = UP;
            }
        }

        public void GoDown()
        {
            if (direction != UP)
            {
                direction = DOWN;
            }
        }

        public void GoLeft()
        {
            if (direction != RIGHT)
            {
                direction = LEFT;
            }
        }

        public void GoRight()
        {
            if (direction != LEFT)
            {
                direction = RIGHT;
            }
        }

        public bool HitSelf()
        {
            for (int i = 1; i < segments.Count; i++)
            {
                if (segments[i] == segments[0])
                {
                    return true;
                }
            }

            return false;
        }

        public Rectangle GetBounds()
        {
            return new Rectangle(x - SEGMENT_SIZE / 2, y - SEGMENT_SIZE / 2, SEGMENT_SIZE, SEGMENT_SIZE);

        }

    }
}
