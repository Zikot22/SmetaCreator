using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmetaCreator.Models
{
    internal class Smeta
    {
        private string? ExecutorName { get; set; }
        private string? Customer { get; set; }
        private string? Adress { get; set; }
        private List<Work> Works { get; set; }
        public Smeta(Executor executor, string customer, string adress, List<Work> works)
        {
            ExecutorName = executor.Name;
            Customer = customer;
            Adress = adress;
            Works = works;
        }
    }
}
