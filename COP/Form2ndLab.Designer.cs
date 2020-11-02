namespace COP
{
    partial class Form2ndLab
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
            this.components = new System.ComponentModel.Container();
            this.buttonSaveXML = new System.Windows.Forms.Button();
            this.buttonReportExcel = new System.Windows.Forms.Button();
            this.buttonChart = new System.Windows.Forms.Button();
            this.excelReporterKozlov = new _2ndLabComponents.ExcelReporterKozlov(this.components);
            this.pdfPieChartPainterKozlov = new _2ndLabComponents.PdfPieChartPainterKozlov(this.components);
            this.xmlBackuperKozlov = new _2ndLabComponents.XmlBackuperKozlov(this.components);
            this.SuspendLayout();
            // 
            // buttonSaveXML
            // 
            this.buttonSaveXML.Location = new System.Drawing.Point(12, 8);
            this.buttonSaveXML.Name = "buttonSaveXML";
            this.buttonSaveXML.Size = new System.Drawing.Size(175, 20);
            this.buttonSaveXML.TabIndex = 20;
            this.buttonSaveXML.Text = "Сохранить в XML";
            this.buttonSaveXML.UseVisualStyleBackColor = true;
            this.buttonSaveXML.Click += new System.EventHandler(this.buttonSaveXML_Click);
            // 
            // buttonReportExcel
            // 
            this.buttonReportExcel.Location = new System.Drawing.Point(12, 34);
            this.buttonReportExcel.Name = "buttonReportExcel";
            this.buttonReportExcel.Size = new System.Drawing.Size(175, 23);
            this.buttonReportExcel.TabIndex = 21;
            this.buttonReportExcel.Text = "Отчёт в Excel";
            this.buttonReportExcel.UseVisualStyleBackColor = true;
            this.buttonReportExcel.Click += new System.EventHandler(this.buttonReportExcel_Click);
            // 
            // buttonChart
            // 
            this.buttonChart.Location = new System.Drawing.Point(12, 63);
            this.buttonChart.Name = "buttonChart";
            this.buttonChart.Size = new System.Drawing.Size(175, 23);
            this.buttonChart.TabIndex = 22;
            this.buttonChart.Text = "Диаграмма";
            this.buttonChart.UseVisualStyleBackColor = true;
            this.buttonChart.Click += new System.EventHandler(this.buttonChart_Click);
            // 
            // Form2ndLab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 96);
            this.Controls.Add(this.buttonChart);
            this.Controls.Add(this.buttonReportExcel);
            this.Controls.Add(this.buttonSaveXML);
            this.Name = "Form2ndLab";
            this.Text = "Form2ndLab";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonSaveXML;
        private System.Windows.Forms.Button buttonReportExcel;
        private System.Windows.Forms.Button buttonChart;
        private _2ndLabComponents.ExcelReporterKozlov excelReporterKozlov;
        private _2ndLabComponents.PdfPieChartPainterKozlov pdfPieChartPainterKozlov;
        private _2ndLabComponents.XmlBackuperKozlov xmlBackuperKozlov;
    }
}