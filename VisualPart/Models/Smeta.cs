using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmetaCreator.Models
{
    internal class Smeta
    {
        public string? ExecutorName { get; set; }
        public string? Customer { get; set; }
        public string? Adress { get; set; }
        public List<Work> Works { get; set; }
        public Smeta(Executor executor, string customer, string adress, List<Work> works)
        {
            ExecutorName = executor.Name;
            Customer = customer;
            Adress = adress;
            Works = works;
        }
    }
}
 