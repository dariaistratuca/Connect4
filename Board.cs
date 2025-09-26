using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connect4
{
    internal class Board
    {
        private int boardWidth;
        private int boardHeigth;
        private int[,] mat;
        private int[] emptyCells;

        public Board(int x, int y)
        {
            mat = new int[y, x];
            emptyCells = new int[x];
            boardHeigth = y;
            boardWidth = x;
            for (int i = 0; i < boardWidth; i++)
                emptyCells[i] = boardHeigth - 1;
        }
        public Board()
        {
            boardHeigth = 6;
            boardWidth = 7;
            mat = new int[boardHeigth, boardWidth];
            emptyCells = new int[boardWidth];
            for (int i = 0; i < boardWidth; i++)
                for (int j = 0; j < boardHeigth; j++)
                    mat[i, j] = 0;  
            for (int i = 0; i < boardWidth; i++)
                emptyCells[i] = boardHeigth - 1;
        }



        public Color FourInARow()
        {
            Color winningColor = Color.Empty;
            for (int row = 0; row < boardHeigth; row++)
            {
                for (int col = 0; col < boardWidth; col++)
                {
                    if (mat[row, col] != 0)
                    {
                        // Check on horizontal
                        if (col + 3 < boardWidth &&
                            mat[row, col] == mat[row, col + 1] &&
                            mat[row, col] == mat[row, col + 2] &&
                            mat[row, col] == mat[row, col + 3])
                        {
                            winningColor = mat[row, col] == 1 ? Color.Red : Color.Black;
                            return winningColor;
                        }

                        // Check on vertical
                        if (row + 3 < boardHeigth &&
                            mat[row, col] == mat[row + 1, col] &&
                            mat[row, col] == mat[row + 2, col] &&
                            mat[row, col] == mat[row + 3, col])
                        {
                            winningColor = mat[row, col] == 1 ? Color.Red : Color.Black;
                            return winningColor;
                        }

                        // Check on main diagonal
                        if (row + 3 < boardHeigth && col + 3 < boardWidth &&
                            mat[row, col] == mat[row + 1, col + 1] &&
                            mat[row, col] == mat[row + 2, col + 2] &&
                            mat[row, col] == mat[row + 3, col + 3])
                        {
                            winningColor = mat[row, col] == 1 ? Color.Red : Color.Black;
                            return winningColor;
                        }

                        // Check secondary diagonal
                        if (row + 3 < boardHeigth && col - 3 >= 0 &&
                            mat[row, col] == mat[row + 1, col - 1] &&
                            mat[row, col] == mat[row + 2, col - 2] &&
                            mat[row, col] == mat[row + 3, col - 3])
                        {
                            winningColor = mat[row, col] == 1 ? Color.Red : Color.Black;
                            return winningColor;
                        }
                    }
                }
            }
            return winningColor;
        }


        public int GetValue(int x, int y)
        {
            return mat[y, x];
        }

        public void SetValue(int x, int y, int val)
        {
            mat[y, x] = val;
        }

        public int GetEmptyCells(int x)
        {
            return emptyCells[x];
        }

        public void SetEmptyCells(int x, int val)
        {
            if (x < boardWidth)
            {
                emptyCells[x] = val;
            }
        }
        public void ResetEmptyCells()
        {
            for (int i = 0; i < boardWidth; i++)
                emptyCells[i] = boardHeigth - 1;
        }
        public void ResetBoard()
        {
            for (int i = 0; i < boardWidth; i++)
                emptyCells[i] = boardHeigth;

            for (int i = 0; i < boardHeigth; i++)
                for (int j = 0; j < boardWidth; j++)
                    mat[i, j] = 0;

        }

        public bool IsBoardFull()
        {
            for (int col = 0; col < boardWidth; col++)
            {
                if (GetEmptyCells(col) >= 0)
                {
                    return false; 
                }
            }
            return true;
        }
    }
}
