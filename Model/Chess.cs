using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCaro.Model
{
    public class Chess
    {
        public int Column { get; set; }
        public int Row { get; set; }
        public Point Location { get; set; }
        public int Owner { get; set; }

        public Chess()
        {

        }

        public Chess(int column, int row, Point location, int owner)
        {
            this.Column = column;
            this.Row = row;
            this.Location = location;
            this.Owner = owner;
        }
    }
}
