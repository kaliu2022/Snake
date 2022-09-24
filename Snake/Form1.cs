using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{

    public partial class Form1 : Form
    {
        Game game = new Game();
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Ethan Nguyen");
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            game.Draw(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            game.Update();
            pictureBox1.Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                game.GoLeft();
            }
            else if (e.KeyCode == Keys.Right)
            {
                game.GoRight();
            }
            else if (e.KeyCode == Keys.Up)
            {
                game.GoUp();
            }
            else if (e.KeyCode == Keys.Down)
            {
                game.GoDown();
            }
            else if (e.KeyCode == Keys.Space)
            {
                game.Reset();
            }
        }
    }
}
