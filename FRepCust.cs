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
    public partial class FRepCust : Form
    {
        public FRepCust()
        {
            InitializeComponent();
        }

        private void FRepCust_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "DatabaseDataSet.Customer". При необходимости она может быть перемещена или удалена.
            this.CustomerTableAdapter.Fill(this.DatabaseDataSet.Customer);

            this.reportViewer1.RefreshReport();
        }
    }
}
