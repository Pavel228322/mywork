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
using System.Text.RegularExpressions;
using System.IO;

namespace Auto.Forms
{
    public partial class AddCarForm : Form
    {
        DataBaseModel db;
        byte[] imgByte;
        public AddCarForm()
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
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
                Regex r = new Regex(@"[АВЕКМНОРСТУХABEKMHOPCTYX]\d{3}[АВЕКМНОРСТУХABEKMHOPCTYX]{2}\d{2,3}$");
                if (!r.IsMatch(textBox1.Text))
                {
                    MessageBox.Show("Введите корректный номер авто");
                    return;
                }
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" 
                    || textBox5.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox11.Text == "" 
                    || textBox6.Text == "" || textBox7.Text == "" || textBox10.Text == "")
                {
                    MessageBox.Show("Введите все данные");
                    return;
                }
                

                har_avto a = new har_avto();
                a.CarNum = textBox1.Text;
                a.Price = Decimal.Parse(textBox2.Text);
                a.Mileage = Convert.ToInt32(textBox3.Text);
                a.Color = textBox4.Text;
                a.Firm = textBox5.Text;
                a.Model = textBox6.Text;
                a.FuelType = textBox7.Text;
                a.Power = Convert.ToInt32(textBox8.Text);
                a.EngineVolume = Decimal.Parse(textBox9.Text);
                a.Year = Convert.ToInt32(textBox10.Text);
                a.Country = textBox11.Text;
                a.Description = richTextBox1.Text;
            a.CarImg = imgByte;
                db.har_avto.Add(a);
                db.SaveChanges();
                this.DialogResult = DialogResult.OK;
                this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                imgByte = ImageToByte2(Image.FromFile(fd.FileName));
            }
        }

        public static byte[] ImageToByte2(Image img)
        {
            byte[] byteArray = new byte[0];
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                stream.Close();
                
                byteArray = stream.ToArray();
            }
            return byteArray;
        }
    }
}
