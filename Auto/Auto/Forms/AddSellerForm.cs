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
    public partial class AddSellerForm : Form
    {
        DataBaseModel db;
        public AddSellerForm()
        {
            InitializeComponent();
            try
            {
                db = new DataBaseModel();
            }
            catch (Exception)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" ||textBox3.Text == "")
                {
                    MessageBox.Show("Введите данные");
                    return;
                }
                Prodavets p = new Prodavets();
                p.FullName = textBox1.Text;
                p.Phone = textBox3.Text;
                db.Prodavets.Add(p);
                db.SaveChanges();

                SystemUsers u = new SystemUsers();
                u.IdProdavets = p.idprodavets;
                u.Login = textBox2.Text;
                u.Password = textBox4.Text;
                db.SystemUsers.Add(u);
                db.SaveChanges();
                MessageBox.Show("Готово. Сохраните логин и пароль: "+u.Login + " "+ u.Password);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void AddSellerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
