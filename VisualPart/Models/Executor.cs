using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmetaCreator.Models
{
    internal class Executor
    {
        public string? Name { get; private set; }
        public List<Work> Works { get; private set; }

        public Executor(string name)
        {
            Name = name;
            Works = new List<Work>();
        }

        private void AddWork(Work work)
        {
            Works.Add(work);
        }

        private void DeleteWord(Work work)
        {
            Works.Remove(work);
        }
    }
}
