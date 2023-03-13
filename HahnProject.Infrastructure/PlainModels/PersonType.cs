using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnProject.Infrastructure.PlainModels
{
    public class PersonType
    {
        public int id { get; set; }
        public string type { get; set; }
        public List<Person> people { get; set;}
    }
}
