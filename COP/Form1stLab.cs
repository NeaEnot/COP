using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COP
{
    public partial class Form1stLab : Form
    {
        public Form1stLab()
        {
            InitializeComponent();

            List<string> list = new List<string>();
            for (int i = 100000; i < 200000; i += 12345)
            {
                list.Add(i.ToString());
            }

            comboBoxKozlov.Items = list;

            phoneInputKozlov.WrongColor = Color.Coral;

            List<string> names = new List<string>();
            names.Add("Бхирампал");
            names.Add("Маргерита");
            names.Add("Фоулк");
            names.Add("Хамамото");
            names.Add("Русонин");
            names.Add("Базазат");
            names.Add("Ыилваелл");
            names.Add("Куркотатт");
            names.Add("Томас");
            names.Add("Куикс");
            names.Add("Таф");
            names.Add("Стренкрикс");
            names.Add("Уазебун");
            names.Add("Вагдраэнаг");
            names.Add("Морита");
            names.Add("Загаф");
            names.Add("Брезотт");
            names.Add("Аицросс");
            names.Add("Ар'ееран");
            names.Add("Рохаен");
            names.Add("Гнагуар");
            names.Add("Озозед");
            names.Add("Стуокс");
            names.Add("Мериона");
            names.Add("Мармадук");
            names.Add("Гринкеок");

            List<string> covenants = new List<string>();
            covenants.Add("Белый путь");
            covenants.Add("Стражи Принцессы");
            covenants.Add("Клинки Темной Луны");
            covenants.Add("Воины Света");
            covenants.Add("Лесные Охотники");
            covenants.Add("Слуги Хаоса");
            covenants.Add("Слуги Повелителя Могил");
            covenants.Add("Путь Дракона");
            covenants.Add("Темные Духи");

            listBoxKozlov.SetTemplateString("Name;Covenant;Level");

            Random rnd = new Random();
            for (int i = 0; i < 8; i++)
            {
                Character character = new Character
                {
                    Name = names[rnd.Next(names.Count)] + " " + names[rnd.Next(names.Count)],
                    Covenant = covenants[rnd.Next(covenants.Count)],
                    Vitality = rnd.Next(100),
                    Attunement = rnd.Next(100),
                    Endurance = rnd.Next(100),
                    Strength = rnd.Next(100),
                    Dexterity = rnd.Next(100),
                    Resistance = rnd.Next(100),
                    Intelligence = rnd.Next(100),
                    Faith = rnd.Next(100)
                };

                listBoxKozlov.Add(character);
            }
        }

        private void buttonIndexApply_Click(object sender, EventArgs e)
        {
            int index = int.Parse(textBoxIndex1.Text);
            comboBoxKozlov.SelectedIndex = index;
        }

        private void ButtonValueApply_Click(object sender, EventArgs e)
        {
            comboBoxKozlov.SelectedText = textBoxValue.Text;
        }

        private void comboBoxKozlov_ComboBoxSelectedElementChange(object sender, EventArgs e)
        {
            textBoxIndex1.Text = comboBoxKozlov.SelectedIndex.ToString();
            textBoxValue.Text = comboBoxKozlov.SelectedText;
        }

        private void phoneInputKozlov_TextBoxTextChanged(object sender, EventArgs e)
        {
            labelPhone.Text = phoneInputKozlov.Text;
        }

        private void buttonCharacterApply_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text != "" || textBoxCovenant.Text != "")
            {
                Character character = new Character
                {
                    Name = textBoxName.Text,
                    Covenant = textBoxCovenant.Text
                };

                if (textBoxIndex2.Text == "")
                {
                    listBoxKozlov.Add(character);
                }
                else
                {
                    listBoxKozlov.Add(character, int.Parse(textBoxIndex2.Text));
                }
            }
        }
    }
}
