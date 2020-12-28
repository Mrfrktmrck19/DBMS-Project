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
    public partial class isYap : Form
    {
        NpgsqlConnection baglantiAdresi = new NpgsqlConnection("server=localHost; port=5432; database=TekstilFirmasi; user ID=postgres; password=klmngh3746");

        public isYap()
        {
            InitializeComponent();
        }

        private void isYap_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           baglantiAdresi.Open();
            string sorgu = "select * from firma.issozlesmesiimzala(:id,:noo,:imza,:fiyat,:adett,:anlasma,:teslim)";
            NpgsqlCommand cmd = new NpgsqlCommand(sorgu, baglantiAdresi);
           
            cmd.Parameters.AddWithValue("id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("noo", int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("imza", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("fiyat", int.Parse(textBox6.Text));
            cmd.Parameters.AddWithValue("adett", int.Parse(textBox5.Text));
            cmd.Parameters.AddWithValue("anlasma", textBox4.Text.ToString());
            cmd.Parameters.AddWithValue("teslim", textBox7.Text.ToString());
            cmd.ExecuteNonQuery();

            string sorguu = "select* from firma.yapilanisekle(:id, :istur, :ipliktur, :kumastur, :iplazim, :kumaslazim)";
            NpgsqlCommand cmd2 = new NpgsqlCommand(sorguu, baglantiAdresi);

            cmd2.Parameters.AddWithValue("id", int.Parse(textBox1.Text));
            cmd2.Parameters.AddWithValue("istur", int.Parse(comboBox1.Text));
            cmd2.Parameters.AddWithValue("ipliktur", int.Parse(comboBox3.Text));
            cmd2.Parameters.AddWithValue("kumastur", int.Parse(comboBox2.Text));
            cmd2.Parameters.AddWithValue("iplazim", int.Parse(textBox8.Text));
            cmd2.Parameters.AddWithValue("kumaslazim", int.Parse(textBox9.Text));
            cmd2.ExecuteNonQuery();

            baglantiAdresi.Close();

            MessageBox.Show("Başarıyla Eklendi!");
        }
    }
}
