using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
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
        /// <param name="s"> Шаблонная строка вывода: {Property} - место для подстановки </param>
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
            string value = (index >= 0 && index < listBox.Items.Count) ? listBox.Items[index].ToString() : templateString;

            Regex regex = new Regex(@"{[\w|\d|_]+}");
            MatchCollection matches = regex.Matches(value);

            for (int i = 0; i < matches.Count; i++)
            {
                string prop = matches[i].Value.Substring(1, matches[i].Value.Length - 2);

                if (obj.GetType().GetProperty(prop).GetValue(obj).ToString() != "")
                {
                    value = value.Replace(matches[i].Value, obj.GetType().GetProperty(prop).GetValue(obj).ToString());
                }
            }

            if (index >= 0 && index < listBox.Items.Count)
            {
                listBox.Items[index] = value;
            }
            else
            {
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
