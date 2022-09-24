using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Media;

namespace Snake
{
    class Game
    {
        bool gameOver = false;
        Snake snake = new Snake();
        flower flower = new flower(25, 25, global::Snake.Properties.Resources.flower);
        SoundPlayer chompSnd = new SoundPlayer(Properties.Resources.sound_chomp);
        SoundPlayer splatSnd = new SoundPlayer(Properties.Resources.sound_splat);

        public Game()
        {
            gameOver = false;
        }

        public void Reset()
        {
            if (gameOver)
            {
                snake.Reset();
                flower.Reposition();
                gameOver = false;
            }

        }

        public void GoUp()
        {
            snake.GoUp();
        }

        public void GoDown()
        {
            snake.GoDown();
        }

        public void GoLeft()
        {
            snake.GoLeft();
        }

        public void GoRight()
        {
            snake.GoRight();
        }

        public void Update()
        {
            if (!gameOver)
            {
                snake.Update();

                //did it hit the flower?
                if (SnakeTouchingFlower())
                {
                    chompSnd.Play();
                    snake.Grow();
                    flower.Reposition();
                }

                //did it hit the wall?
                if (snake.GetX() < 0 || snake.GetX() > 600 ||
                    snake.GetY() < 0 || snake.GetY() > 400)
                {
                    splatSnd.Play();
                    gameOver = true;
                }

                if (snake.HitSelf())
                {
                    splatSnd.Play();
                    gameOver = true;
                }

            }
        }

        public void Draw(Graphics g)
        {
            g.Clear(Color.Green);
            flower.Draw(g);
            snake.Draw(g);
        }

        private bool SnakeTouchingFlower()
        {
            return snake.GetBounds().IntersectsWith(flower.GetBounds());
        }
    }
}
