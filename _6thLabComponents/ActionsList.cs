using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace _6thLabComponents
{
    public partial class ActionsList : Component
    {
        private List<Memento> list;
        private int index;

        public bool CanPrev { get { return index > 0; } }
        public bool CanNext { get { return index < list.Count - 1; } }

        public ActionsList()
        {
            InitializeComponent();

            list = new List<Memento>();
            index = -1;
        }

        public ActionsList(IContainer container) : this()
        {
            container.Add(this);
        }

        public void Add(Memento memento)
        {
            if (index < list.Count - 1)
            {
                for (int i = list.Count - 1; i > index; i--)
                {
                    list.Remove(list[i]);
                }
            }

            list.Add(memento);
            index++;
        }

        public Memento Prev()
        {
            if (index > 0)
            {
                index--;
                return list[index];
            }

            throw new IndexOutOfRangeException();
        }

        public Memento Next()
        {
            if (index < list.Count - 1)
            {
                index++;
                return list[index];
            }

            throw new IndexOutOfRangeException();
        }
    }
}
