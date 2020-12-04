using CourierBusinessLogic.Enums;
using CourierBusinessLogic.Models;
using System;
using System.Windows.Forms;

namespace DeliveryTypeChanger
{
    public partial class FormChangeType : Form
    {
        private DeliveryAct act;
        public DeliveryAct Act { get; }

        public FormChangeType(DeliveryAct act)
        {
            InitializeComponent();
            this.act = act;

            foreach (var item in Enum.GetValues(typeof(DeliveryType)))
            {
                comboBox.Items.Add(item);
            }

            comboBox.SelectedItem = act.DeliveryType.Value;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            act.DeliveryType = (DeliveryType)comboBox.SelectedItem;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
