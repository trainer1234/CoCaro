using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCaro.DAL.Models
{
    public class Game
    {
        public int Id { get; set; }
        public int Winner { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }

        public List<Move> Moves { get; set; }
    }
}
