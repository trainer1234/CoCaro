using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCaro.Model
{
    public class ChessBoard
    {
        public static int ChessSize { get; } = 35;
        public static int BoardRows { get; } = 20;
        public static int BoardColumns { get; } = 20;
        public static int BoardPaddingLeft { get; } = 80;
        public static int BoardPaddingTop { get; } = 150;
        public int Id { get; set; }
        public Chess[,] Chesses { get; set; }
        public int NumberOfMove { get; set; }
        public int TurnOwner { get; set; }
        public bool IsEnd { get; set; }    
        public int MoveTime { get; set; }
        public List<string> Moves { get; set; }
        public int GameDuration { get; set; }
        public DateTime StartTime { get; set; }
        public int Winer { get; set; }
        public ChessBoard()
        {
            Chesses = new Chess[BoardRows + 1, BoardColumns + 1];
            NumberOfMove = 0;
            TurnOwner = 1;
            IsEnd = false;
            MoveTime = 20;
            Moves = new List<string>();
            StartTime = new DateTime();
            Winer = 0;
        }

        public ChessBoard(int id) : this()
        {
            this.Id = id;
        }
    }
}
