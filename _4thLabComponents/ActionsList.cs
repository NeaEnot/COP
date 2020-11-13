using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace _4thLabComponents
{
    public partial class ActionsList : Component
    {
        private ICloneable before;

        private List<(ICloneable before, ICloneable after)> list;
        private int index;

        public bool CanPrev { get { return index > -1; } }
        public bool CanNext { get { return index < list.Count - 1; } }

        public ActionsList()
        {
            InitializeComponent();

            list = new List<(ICloneable before, ICloneable after)>();
            index = -1;
        }

        public ActionsList(IContainer container)
        {
            container.Add(this);
            InitializeComponent();

            list = new List<(ICloneable before, ICloneable after)>();
            index = -1;
        }

        public void AddBefore(ICloneable b)
        {
            before = (ICloneable)(b == null ? null : b.Clone());
        }

        public void AddAfter(ICloneable after)
        {
            if (index < list.Count - 1)
            {
                for (int i = list.Count - 1; i > index; i--)
                {
                    list.Remove(list[i]);
                }
            }

            list.Add(((ICloneable before, ICloneable after))(before, after == null ? null : after.Clone()));
            index++;
        }

        /*public void Add(ICloneable before, ICloneable after)
        {
            if (index < list.Count - 1)
            {
                for (int i = list.Count - 1; i > index; i++)
                {
                    list.Remove(list[i]);
                }
            }

            list.Add(((ICloneable before, ICloneable after))(before == null ? null : before.Clone(), after == null ? null : after.Clone()));
            index++;
        }*/

        public (ICloneable before, ICloneable after) Prev()
        {
            if (index > -1)
            {
                var item = list[index];
                index--;
                return item;
            }

            throw new IndexOutOfRangeException();
        }

        public (ICloneable before, ICloneable after) Next()
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
