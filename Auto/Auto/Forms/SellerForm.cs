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
using Auto.Classes;


namespace Auto.Forms
{
    public partial class SellerForm : Form
    {
        DataBaseModel db;
        public SellerForm()
        {
            InitializeComponent();
            db = new DataBaseModel();
            initClients();
            initCars();
        }

        private void initClients()
        {
            try
            {
                dataGridView2.DataSource = db.Pokupatel.Select(x => new { x.FullName, x.Address,x.Phone}).ToList();
            }
            catch (Exception err)
            {
            }
        }
        private void initCars()
        {
            try
            {
                dataGridView1.DataSource = db.har_avto.Where(x => x.Status != "Продан").Select(x => new {x.CarNum, x.Firm,x.Model,
                    x.Price,
                    x.Mileage ,x.Color,
                    СтрранаПроизводителя = x.Country,
                x.Year,x.EngineVolume,x.Power, x.FuelType}).ToList();
            }
            catch (Exception err)
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SellerAddClient f = new SellerAddClient();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                initClients();
            }
        }

        private void SellerForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var carNum = dataGridView1.SelectedCells[0].Value;
                label1.Text = db.har_avto.FirstOrDefault(x=>x.CarNum == carNum.ToString()).Description;

            }
            catch (Exception)
            {

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var carNum = dataGridView1.SelectedCells[0].Value;
                var id = (dataGridView2.SelectedCells[0].Value).ToString();
                var clientId = db.Pokupatel.FirstOrDefault(x => x.FullName == id).idPocupatel;
                Prodaji p = new Prodaji();
                p.SeleDate = DateTime.Now;
                p.CarNum = carNum.ToString();
                p.Seller = UserData.prodavets.idprodavets;
                p.Buyer = clientId;

                var car = db.har_avto.FirstOrDefault(x => x.CarNum == carNum.ToString());
                car.Status = "Продан";

                db.Prodaji.Add(p);
                db.SaveChanges();
                initCars();
                MessageBox.Show("Автомобиль " + carNum.ToString() + " продан клиенту " + db.Pokupatel.FirstOrDefault(x => x.FullName == id).FullName);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
