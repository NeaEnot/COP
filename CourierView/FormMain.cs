using _6thLabComponents;
using CourierBusinessLogic.Enums;
using CourierBusinessLogic.Interfaces;
using CourierBusinessLogic.Models;
using Lab2KOP;
using Lab2KOP.WordHelpModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Unity;
using WindowsFormsControlLibrary.Models;

namespace CourierView
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IDeliveryActLogic logic;

        private List<DeliveryAct> deliveryActs;

        public FormMain(IDeliveryActLogic logic)
        {
            this.logic = logic;
            InitializeComponent();

            Queue<string> queue = new Queue<string>();
            queue.Enqueue("DeliveryType");
            queue.Enqueue("CourierFIO");
            queue.Enqueue("DeliveryDate");
            controlDataTreeRow.LoadTreeInfo(new DataTreeNodeConfig { NodeNames = queue });
        }

        private void LoadData(bool isNeedStore = true)
        {
            deliveryActs = logic.Read(null);
            controlDataTreeRow.Clear();
            foreach (var act in deliveryActs)
            {
                controlDataTreeRow.AddRow(act);
            }

            if (isNeedStore)
            {
                Memento memento = new Memento(deliveryActs);
                actionsList.Add(memento);
            }

            buttonPrev.Enabled = actionsList.CanPrev;
            buttonNext.Enabled = actionsList.CanNext;
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
                logic.Create(form.Act);

                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (controlDataTreeRow.SelectedNode == null)
            {
                MessageBox.Show("Выберете элемент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    DeliveryAct deliveryAct = ParseActFromForm();
                    var form = Container.Resolve<FormDeliveryAct>();
                    form.Act = deliveryAct;

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        logic.Update(form.Act);

                        MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (controlDataTreeRow.SelectedNode == null)
            {
                MessageBox.Show("Выберете элемент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    DeliveryAct deliveryAct = ParseActFromForm();
                    logic.Delete(deliveryAct);

                    MessageBox.Show("Удаление прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private DeliveryAct ParseActFromForm()
        {
            TreeNode node = (TreeNode)controlDataTreeRow.SelectedNode;
            string fullPath = node.FullPath;
            string[] elements = fullPath.Split('\\');

            if (elements.Length != 3)
            {
                throw new Exception("Выбран узел не на том уровне");
            }

            DeliveryType deliveryType = DeliveryType.Газета;
            foreach (var item in Enum.GetValues(typeof(DeliveryType)))
            {
                if (item.ToString() == elements[0])
                {
                    deliveryType = (DeliveryType)item;
                }
            }

            return deliveryActs
                .First(rec => rec.DeliveryDate.ToString() == DateTime.Parse(elements[2]).ToString() &&
                              rec.DeliveryType == deliveryType &&
                              rec.CourierFIO == elements[1]);
        }

        private void buttonBackup_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        xmlBackuperKozlov.MakeBackup(deliveryActs, dialog.FileName);
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "*.docx|*.doc" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        componentWordReport.AddTable(deliveryActs, $"Отчёт за {DateTime.Now.ToString("dd.MM.yyyy")}", dialog.FileName);
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonChart_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "*.docx|*.doc" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
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
                        userWordLinearDiagramComponent.FilePath = dialog.FileName;
                        userWordLinearDiagramComponent.LegendVisible = true;

                        userWordLinearDiagramComponent.CreateDoc();

                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            Memento memento = actionsList.Prev();
            Restore(memento);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            Memento memento = actionsList.Next();
            Restore(memento);
        }

        private void Restore(Memento memento)
        {
            List<int> ids = new List<int>();

            foreach (DeliveryAct item in (List<DeliveryAct>)memento.Obj)
            {
                DeliveryAct act = deliveryActs.FirstOrDefault(rec => rec.Id == item.Id);

                if (act == null)
                {
                    logic.Create(item);
                }
                else
                {
                    logic.Update(act);
                }

                ids.Add(item.Id.Value);
            }

            foreach (DeliveryAct item in deliveryActs.Where(rec => !ids.Contains(rec.Id.Value)))
            {
                logic.Delete(item);
            }

            LoadData(false);
        }
    }
}
