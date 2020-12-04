namespace CourierView
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.controlDataTreeRow = new WindowsFormsControlLibrary.Data.ControlDataTreeRow();
            this.buttonBackup = new System.Windows.Forms.Button();
            this.buttonReport = new System.Windows.Forms.Button();
            this.buttonChart = new System.Windows.Forms.Button();
            this.componentWordReport = new ClassLibraryControlInvisible.ComponentWordReport(this.components);
            this.userWordLinearDiagramComponent = new Lab2KOP.UserWordLinearDiagramComponent(this.components);
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.xmlBackuperKozlov = new _2ndLabComponents.XmlBackuperKozlov(this.components);
            this.buttonPrev = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.actionsList = new _6thLabComponents.ActionsList(this.components);
            this.comboBoxPlugins = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonInvokePlugin = new System.Windows.Forms.Button();
            this.textBoxModifyValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(12, 404);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // controlDataTreeRow
            // 
            this.controlDataTreeRow.Location = new System.Drawing.Point(12, 12);
            this.controlDataTreeRow.Name = "controlDataTreeRow";
            this.controlDataTreeRow.Size = new System.Drawing.Size(776, 374);
            this.controlDataTreeRow.TabIndex = 3;
            this.controlDataTreeRow.Load += new System.EventHandler(this.controlDataTreeRow_Load);
            // 
            // buttonBackup
            // 
            this.buttonBackup.Location = new System.Drawing.Point(632, 404);
            this.buttonBackup.Name = "buttonBackup";
            this.buttonBackup.Size = new System.Drawing.Size(75, 23);
            this.buttonBackup.TabIndex = 4;
            this.buttonBackup.Text = "Бэкап";
            this.buttonBackup.UseVisualStyleBackColor = true;
            this.buttonBackup.Click += new System.EventHandler(this.buttonBackup_Click);
            // 
            // buttonReport
            // 
            this.buttonReport.Location = new System.Drawing.Point(713, 404);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(75, 23);
            this.buttonReport.TabIndex = 5;
            this.buttonReport.Text = "Отчёт";
            this.buttonReport.UseVisualStyleBackColor = true;
            this.buttonReport.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // buttonChart
            // 
            this.buttonChart.Location = new System.Drawing.Point(713, 431);
            this.buttonChart.Name = "buttonChart";
            this.buttonChart.Size = new System.Drawing.Size(75, 23);
            this.buttonChart.TabIndex = 6;
            this.buttonChart.Text = "Диаграмма";
            this.buttonChart.UseVisualStyleBackColor = true;
            this.buttonChart.Click += new System.EventHandler(this.buttonChart_Click);
            // 
            // userWordLinearDiagramComponent
            // 
            this.userWordLinearDiagramComponent.ChartLegendPosition = Lab2KOP.LegendPositionEnum.Bottom;
            this.userWordLinearDiagramComponent.ChartTitle = null;
            this.userWordLinearDiagramComponent.Data = null;
            this.userWordLinearDiagramComponent.DataLabel = null;
            this.userWordLinearDiagramComponent.FilePath = null;
            this.userWordLinearDiagramComponent.LegendVisible = false;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(12, 433);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 7;
            this.buttonUpdate.Text = "Изменить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(93, 404);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 8;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonPrev
            // 
            this.buttonPrev.Location = new System.Drawing.Point(99, 433);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(27, 23);
            this.buttonPrev.TabIndex = 9;
            this.buttonPrev.Text = "<";
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(132, 433);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(27, 23);
            this.buttonNext.TabIndex = 10;
            this.buttonNext.Text = ">";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // comboBoxPlugins
            // 
            this.comboBoxPlugins.FormattingEnabled = true;
            this.comboBoxPlugins.Location = new System.Drawing.Point(267, 404);
            this.comboBoxPlugins.Name = "comboBoxPlugins";
            this.comboBoxPlugins.Size = new System.Drawing.Size(315, 21);
            this.comboBoxPlugins.TabIndex = 11;
            this.comboBoxPlugins.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlugins_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(206, 409);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Плагины:";
            // 
            // buttonInvokePlugin
            // 
            this.buttonInvokePlugin.Location = new System.Drawing.Point(507, 431);
            this.buttonInvokePlugin.Name = "buttonInvokePlugin";
            this.buttonInvokePlugin.Size = new System.Drawing.Size(75, 23);
            this.buttonInvokePlugin.TabIndex = 13;
            this.buttonInvokePlugin.Text = "Выполнить";
            this.buttonInvokePlugin.UseVisualStyleBackColor = true;
            this.buttonInvokePlugin.Click += new System.EventHandler(this.buttonInvokePlugin_Click);
            // 
            // textBoxModifyValue
            // 
            this.textBoxModifyValue.Enabled = false;
            this.textBoxModifyValue.Location = new System.Drawing.Point(267, 431);
            this.textBoxModifyValue.Name = "textBoxModifyValue";
            this.textBoxModifyValue.Size = new System.Drawing.Size(145, 20);
            this.textBoxModifyValue.TabIndex = 14;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 466);
            this.Controls.Add(this.textBoxModifyValue);
            this.Controls.Add(this.buttonInvokePlugin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxPlugins);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPrev);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonChart);
            this.Controls.Add(this.buttonReport);
            this.Controls.Add(this.buttonBackup);
            this.Controls.Add(this.controlDataTreeRow);
            this.Controls.Add(this.buttonAdd);
            this.Name = "FormMain";
            this.Text = "Курьер";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonAdd;
        private WindowsFormsControlLibrary.Data.ControlDataTreeRow controlDataTreeRow;
        private System.Windows.Forms.Button buttonBackup;
        private System.Windows.Forms.Button buttonReport;
        private System.Windows.Forms.Button buttonChart;
        private ClassLibraryControlInvisible.ComponentWordReport componentWordReport;
        private Lab2KOP.UserWordLinearDiagramComponent userWordLinearDiagramComponent;
        private _2ndLabComponents.XmlBackuperKozlov xmlBackuperKozlov;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Button buttonNext;
        private _6thLabComponents.ActionsList actionsList;
        private System.Windows.Forms.ComboBox comboBoxPlugins;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonInvokePlugin;
        private System.Windows.Forms.TextBox textBoxModifyValue;
    }
}

