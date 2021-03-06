﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.ComboBox;

namespace _1sLabComponents
{
    public partial class ComboBoxKozlov : UserControl
    {
        /// <summary>
        /// Событие выбора элемента из списка
        /// </summary>
        private event EventHandler comboBoxSelectedElementChange;

        /// <summary>
        /// Элементы контрола
        /// </summary>
        [Category("Спецификация"), Description("Элементы контрола")]
        public ObjectCollection Items
        {
            get
            {
                return comboBox.Items;
            }
        }

        /// <summary>
        /// Порядковый номер выбранного элемента
        /// </summary>
        [Category("Спецификация"), Description("Порядковый номер выбранного элемента")]
        public int SelectedIndex
        {
            get { return comboBox.SelectedIndex; }
            set
            {
                if (value > -2 && value < comboBox.Items.Count)
                {
                    comboBox.SelectedIndex = value;
                }
            }
        }

        /// <summary>
        /// Текст выбранной записи
        /// </summary>
        [Category("Спецификация"), Description("Текст выбранной записи")]
        public string SelectedText
        {
            get 
            { 
                return comboBox.Text;
            }
            set
            {
                try
                {
                    comboBox.Items[SelectedIndex] = value;
                }
                catch { }
            }
        }

        /// <summary>
        /// Событие выбора элемента из списка
        /// </summary>
        [Category("Спецификация"), Description("Событие выбора элемента из списка")]
        public event EventHandler ComboBoxSelectedElementChange
        {
            add { comboBoxSelectedElementChange += value; }
            remove { comboBoxSelectedElementChange -= value; }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public ComboBoxKozlov()
        {
            InitializeComponent();
            comboBox.SelectedIndexChanged += (sender, e)
                => { comboBoxSelectedElementChange?.Invoke(sender, e); };
        }
    }
}
