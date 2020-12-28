using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Npgsql;
namespace FormDeneme1
{
    public partial class guncelle : Form
    {
        public guncelle()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        NpgsqlConnection baglantiAdresi = new NpgsqlConnection("server=localHost; port=5432; database=TekstilFirmasi; user ID=postgres; password=klmngh3746");

        private void button1_Click(object sender, EventArgs e)
        {
            baglantiAdresi.Open();
            string sorgu = "select * from firma.guncelle("+ int.Parse(textBox1.Text)+",\'" + textBox2.Text.ToString()+ "\',\'" + textBox3.Text.ToString()+ "\')";
            NpgsqlCommand cmdGuncelle = new NpgsqlCommand(sorgu, baglantiAdresi);

            cmdGuncelle.ExecuteNonQuery();
            baglantiAdresi.Close();

            MessageBox.Show("Başarıyla Güncellendi!");
        }
    }
}
