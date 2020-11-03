using CourierBusinessLogic.Interfaces;
using CourierBusinessLogic.Models;
using Lab2KOP;
using Lab2KOP.WordHelpModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace CourierView
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IDeliveryActLogic logic;

        List<DeliveryAct> deliveryActs;

        public FormMain(IDeliveryActLogic logic)
        {
            this.logic = logic;
            InitializeComponent();

            Queue<string> queue = new Queue<string>();
            queue.Enqueue("DeliveryType");
            queue.Enqueue("DeliveryDate");
            queue.Enqueue("CourierFIO");
            controlDataTreeRow.LoadTreeInfo(new WindowsFormsControlLibrary.Models.DataTreeNodeConfig { NodeNames = queue });
        }

        private void LoadData()
        {
            deliveryActs = logic.Read(null);
            foreach (var act in deliveryActs)
            {
                controlDataTreeRow.AddRow(act);
            }
        }

        private void controlDataTreeRow_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormDeliveryAct>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (controlDataTreeRow.SelectedNode == null)
            {
                MessageBox.Show("Выберете элемент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DeliveryAct act = (DeliveryAct)controlDataTreeRow.SelectedNode;
                logic.Delete(new DeliveryAct { Id = act.Id });
                LoadData();
            }
        }

        private void buttonBackup_Click(object sender, EventArgs e)
        {
            xmlBackuperKozlov.MakeBackup(deliveryActs, @"C:\Users\olegk\Downloads\Бэкап");
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            componentWordReport.AddTable(deliveryActs, $"Отчёт за {DateTime.Now.ToString("dd.MM.yyyy")}", @"C:\Users\olegk\Downloads\Отчёт.docx");
        }

        private void buttonChart_Click(object sender, EventArgs e)
        {
            userWordLinearDiagramComponent.Data = new List<Data>();
            foreach (DeliveryAct act in deliveryActs)
            {
                Data data = userWordLinearDiagramComponent.Data.Find(d => d.X.ToString() == act.DeliveryDate?.ToString("MM"));

                if (data == null)
                {
                    data = new Data { IntX = int.Parse(act.DeliveryDate?.ToString("MM")), IntY = 0 };
                    userWordLinearDiagramComponent.Data.Add(data);
                }

                data.IntY = (int)data.Y + 1;
            }

            for (int i = 0; i < userWordLinearDiagramComponent.Data.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if ((int)userWordLinearDiagramComponent.Data[i].Y < (int)userWordLinearDiagramComponent.Data[j].Y)
                    {
                        Data tmp = userWordLinearDiagramComponent.Data[i];
                        userWordLinearDiagramComponent.Data[i] = userWordLinearDiagramComponent.Data[j];
                        userWordLinearDiagramComponent.Data[j] = tmp;
                    }
                }
            }

            userWordLinearDiagramComponent.ChartLegendPosition = LegendPositionEnum.Bottom;
            userWordLinearDiagramComponent.ChartTitle = $"Отчёт за {DateTime.Now.ToString("dd.MM.yyyy")}";
            userWordLinearDiagramComponent.DataLabel = "Доставок в месяц";
            userWordLinearDiagramComponent.FilePath = @"C:\Users\olegk\Downloads\Диаграмма.docx";
            userWordLinearDiagramComponent.LegendVisible = true;

            userWordLinearDiagramComponent.CreateDoc();
        }
    }
}
