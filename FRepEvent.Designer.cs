namespace KursHolidays
{
    partial class FRepEvent
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DatabaseDataSet = new KursHolidays.DatabaseDataSet();
            this.EventBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EventTableAdapter = new KursHolidays.DatabaseDataSetTableAdapters.EventTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.EventBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "KursHolidays.ReportEvent.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // DatabaseDataSet
            // 
            this.DatabaseDataSet.DataSetName = "DatabaseDataSet";
            this.DatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // EventBindingSource
            // 
            this.EventBindingSource.DataMember = "Event";
            this.EventBindingSource.DataSource = this.DatabaseDataSet;
            // 
            // EventTableAdapter
            // 
            this.EventTableAdapter.ClearBeforeFill = true;
            // 
            // FRepEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FRepEvent";
            this.Text = "Отчет";
            this.Load += new System.EventHandler(this.FRepEvent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DatabaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource EventBindingSource;
        private DatabaseDataSet DatabaseDataSet;
        private DatabaseDataSetTableAdapters.EventTableAdapter EventTableAdapter;
    }
}