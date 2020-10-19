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
    public partial class Form2ndLab : Form
    {
        public Form2ndLab()
        {
            InitializeComponent();
            pdfPieChartPainterKozlov.SetDataLabelType(2);
        }

        private Character ReadCharacterFromForm()
        {
            return new Character
            {
                Name = textBoxName.Text,
                Covenant = textBoxCovenant.Text,
                Vitality = int.Parse(textBoxVitality.Text),
                Attunement = int.Parse(textBoxAttunement.Text),
                Endurance = int.Parse(textBoxEndurance.Text),
                Strength = int.Parse(textBoxStrength.Text),
                Dexterity = int.Parse(textBoxDexterity.Text),
                Resistance = int.Parse(textBoxResistance.Text),
                Intelligence = int.Parse(textBoxIntelligence.Text),
                Faith = int.Parse(textBoxFaith.Text)
            };
        }

        private void buttonSaveXML_Click(object sender, EventArgs e)
        {
            xmlBackuperKozlov.MakeBackup(ReadCharacterFromForm(), "C:\\Users\\olegk\\Downloads\\1");
        }

        private void buttonReportExcel_Click(object sender, EventArgs e)
        {
            //excelReporterKozlov.CreateReport(ReadCharacterFromForm(), "C:\\Users\\olegk\\Downloads\\character.xlsx");
        }

        private void buttonChart_Click(object sender, EventArgs e)
        {
            pdfPieChartPainterKozlov.MakePieChart(ReadCharacterFromForm(), "C:\\Users\\olegk\\Downloads\\character.pdf");
        }
    }
}
