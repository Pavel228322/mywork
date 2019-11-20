using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auto.Forms
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WatchSellersForm F = new WatchSellersForm();
            F.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WatchCarsForm f = new WatchCarsForm();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Forms.Prodaji b = new Forms.Prodaji();
            b.ShowDialog();
        }
    }
}
