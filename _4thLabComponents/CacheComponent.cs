using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4thLabComponents
{
    public partial class CacheComponent<T> : Component where T : ICloneable
    {
        private List<T> elements;

        /// <summary>
        /// Свойство, позволяющее работать с кэшем.
        /// get - возвращает список элементов, являющихся копиями сохранённых элементов
        /// set - сохраняет список из элементов, являющихся копиями элементов списка, поданного на вход
        /// </summary>
        public List<T> Elements
        {
            get
            {
                List<T> list = new List<T>();
                foreach (T item in elements)
                {
                    list.Add((T)item.Clone());
                }
                return list;
            }
            set
            {
                elements.Clear();
                foreach (T item in value)
                {
                    elements.Add((T)item.Clone());
                }
            }
        }

        public CacheComponent()
        {
            InitializeComponent();
            elements = new List<T>();
        }

        public CacheComponent(IContainer container) : this()
        {
            container.Add(this);
        }
    }
}
