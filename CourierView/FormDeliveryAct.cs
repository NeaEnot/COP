using CourierBusinessLogic.Interfaces;
using CourierBusinessLogic.Models;
using CourierBusinessLogic.Enums;
using System;
using System.Windows.Forms;
using Unity;

namespace CourierView
{
    public partial class FormDeliveryAct : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IDeliveryActLogic logic;

        public FormDeliveryAct(IDeliveryActLogic logic)
        {
            this.logic = logic;
            InitializeComponent();

            foreach (var item in Enum.GetValues(typeof(DeliveryType)))
            {
                controlComboBoxDeliveryType.LoadElement(item);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            DeliveryAct act = new DeliveryAct
            {
                CourierFIO = textBoxFIO.Text,
                DeliveryType = (DeliveryType?)controlComboBoxDeliveryType.SelectedItem,
                DeliveryDate = checkBoxIsDelivered.Checked ? controlInputDateDeliveryDate.Value : null
            };

            logic.CreateOrUpdate(act);
        }

        private void checkBoxIsDelivered_CheckedChanged(object sender, EventArgs e)
        {
            controlInputDateDeliveryDate.Enabled = checkBoxIsDelivered.Checked;
        }
    }
}
