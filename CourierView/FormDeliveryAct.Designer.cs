namespace CourierView
{
    partial class FormDeliveryAct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxFIO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.controlComboBoxDeliveryType = new WindowsFormsControlLibrary.Selected.ControlSelectedComboBoxSingle();
            this.controlInputDateDeliveryDate = new WindowsFormsControlLibrary.Input.ControlInputRangeDate();
            this.checkBoxIsDelivered = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBoxFIO
            // 
            this.textBoxFIO.Location = new System.Drawing.Point(141, 20);
            this.textBoxFIO.Name = "textBoxFIO";
            this.textBoxFIO.Size = new System.Drawing.Size(161, 20);
            this.textBoxFIO.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "ФИО курьера";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Тип доставки";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Дата";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(129, 160);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // controlComboBoxDeliveryType
            // 
            this.controlComboBoxDeliveryType.Location = new System.Drawing.Point(141, 61);
            this.controlComboBoxDeliveryType.Name = "controlComboBoxDeliveryType";
            this.controlComboBoxDeliveryType.SelectedIndex = -1;
            this.controlComboBoxDeliveryType.SelectedItem = null;
            this.controlComboBoxDeliveryType.Size = new System.Drawing.Size(161, 21);
            this.controlComboBoxDeliveryType.TabIndex = 7;
            // 
            // controlInputDateDeliveryDate
            // 
            this.controlInputDateDeliveryDate.Location = new System.Drawing.Point(141, 100);
            this.controlInputDateDeliveryDate.MaxDate = new System.DateTime(9999, 12, 31, 23, 59, 59, 999);
            this.controlInputDateDeliveryDate.MinDate = new System.DateTime(((long)(0)));
            this.controlInputDateDeliveryDate.Name = "controlInputDateDeliveryDate";
            this.controlInputDateDeliveryDate.Size = new System.Drawing.Size(161, 20);
            this.controlInputDateDeliveryDate.TabIndex = 8;
            this.controlInputDateDeliveryDate.Value = new System.DateTime(2020, 10, 21, 10, 37, 25, 220);
            // 
            // checkBoxIsDelivered
            // 
            this.checkBoxIsDelivered.AutoSize = true;
            this.checkBoxIsDelivered.Checked = true;
            this.checkBoxIsDelivered.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIsDelivered.Location = new System.Drawing.Point(15, 133);
            this.checkBoxIsDelivered.Name = "checkBoxIsDelivered";
            this.checkBoxIsDelivered.Size = new System.Drawing.Size(88, 17);
            this.checkBoxIsDelivered.TabIndex = 9;
            this.checkBoxIsDelivered.Text = "Доставлено";
            this.checkBoxIsDelivered.UseVisualStyleBackColor = true;
            this.checkBoxIsDelivered.CheckedChanged += new System.EventHandler(this.checkBoxIsDelivered_CheckedChanged);
            // 
            // FormDeliveryAct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 195);
            this.Controls.Add(this.checkBoxIsDelivered);
            this.Controls.Add(this.controlInputDateDeliveryDate);
            this.Controls.Add(this.controlComboBoxDeliveryType);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFIO);
            this.Name = "FormDeliveryAct";
            this.Text = "Доставка";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFIO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonSave;
        private WindowsFormsControlLibrary.Selected.ControlSelectedComboBoxSingle controlComboBoxDeliveryType;
        private WindowsFormsControlLibrary.Input.ControlInputRangeDate controlInputDateDeliveryDate;
        private System.Windows.Forms.CheckBox checkBoxIsDelivered;
    }
}