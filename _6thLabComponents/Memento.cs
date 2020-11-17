using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6thLabComponents
{
    public class Memento
    {
        private object obj;
        public object Obj { get { return obj; } }

        public Memento(object obj)
        {
            this.obj = obj;
        }
    }
}
