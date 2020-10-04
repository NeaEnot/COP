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
    public partial class FormTest : Form
    {
        public FormTest() 
        { 
            InitializeComponent(); 
            controlComboBoxSelected.LoadEnumeration(typeof(TestEnum));
        }
        
        private void controlComboBoxSelected_ComboBoxSelectedElementChange(object sender, EventArgs e) 
        { 
            MessageBox.Show(controlComboBoxSelected.SelectedText);
        }

        private void buttonChange_Click(object sender, EventArgs e)
        { 
            controlComboBoxSelected.SelectedIndex = 0; 
        }
    }
}
