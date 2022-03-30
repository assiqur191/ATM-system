using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_System.Entities
{
    public class Transaction
    {
        public int TraxId { get; set; }
        public int AccountNo { get; set; }
        public string TransactionType { get; set; }
        public int TransactionAmount { get; set; }
        public Int64 Balance { get; set; }
        public string DateAndTime { get; set; }
    }
}
