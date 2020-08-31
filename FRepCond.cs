using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KursHolidays
{
    public partial class FRepCond : Form
    {
        public FRepCond()
        {
            InitializeComponent();
        }

        private void FRepCond_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "DatabaseDataSet.Conduct". При необходимости она может быть перемещена или удалена.
            this.ConductTableAdapter.Fill(this.DatabaseDataSet.Conduct);

            this.reportViewer1.RefreshReport();
        }
    }
}
