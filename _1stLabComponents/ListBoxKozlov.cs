using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace _1stLabComponents
{
    public partial class ListBoxKozlov : UserControl
    {
        /// <summary>
        /// Шаблонная строка вывода
        /// </summary>
        private string templateString;

        /// <summary>
        /// Событие выбора элемента из списка
        /// </summary>
        private event EventHandler listBoxSelectedElementChange;

        /// <summary>
        /// Индекс выбранной строки
        /// </summary>
        [Category("Спецификация"), Description("Индекс выбранной строки")]
        public int SelectedIndex
        {
            get
            {
                return listBox.SelectedIndex;
            }
            set
            {
                listBox.SelectedIndex = value;
            }
        }

        /// <summary>
        /// Значение выбранной строки
        /// </summary>
        [Category("Спецификация"), Description("Значение выбранной строки")]
        public string SelectedString
        {
            get
            {
                return SelectedIndex >= 0 ? listBox.Items[SelectedIndex].ToString() : "";
            }
            set
            {
                if (SelectedIndex >= 0)
                {
                    listBox.Items[SelectedIndex] = value;
                }
            }
        }

        /// <summary>
        /// Событие выбора элемента из списка
        /// </summary>
        [Category("Спецификация"), Description("Событие выбора элемента из списка")]
        public event EventHandler ListBoxSelectedElementChange
        {
            add { listBoxSelectedElementChange += value; }
            remove { listBoxSelectedElementChange -= value; }
        }

        /// <summary>
        /// Метод для ввода шаблонной строки вывода
        /// </summary>
        /// <param name="s"> Шаблонная строка вывода: "Свойство1;Свойство2;..." </param>
        [Category("Спецификация"), Description("Метод для ввода шаблонной строки вывода")]
        public void SetTemplateString(string s)
        {
            templateString = s;
        }

        /// <summary>
        /// Метод для вставки значения
        /// </summary>
        /// <param name="obj"> Вставляемый объект </param>
        /// <param name="index"> Индекс строки, если не указывать или указать неверный индкс - вставка производится в конец </param>
        [Category("Спецификация"), Description("Метод для вставки значения")]
        public void Add(object obj, int index = -1)
        {
            string value = "";
            string[] props = templateString.Split(';');

            if (index >= 0 && index < listBox.Items.Count)
            {
                string[] itemProps = listBox.Items[index].ToString().Split(';');

                for (int i = 0; i < props.Length; i++)
                {
                    if (itemProps[i] == "")
                    {
                        value += obj.GetType().GetProperty(props[i]).GetValue(obj).ToString() + ";";
                    }
                    else
                    {
                        value += itemProps[i] + ";";
                    }
                }
                value = value.Substring(0, value.Length - 1);

                listBox.Items[index] = value;
            }
            else
            {
                for (int i = 0; i < props.Length; i++)
                {
                    value += obj.GetType().GetProperty(props[i]).GetValue(obj).ToString() + ";";
                }
                value = value.Substring(0, value.Length - 1);

                listBox.Items.Add(value);
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public ListBoxKozlov()
        {
            InitializeComponent();
            listBox.SelectedIndexChanged += (sender, e)
                => { listBoxSelectedElementChange?.Invoke(sender, e); };
        }
    }
}
