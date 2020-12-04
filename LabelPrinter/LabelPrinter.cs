using CourierBusinessLogic.Models;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PluginConfiguration.Interfaces;
using System.ComponentModel.Composition;
using System.Windows.Forms;

namespace LabelPrinter
{
    [Export(typeof(IPrinter))]
    public class LabelPrinter : IPrinter
    {
        public string Name => "Формирование наклейки на посылку";

        public void Print(DeliveryAct act)
        {
            Document document = new Document();

            Style style = document.Styles["Normal"];
            style.Font.Name = "Times New Roman";
            style.Font.Size = 14;
            style = document.Styles.AddStyle("NormalTitle", "Normal");
            style.Font.Bold = true;

            Section section = document.AddSection();
            Paragraph paragraphCourier = section.AddParagraph("Курьер: " + act.CourierFIO);
            paragraphCourier.Format.SpaceAfter = "0,1cm";
            Paragraph paragraphType = section.AddParagraph("Тип доставки: " + act.DeliveryType);
            paragraphType.Format.SpaceAfter = "0,1cm";
            Paragraph paragraphDate = section.AddParagraph("Дата доставки: " + act.DeliveryDate);
            paragraphDate.Format.SpaceAfter = "0,1cm";

            using (var dialog = new SaveFileDialog { Filter = "(*.pdf)|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always) { Document = document };
                    renderer.RenderDocument();
                    renderer.PdfDocument.Save(dialog.FileName);
                }
            }
        }
    }
}
