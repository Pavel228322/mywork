﻿using System;
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
    public partial class WatchCarsForm : Form
    {
        DataBaseModel db;
        public WatchCarsForm()
        {
            InitializeComponent();

            try
            {
                db = new DataBaseModel();
                dataGridView1.DataSource = db.har_avto.Select(x => new {
                    x.CarNum,
                    x.Firm,
                    x.Model,
                    x.Price,
                    x.Mileage,
                    x.Color,
                    СтрранаПроизводителя = x.Country,
                    x.Year,
                    x.EngineVolume,
                    x.Power,
                    x.FuelType, x.Status
                }).ToList();
            }
            catch (Exception err)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddCarForm f = new AddCarForm();
            f.ShowDialog();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var carNum = dataGridView1.SelectedCells[0].Value;
                var car = db.har_avto.FirstOrDefault(x => x.CarNum == carNum.ToString());
                if (car != null)
                {
                    if (car.CarImg != null)
                    {
                        using (var ms = new MemoryStream(car.CarImg))
                        {
                            pictureBox1.Image = Image.FromStream(ms);
                        }
                    } else
                    {
                        pictureBox1.Image = Image.FromFile(@"empty.png");
                    } 
                }
            }
            catch (Exception err)
            {

            }
            try
            {
                var carNum = dataGridView1.SelectedCells[0].Value;
                label1.Text = db.har_avto.FirstOrDefault(x => x.CarNum == carNum.ToString()).Description;

            }
            catch (Exception)
            {

            }

        }

        private void WatchCarsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
