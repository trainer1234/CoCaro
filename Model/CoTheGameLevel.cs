using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCaro.Model
{
    public class CoTheGameLevel
    {
        public int Id { get; set; }
        public List<string> Moves { get; set; }
        public int LimitedMoves { get; set; }    
        public CoTheGameLevel()
        {
            this.Id = 0;
            this.Moves = new List<string>();
            this.LimitedMoves = 0;
        }
        public CoTheGameLevel(int Id, List<string> Moves, int LimitedMoves):this()
        {
            this.Id = Id;
            this.Moves = Moves;
            this.LimitedMoves = LimitedMoves;
        }

        public int GetTurnOwner()
        {
            if (Moves.Count % 2 == 0)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
    }
}
