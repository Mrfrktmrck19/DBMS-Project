using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
namespace FormDeneme1
{
    public partial class Form1 : Form
    {
        NpgsqlConnection baglantiAdresi = new NpgsqlConnection("server=localHost; port=5432; database=TekstilFirmasi; user ID=postgres; password=klmngh3746");
        
        public Form1()
        {
            InitializeComponent();
             this.IsMdiContainer =true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Listele_Click(object sender, EventArgs e)
        {
            
            string sorgu = "select * from \"firma\".\"listele\"();";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglantiAdresi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {


            int a = int.Parse(textBox1.Text);
            string sorgu = "SELECT* FROM \"firma\".\"personelara\"("+a+")";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglantiAdresi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ekle PersonelEkle = new ekle();
            PersonelEkle.Show();
        }

        private void detayliListele_Click(object sender, EventArgs e)
        {
            detayliListele listele = new detayliListele();
            listele.Show();
        }

        private void Kaldir_Click(object sender, EventArgs e)
        {
            baglantiAdresi.Open();
           string sorgu = "select * from firma.kaldir(:id);";
            NpgsqlCommand da = new NpgsqlCommand(sorgu, baglantiAdresi);
            da.Parameters.AddWithValue("id", int.Parse(textBox2.Text));
            MessageBox.Show("Başarıyla Kaldırıldı.");


            da.ExecuteNonQuery();
            baglantiAdresi.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            guncelle gunc = new guncelle();
            gunc.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isYap iss = new isYap();
            iss.Show();
        }
    }
}
