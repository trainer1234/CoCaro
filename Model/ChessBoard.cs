using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCaro.Model
{
    class ChessBoard
    {
        public int ChessSize { get; } = 35;
        public int BoardRows { get; } = 20;
        public int BoardColumns { get; } = 20;
        public int BoardPaddingLeft { get; } = 80;
        public int BoardPaddingTop { get; } = 150;
        public Chess[,] Chesses { get; set; }
        public int NumberOfMove { get; set; }
        public int TurnOwner { get; set; }
        public bool IsEnd { get; set; }    
        public int MoveTime { get; set; }

        public ChessBoard()
        {
            Chesses = new Chess[BoardRows + 1, BoardColumns + 1];
            NumberOfMove = 0;
            TurnOwner = 1;
            IsEnd = false;
            MoveTime = 20;
        }
    }
}
