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
    public partial class detayliListele : Form
    {
        public detayliListele()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        NpgsqlConnection baglantiAdresi = new NpgsqlConnection("server=localHost; port=5432; database=TekstilFirmasi; user ID=postgres; password=klmngh3746");
        private void button1_Click(object sender, EventArgs e)
        {
            baglantiAdresi.Open();
            if (comboBox1.Text=="Dikim Elemanları")
            {

                //sigorta türü falan eklemedin la adamlara düz direk geçirdin hemen
                string sorgu = "select \"firma\".\"personel\".\"personelId\" as \"Personel ID\","+
                "\"firma\".\"personel\".\"ad\" as \"İsim\", "+
                "\"firma\".\"personel\".\"soyad\" as \"Soyisim\","+
                "\"firma\".\"personel\".\"departmanNo\" as\"Çalıştığı yer\","+
                "\"firma\".\"personel\".\"telNo\" as \"Telefon\","+
                "\"firma\".\"sigortaBilgisi\".\"maas\" as \"Maaş\","+
                "\"firma\".\"sigortaBilgisi\".\"sigortaTuru\" as \"Sigorta Türü\","+
                "\"firma\".\"sigortaBilgisi\".\"isBaslangici\" as \"İş başlangıcı\","+
                "\"firma\".\"dikimElemani\".\"kullanilanMakine\" as \"Sıra No\","+
                "\"firma\".\"dikimElemani\".\"makineTipi\" as \"Çalıştığı Makine Tipi\""+
                "from \"firma\".\"personel\""+
                "inner join \"firma\".\"dikimElemani\" on \"firma\".\"personel\".\"personelId\"=\"firma\".\"dikimElemani\".\"personelNo\""+
                "inner join \"firma\".\"sigortaBilgisi\" on \"firma\".\"personel\".\"personelId\"=\"firma\".\"sigortaBilgisi\".\"personelNo\";";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglantiAdresi);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if(comboBox1.Text == "Paketleme Elemanları")
            {
                string sorgu = "select \"firma\".\"personel\".\"personelId\" as \"Personel ID\","+
                "\"firma\".\"personel\".\"ad\" as \"İsim\", "+
                "\"firma\".\"personel\".\"soyad\" as \"Soyisim\","+
                "\"firma\".\"personel\".\"departmanNo\" as\"Çalıştığı yer\","+
                "\"firma\".\"personel\".\"telNo\" as \"Telefon\","+
                "\"firma\".\"sigortaBilgisi\".\"maas\" as \"Maaş\","+
                "\"firma\".\"sigortaBilgisi\".\"sigortaTuru\" as \"Sigorta Türü\","+
                "\"firma\".\"sigortaBilgisi\".\"isBaslangici\" as \"İş başlangıcı\""+
                "from \"firma\".\"personel\""+
                "inner join \"firma\".\"paketlemeElemani\" on \"firma\".\"personel\".\"personelId\"=\"firma\".\"paketlemeElemani\".\"personelNo\""+
                "inner join \"firma\".\"sigortaBilgisi\" on \"firma\".\"personel\".\"personelId\"=\"firma\".\"sigortaBilgisi\".\"personelNo\";";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglantiAdresi);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.Text == "Kesim Elemanları")
            {
                string sorgu = "select \"firma\".\"personel\".\"personelId\" as \"Personel ID\", \"firma\".\"personel\".\"ad\" as \"İsim\", "+ 
                "\"firma\".\"personel\".\"soyad\" as \"Soyisim\", \"firma\".\"personel\".\"departmanNo\" as\"Çalıştığı yer\", "+
                "\"firma\".\"personel\".\"telNo\" as \"Telefon\", \"firma\".\"sigortaBilgisi\".\"maas\" as \"Maaş\", "+
                "\"firma\".\"sigortaBilgisi\".\"sigortaTuru\" as \"Sigorta Türü\",  \"firma\".\"sigortaBilgisi\".\"isBaslangici\" as \"İş başlangıcı\", "+
                "\"firma\".\"kesimmElemani\".\"kullanilanMasa\" as \"Sıra No\",  \"firma\".\"kesimmElemani\".\"kumasTuru\" as \"Kesim kumaşı\" "+
                "from \"firma\".\"personel\""+
                "inner join \"firma\".\"kesimmElemani\" on \"firma\".\"personel\".\"personelId\"=\"firma\".\"kesimmElemani\".\"personelNo\""+
                "inner join \"firma\".\"sigortaBilgisi\" on \"firma\".\"personel\".\"personelId\"=\"firma\".\"sigortaBilgisi\".\"personelNo\";";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglantiAdresi);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.Text == "Ofis Elemanları")
            {
                string sorgu = "select \"firma\".\"personel\".\"personelId\" as \"Personel ID\","+
                "\"firma\".\"personel\".\"ad\" as \"İsim\", "+
                "\"firma\".\"personel\".\"soyad\" as \"Soyisim\","+
                "\"firma\".\"personel\".\"departmanNo\" as\"Çalıştığı yer\","+
                "\"firma\".\"personel\".\"telNo\" as \"Telefon\","+
                "\"firma\".\"sigortaBilgisi\".\"maas\" as \"Maaş\","+
                "\"firma\".\"sigortaBilgisi\".\"sigortaTuru\" as \"Sigorta Türü\","+
                "\"firma\".\"sigortaBilgisi\".\"isBaslangici\" as \"İş başlangıcı\","+
                "\"firma\".\"ofisElemani\".\"isTuru\" as \"iş\""+
                "from \"firma\".\"personel\""+
                "inner join \"firma\".\"ofisElemani\" on \"firma\".\"personel\".\"personelId\"=\"firma\".\"ofisElemani\".\"personelNo\""+
                "inner join \"firma\".\"sigortaBilgisi\" on \"firma\".\"personel\".\"personelId\"=\"firma\".\"sigortaBilgisi\".\"personelNo\";";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglantiAdresi);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.Text == "Yönetim Elemanları")
            {
                string sorgu = "select \"firma\".\"personel\".\"personelId\" as \"Personel ID\","+
                "\"firma\".\"personel\".\"ad\" as \"İsim\", "+
                "\"firma\".\"personel\".\"soyad\" as \"Soyisim\","+
                "\"firma\".\"personel\".\"departmanNo\" as\"Çalıştığı yer\","+
                "\"firma\".\"personel\".\"telNo\" as \"Telefon\","+
                "\"firma\".\"sigortaBilgisi\".\"maas\" as \"Maaş\","+
                "\"firma\".\"sigortaBilgisi\".\"sigortaTuru\" as \"Sigorta Türü\","+
                "\"firma\".\"sigortaBilgisi\".\"isBaslangici\" as \"İş başlangıcı\","+
                "\"firma\".\"yonetimElemani\".\"yoneticiTpi\" as \"Yönetilen\","+
                "\"firma\".\"yonetimElemani\".\"departmanNo\" as \"Çalışılan yer\""+
                "from \"firma\".\"personel\""+
                "inner join \"firma\".\"yonetimElemani\" on \"firma\".\"personel\".\"personelId\"=\"firma\".\"yonetimElemani\".\"personelNo\""+
                "inner join \"firma\".\"sigortaBilgisi\" on \"firma\".\"personel\".\"personelId\"=\"firma\".\"sigortaBilgisi\".\"personelNo\";";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglantiAdresi);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            baglantiAdresi.Close();
        }
    }
}
