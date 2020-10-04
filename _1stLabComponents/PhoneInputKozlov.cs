using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace _1sLabComponents
{
    public partial class PhoneInputKozlov : UserControl
    {
        /// <summary>
        /// Цвет подсветки ошибки
        /// </summary>
        private Color wrongColor = Color.Red;

        /// <summary>
        /// Шаблон
        /// </summary>
        private Regex regex;

        /// <summary>
        /// Событие изменения текста
        /// </summary>
        private event EventHandler textBoxTextChanged;

        /// <summary>
        /// Цвет подсветки ошибки
        /// </summary>
        [Category("Спецификация"), Description("Цвет подсветки ошибки")]
        public Color WrongColor
        {
            set
            {
                wrongColor = value;
            }
        }

        /// <summary>
        /// Текст
        /// </summary>
        [Category("Спецификация"), Description("Текст")]
        public override string Text
        {
            get
            {
                if (regex.IsMatch(textBox.Text))
                {
                    return textBox.Text;
                }
                else
                {
                    return "Wrong value";
                }
            }
        }

        /// <summary>
        /// Событие изменения текста
        /// </summary>
        [Category("Спецификация"), Description("Событие изменения текста")]
        public event EventHandler TextBoxTextChanged
        {
            add { textBoxTextChanged += value; }
            remove { textBoxTextChanged -= value; }
        }

        /// <summary>
        /// Реакция на изменение текста
        /// </summary>
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (!regex.IsMatch(textBox.Text))
            {
                textBox.BackColor = wrongColor;
            }
            else
            {
                textBox.BackColor = Color.White;
            }

            textBoxTextChanged?.Invoke(sender, e);
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public PhoneInputKozlov()
        {
            InitializeComponent();

            regex = new Regex(@"^(\d-\d{3}-\d{3}-\d{2}-\d{2})$");

            ToolTip t = new ToolTip();
            t.SetToolTip(textBox, "x-xxx-xxx-xx-xx");
        }
    }
}