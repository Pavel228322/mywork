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
    public partial class SellerAddClient : Form
    {
        DataBaseModel db;
        public SellerAddClient()
        {
            InitializeComponent();
            db = new DataBaseModel();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Введите данные");
                    return;
                }
                Pokupatel p = new Pokupatel();
                p.FullName = textBox1.Text;
                p.Address = textBox2.Text;
                p.Phone = textBox3.Text;
                db.Pokupatel.Add(p);
                db.SaveChanges();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                this.Close();
            }
          
             
        }
    }
}
