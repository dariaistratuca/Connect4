using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    public class Player
    {
        public Color PieceColor { get; set; }
        public bool PlayerTurn { get; set; }

        public Player(Color color)
        {
            PieceColor = color;
            PlayerTurn = false;
        }

        public void SetTurn(bool playerTurn)
        {
            this.PlayerTurn = playerTurn;
        }
    }
}
