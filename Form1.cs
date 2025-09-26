//===================================================
// Tyler Sriver
// Connect 4 Game - Form Class
// October 31, 2014
//===================================================
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Connect4
{
    public partial class Form1 : Form
    {
        //instance of Game
        Game game1 = new Game();
        //List of Games to save and redraw with
        

        //constructor of the Form
        public Form1()
        {
            InitializeComponent();
            lblTurn.ForeColor = Color.Red;
            lblTurn.Text = "Player 1's Turn";
        }

        //Method to handle painting of the form
        //handles repainting
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            game1.DrawBoard(e);
        }

        //Method to handle mouse click in the panel
        //handles drawing the cells, and checking win
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            using (Graphics f = this.panel1.CreateGraphics())
            {
                game1.DrawGamePiece(e, f, game1.GetPlayer1Turn());
                if(game1.GetPlayer1Turn())
                {
                    lblTurn.ForeColor = Color.Red;
                    lblTurn.Text = "Player 1's Turn";
                }
                else
                {
                    lblTurn.ForeColor = Color.Black;
                    lblTurn.Text = "Player 2's Turn";
                }
                
            }

            if (game1.WinningPlayer() == Color.Red)
            {
                MessageBox.Show("Red Player Wins", "Red Beat Black", MessageBoxButtons.OK);
                game1.Reset();
                panel1.Invalidate();
            }
            else if (game1.WinningPlayer() == Color.Black)
            {
                MessageBox.Show("Black Player Wins", "Black Beat Red", MessageBoxButtons.OK);
                game1.Reset();
                panel1.Invalidate();
            }
            else if(game1.IsBoardFull())
            {
                MessageBox.Show("The game is a draw", "Draw", MessageBoxButtons.OK);
                game1.Reset();
                panel1.Invalidate();
            }
            
        }

        //Method for reset button, resets game when clicked
        private void btnReset_MouseClick(object sender, MouseEventArgs e)
        {
            DialogResult result;

            result = MessageBox.Show("Are you sure you want to reset?", "Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                panel1.Invalidate();
                lblTurn.ForeColor = Color.Red;
                lblTurn.Text = "Player 1's Turn";
                game1.Reset();
            }
        }     
        
    }
}
