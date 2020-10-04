using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes.Charts;
using MigraDoc.Rendering;
using System.ComponentModel;

namespace _2ndLabComponents
{
    public partial class PdfPieChartPainterKozlov : Component
    {
        private DataLabelType dataLabelType = DataLabelType.None;

        /// <summary>
        /// Конструктор
        /// </summary>
        public PdfPieChartPainterKozlov()
        {
            InitializeComponent();
        }

        public PdfPieChartPainterKozlov(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        /// <summary>
        /// Создание круговой диаграммы из объекта
        /// </summary>
        /// <param name="obj"> Источник данных </param>
        /// <param name="fileName"> Имя выходного файла </param>
        public void MakePieChart(object obj, string fileName)
        {
            Document document = new Document();

            Style style = document.Styles["Normal"];
            style.Font.Name = "Times New Roman";
            style.Font.Size = 14;
            style = document.Styles.AddStyle("NormalTitle", "Normal");
            style.Font.Bold = true;

            Section section = document.AddSection();
            Paragraph paragraph = section.AddParagraph("");
            paragraph.Format.SpaceAfter = "1cm";
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Style = "NormalTitle";

            var chart = document.LastSection.AddChart(ChartType.Pie2D);
            chart.Left = 0;

            chart.Width = Unit.FromCentimeter(12);
            chart.Height = Unit.FromCentimeter(12);

            chart.DataLabel.Type = dataLabelType;

            Series series = chart.SeriesCollection.AddSeries();
            XSeries xseries = chart.XValues.AddXSeries();

            foreach (var prop in obj.GetType().GetProperties())
            {
                double d;
                if (double.TryParse(prop.GetValue(obj).ToString(), out d))
                {
                    xseries.Add(prop.Name);
                    series.Add(d);
                }
            }

            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always) { Document = document };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(fileName);
        }

        /// <summary>
        /// Устанавливает тип подписи к графику
        /// </summary>
        /// <param name="type"> 0 - нет, 1 - процент, 2 - значение </param>
        public void SetDataLabelType(int type)
        {
            dataLabelType = (DataLabelType)type;
        }
    }
}
