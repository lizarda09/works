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
    public partial class FRepEvent : Form
    {
        public FRepEvent()
        {
            InitializeComponent();
        }

        private void FRepEvent_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "DatabaseDataSet.Event". При необходимости она может быть перемещена или удалена.
            this.EventTableAdapter.Fill(this.DatabaseDataSet.Event);

            this.reportViewer1.RefreshReport();
        }
    }
}
