using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCaro.Model
{
    public class User
    {
        private int iDUsers;
        private string name;
        private string tittle;

        public string Tittle { get => tittle; set => tittle = value; }
        public string Name { get => name; set => name = value; }
        public int IDUsers { get => iDUsers; set => iDUsers = value; }
    }
}
