using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnProject.Infrastructure.PlainModels
{
    public class SubTransactions
    {
        public long id { get; set; }
        public long transaction_id { get; set; }
        public long product_id { get; set; }
        public decimal amount { get; set; }
        public decimal total { get; set; }
        public Transactions Transactions { get; set; }
    }
}
