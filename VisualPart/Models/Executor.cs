using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmetaCreator.Models
{
    internal class Executor
    {
        public string? Name { get; set; }
        public List<Work> Works { get; set; }

        public Executor(string name)
        {
            Name = name;
            Works = new List<Work>();
        }
    }
}
