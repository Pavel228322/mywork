using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Auto.AppData;
namespace Auto.Forms
{
    public partial class WatchSellersForm : Form
    {
        DataBaseModel db;
        public WatchSellersForm()
        {
            InitializeComponent();
            try
            {
                db = new DataBaseModel();
                dataGridView1.DataSource = db.Prodavets.Select(x => new { x.FullName, x.Phone }).ToList();

            }
            catch (Exception err)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddSellerForm f = new AddSellerForm();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                dataGridView1.DataSource = db.Prodavets.Select(x => new { x.FullName, x.Phone }).ToList();
            }
        }

        private void WatchSellersForm_Load(object sender, EventArgs e)
        {
                    
        }
    }
}
