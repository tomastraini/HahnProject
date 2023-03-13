using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnProject.Infrastructure.PlainModels
{
    public class Person
    {
        public Int64 id { get; set; }
        public string business_name { get; set; }
        public decimal balance { get; set; }
        public DateTime creation_date { get; set; }
        public int person_type { get; set; }

        public PersonType PersonType { get; set; }
    }
}
