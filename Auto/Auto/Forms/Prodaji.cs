using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Auto.AppData;


namespace Auto.Forms
{
    public partial class Prodaji : Form
    {
        DataBaseModel db;
        public Prodaji()
        {
            InitializeComponent();
            try
            {
                db = new DataBaseModel();
                dataGridView1.DataSource = (from s in db.Prodaji
                                            join p in db.Prodavets on s.Buyer equals p.idprodavets
                                            join b in db.Pokupatel on s.Buyer equals b.idPocupatel
                                            join car in db.har_avto on s.CarNum equals car.CarNum
                                            select new
                                            {
                                                s.CarNum,
                                                car.Firm,
                                                car.Model,
                                                car.Price,
                                                car.Year,
                                                Покупатель = b.FullName,
                                                Продавец = p.FullName,
                                                ДатаПродажи = s.SeleDate
                                            }).ToList();


            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void Prodaji_Load(object sender, EventArgs e)
        {
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter w = new StreamWriter("print.html");
                string html = @"<head> <meta charset=utf-8>  <style> table { border-collapse: collapse; } td, th { padding: 5px; } @media print { button { display: none; } }</style></head><table border=1> <tr> <th>Номер машины</th> <th>Фирма</th> <th>Модель</th> <th>Цена</th> <th>Год</th> <th>Покупатель</th> <th>Продавец</th> <th>Дата продажи</th> </tr>";
                var res = (from s in db.Prodaji
                           join p in db.Prodavets on s.Buyer equals p.idprodavets
                           join b in db.Pokupatel on s.Buyer equals b.idPocupatel
                           join car in db.har_avto on s.CarNum equals car.CarNum
                           select new
                           {
                               s.CarNum,
                               car.Firm,
                               car.Model,
                               car.Price,
                               car.Year,
                               Покупатель = b.FullName,
                               Продавец = p.FullName,
                               ДатаПродажи = s.SeleDate
                           }).ToList();
                foreach (var item in res)
                {
                    html += "<tr><td>" + item.CarNum + "</td><td>" + item.Firm + "</td><td>" + item.Model+ "</td><td>" + item.Price + "</td><td>" + item.Year + "</td><td>" + item.Покупатель+ "</td><td>" + item.Продавец + "</td><td>" + item.ДатаПродажи.Value.Day + "-" + item.ДатаПродажи.Value.Month + "-" + item.ДатаПродажи.Value.Year+ "</td></tr>";
                }
                html += "</table><button onclick=window.print()> Print</button>";
                w.WriteLine(html);
                w.Close();
                System.Diagnostics.Process.Start("print.html");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }


          

        }
    }
}
