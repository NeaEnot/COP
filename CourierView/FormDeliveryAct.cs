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

        private DeliveryAct act;
        public DeliveryAct Act 
        { 
            set 
            { 
                act = value;
                textBoxFIO.Text = act.CourierFIO;
                controlComboBoxDeliveryType.SelectedItem = act.DeliveryType;
                controlInputDateDeliveryDate.Value = act.DeliveryDate;
            }
            get
            {
                return act;
            }
        }

        public FormDeliveryAct()
        {
            InitializeComponent();

            foreach (var item in Enum.GetValues(typeof(DeliveryType)))
            {
                controlComboBoxDeliveryType.LoadElement(item);
            }

            controlInputDateDeliveryDate.Value = DateTime.Now;

            act = new DeliveryAct();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            act.Id = (act == null ? null : act.Id);
            act.CourierFIO = textBoxFIO.Text;
            act.DeliveryType = (DeliveryType?)controlComboBoxDeliveryType.SelectedItem;
            act.DeliveryDate = checkBoxIsDelivered.Checked ? controlInputDateDeliveryDate.Value : null;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void checkBoxIsDelivered_CheckedChanged(object sender, EventArgs e)
        {
            controlInputDateDeliveryDate.Enabled = checkBoxIsDelivered.Checked;
        }
    }
}
