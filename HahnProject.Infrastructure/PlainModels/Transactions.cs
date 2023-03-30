using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnProject.Infrastructure.PlainModels
{
    public class Transactions
    {
        public long id { get; set; }
        public long person { get; set; }
        public DateTime transaction_began { get; set; }
        public decimal total { get; set; }
        public List<SubTransactions> SubTransactions { get; set; }
    }
}
