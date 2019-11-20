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
using Auto.Forms;
using Auto.Classes;

namespace Auto
{
    public partial class Authorization : Form
    {
        DataBaseModel db;
        public Authorization()
        {
            InitializeComponent();
            db = new DataBaseModel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Введите все данные");
                    return;
                }

                var user = db.SystemUsers.FirstOrDefault(x => x.Login == textBox1.Text && x.Password == textBox2.Text);

                if (user == null)
                {
                    MessageBox.Show("Неверный логин/пароль");
                    return;
                }
                else
                {
                    if (user.Role == "Admin")
                    {
                        AdminForm F = new AdminForm();
                        F.Show();
                    } else
                    {
                        SellerForm F = new SellerForm();
                        UserData.prodavets = db.Prodavets.FirstOrDefault(x=>x.idprodavets == user.IdProdavets);
                        F.Show();
                    }
                }


            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void Authorization_Load(object sender, EventArgs e)
        {

        }
    }
}
