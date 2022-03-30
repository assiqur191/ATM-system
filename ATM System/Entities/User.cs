using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_System.Entities
{
    public class User
    {
        public int NoOfUser { get; set; }
        public int AccountNo { get; set; }
        public string Name { get; set; }
        public int Mobile { get; set; }
        public string Address { get; set; }
        public int Pin { get; set; }
        public string Birthday { get; set; }
        public Int64 Balance { get; set; }
    }
}
