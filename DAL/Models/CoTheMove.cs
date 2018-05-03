using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCaro.DAL.Models
{
    public class CoTheMove
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CoTheLevelId { get; set; }
        public string Point { get; set; }
        public CoTheLevel CoTheLevel { get; set; }

        public CoTheMove(string Point)
        {            
            this.Point = Point;            
        }
    }
}
