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

        List<DeliveryAct> deliveryActs;

        public FormMain(IDeliveryActLogic logic)
        {
            this.logic = logic;
            InitializeComponent();

            Queue<string> queue = new Queue<string>();
            queue.Enqueue("DeliveryType");
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
            DeliveryAct act = (DeliveryAct)controlDataTreeRow.SelectedNode;

            logic.Delete(new DeliveryAct { Id = act.Id });

            LoadData();
        }

        private void buttonBackup_Click(object sender, EventArgs e)
        {
            componentSaveDataJson.SaveData("C:\\Users\\root\\Downloads\\Бэкап", deliveryActs);
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            
        }
    }
}
