using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCaro.DAL.Models
{
    public class CoTheLevel
    {      
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int LimitedMove { get; set; }

        public List<CoTheMove> CoTheMoves { get; set; }

        public CoTheLevel(int id, List<CoTheMove> moves, int limitedMove)
        {
            this.Id = id;
            this.CoTheMoves = moves;
            this.LimitedMove = limitedMove;
        }

        public int GetTurnOwner()
        {
            if(CoTheMoves.Count % 2 == 0)
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
