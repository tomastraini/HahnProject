using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnProject.Infrastructure.PlainModels
{
    public class Products
    {
        public long id { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public decimal stock { get; set; }
        public long supplier_id { get; set; }
        public Person supplier { get; set; }
    }
}
