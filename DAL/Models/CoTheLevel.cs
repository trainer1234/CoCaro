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
    }
}
