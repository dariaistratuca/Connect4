using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Connect4
{
    class Game
    {
        private int BoardWidth, BoardHeight;
        private Player player1;
        private Player player2;
        private Board board;

        //Constructor for the game
        public Game()
        {
            BoardWidth = 700;
            BoardHeight = 600;
            board = new Board(7, 6);
            player1 = new Player(Color.Red);
            player2 = new Player(Color.Black);
            player1.SetTurn(true);
        }



        //Method for reseting the game
        public void Reset()
        {
            player1.SetTurn(true);
            player2.SetTurn(false);
            board.ResetBoard();
            board.ResetEmptyCells();
        }

        //Method that changes the players turn
        private void PlayerTurn()
        {
            player1.SetTurn(!player1.PlayerTurn);
            player2.SetTurn(!player2.PlayerTurn);
        }

        public void DrawBoard(PaintEventArgs e)
        {
            Pen line = new Pen(Color.Black);
            int lineXi = 0, lineXf = BoardWidth;
            int lineYi = 0, lineYf = BoardHeight;
            SolidBrush myBrush = new SolidBrush(Color.White);

            int circleSize = 80;
            int spacing = (100 - circleSize) / 2;

            for (int startY = 0; startY <= BoardWidth; startY += 100)
            {
                e.Graphics.DrawLine(line, startY, lineYi, startY, lineYf);
            }

            for (int startX = 0; startX <= BoardHeight; startX += 100)
            {
                e.Graphics.DrawLine(line, lineXi, startX, lineXf, startX);
            }

            for (int y = 0; y <= BoardHeight; y += 100)
            {
                for (int x = 0; x <= BoardWidth; x += 100)
                {
                    int circleX = x + spacing;
                    int circleY = y + spacing;
                    e.Graphics.FillEllipse(myBrush, new Rectangle(circleX, circleY, circleSize, circleSize));
                }
            }
        }


        public void DrawGamePiece(MouseEventArgs e, Graphics f, bool currentPlayerTurn)
        {
            Player currentPlayer = currentPlayerTurn ? player1 : player2;
            SolidBrush myBrush = new SolidBrush(currentPlayer.PieceColor);

            int circleDiameter = 80;

            int xlocal = e.X / 100;
            int emptyCells = board.GetEmptyCells(xlocal);
            if (emptyCells >= 0)
            {
                if (currentPlayer.PlayerTurn && board.GetValue(xlocal, emptyCells) == 0)
                {
                    int circleX = xlocal * 100 + (100 - circleDiameter) / 2; 
                    int circleY = emptyCells * 100 + (100 - circleDiameter) / 2;
                    board.SetValue(xlocal, emptyCells, currentPlayerTurn ? 1 : 2);
                    f.FillEllipse(myBrush, circleX, circleY, circleDiameter, circleDiameter);
                    board.SetEmptyCells(xlocal, emptyCells - 1);
                    PlayerTurn();
                }
            }
        }


        public Color WinningPlayer()
        {
            return board.FourInARow();
        }

        public bool GetPlayer1Turn()
        {
            return player1.PlayerTurn;
        }

        public bool IsBoardFull()
        {
            return board.IsBoardFull();
        }

    }
}
