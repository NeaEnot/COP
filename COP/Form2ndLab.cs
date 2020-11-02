using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace COP
{
    public partial class Form2ndLab : Form
    {
        public Form2ndLab()
        {
            InitializeComponent();
        }

        private List<Character> GenerateCharacters()
        {
            List<Character> characters = new List<Character>();

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

            Random rnd = new Random();
            for (int i = 0; i < 1000; i++)
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

                characters.Add(character);
            }

            return characters;
        }

        private void buttonSaveXML_Click(object sender, EventArgs e)
        {
            xmlBackuperKozlov.MakeBackup(GenerateCharacters(), @"C:\Users\root\Downloads\1");
        }

        private void buttonReportExcel_Click(object sender, EventArgs e)
        {
            excelReporterKozlov.CreateReport(GenerateCharacters(), @"C:\Users\root\Downloads\characters.xlsx");
        }

        private void buttonChart_Click(object sender, EventArgs e)
        {
            List<Character> characters = GenerateCharacters();
            pdfPieChartPainterKozlov.SetDataLabelType(1);

            pdfPieChartPainterKozlov.SelectionFunction = (character) => ((Character)character).Covenant;
            pdfPieChartPainterKozlov.MakePieChart(characters, @"C:\Users\root\Downloads\characters1.pdf");

            pdfPieChartPainterKozlov.SelectionFunction = (character) =>
            {
                int level = ((Character)character).Level;
                return $"level: {Math.Floor((double)(level - 1) / 50) * 50} - {Math.Ceiling((double)level / 50) * 50}";
            };
            pdfPieChartPainterKozlov.MakePieChart(characters, @"C:\Users\root\Downloads\characters2.pdf");
        }
    }
}
