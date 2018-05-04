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
        public int Owner { get; set; }
        public bool IsInit { get; set; } = false;

        public Chess()
        {

        }

        public Chess(int column, int row, int owner)
        {
            this.Column = column;
            this.Row = row;           
            this.Owner = owner;
        }

        public Chess(int column, int row, int owner, bool isInit)
        {
            this.Column = column;
            this.Row = row;            
            this.Owner = owner;
            this.IsInit = isInit;
        }
    }
}
