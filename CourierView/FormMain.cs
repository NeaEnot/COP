using CourierBusinessLogic.Interfaces;
using CourierBusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace CourierView
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IDeliveryActLogic logic;

        public FormMain(IDeliveryActLogic logic)
        {
            this.logic = logic;
            InitializeComponent();
        }

        private void LoadData()
        {
            var list = logic.Read(null);

            foreach (var element in list)
            {
                controlDataListRow.AddRow(element);
            }
        }

        private void controlDataListRow_Load(object sender, EventArgs e)
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
            int index = controlDataListRow.SelectedRowIndex;

            if (index >= 0)
            {
                DeliveryAct act = (DeliveryAct)controlDataListRow.SelectedRow;

                logic.Delete(new DeliveryAct { Id = act.Id });

                LoadData();
            }
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {

        }

        private void buttonChart_Click(object sender, EventArgs e)
        {

        }
    }
}
