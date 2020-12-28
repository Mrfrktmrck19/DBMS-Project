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
    public partial class ekle : Form
    {
        NpgsqlConnection baglantiAdresi = new NpgsqlConnection("server=localHost; port=5432; database=TekstilFirmasi; user ID=postgres; password=klmngh3746");

        public ekle()
        {
            InitializeComponent();
        }
        
        private void ekle_Load(object sender, EventArgs e)
        {

        }
        
        /// <summary>
        /// iş alanı butonuna tıklayınca sectionlar açılıyor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            veriTabaninaEkle.Visible = true;
            button2.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            button1.Enabled = true;

            if(comboBox1.Text== "Dikim Elemanları")
            {
                label5.Visible = true;
                label6.Visible = true;
                comboBox2.Visible = true;
                textBox3.Visible = true;
                label5.Text = "Kullanılan makine türü:";
                label6.Text = "Kullanacağı makine sıra no:";
                comboBox2.Items.Clear();
                comboBox2.Items.Add(1);
                comboBox2.Items.Add(2);
                comboBox2.Items.Add(3);
                comboBox2.Items.Add(4);
                comboBox2.Items.Add(5);
            }
            else if(comboBox1.Text == "Paketleme Elemanları")
            {
                label5.Visible = false;
                label6.Visible = false;
                comboBox2.Visible = false;
                textBox3.Visible = false;
            }
            else if (comboBox1.Text == "Kesim Elemanları")
            {
                label5.Visible = true;
                label6.Visible = true;
                comboBox2.Visible = true;
                textBox3.Visible = true;

                comboBox2.Items.Clear();
                comboBox2.Items.Add(1);
                comboBox2.Items.Add(2);
                comboBox2.Items.Add(3);
                comboBox2.Items.Add(4);
                comboBox2.Items.Add(5);
                comboBox2.Items.Add(6);

                label5.Text = "Uzmanı olduğu kumaş:";
                label6.Text = "Kesim masası sıra no:";
            }
            else if (comboBox1.Text == "Ofis Elemanları")
            {
                label6.Text = "İş türü:";
                label6.Visible = true;
                textBox3.Visible = true;
                comboBox2.Visible = false;
                label5.Visible = false;
            }
            else if (comboBox1.Text == "Yönetim Elemanları")
            {
                textBox3.Visible = false;
                label6.Visible = false;
                label5.Text = "Departman:";
                label5.Visible = true;
                comboBox2.Visible = true;

                comboBox2.Items.Clear();
                comboBox2.Items.Add(1);
                comboBox2.Items.Add(2);
                comboBox2.Items.Add(3);
            }
        }

        NpgsqlCommand cmd = new NpgsqlCommand();
        /// <summary>
        /// ilk ekle butonum, personel ve sigorta tablosu ekleyecek sadece 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void veriTabaninaEkle_Click_1(object sender, EventArgs e)
        {
            int counter = 13;
            baglantiAdresi.Open();
            string sorgu = "call firma.personelekle(:id,:ad,:soyad,:telNo,:departmanNo)";
            
            cmd = new NpgsqlCommand(sorgu,baglantiAdresi);
            cmd.Parameters.AddWithValue("id", counter);
            cmd.Parameters.AddWithValue("ad", textBox1.Text);
            cmd.Parameters.AddWithValue("soyad", textBox2.Text);
            cmd.Parameters.AddWithValue("telNo", textBox4.Text);


            if (comboBox1.Text == "Dikim Elemanları")
                cmd.Parameters.AddWithValue("departmanNo", 3);
            else if (comboBox1.Text == "Paketleme Elemanları")
                cmd.Parameters.AddWithValue("departmanNo", 3);
            else if (comboBox1.Text == "Kesim Elemanları")
                cmd.Parameters.AddWithValue("departmanNo", 2);
            else if (comboBox1.Text == "Ofis Elemanları")
                cmd.Parameters.AddWithValue("departmanNo", 1);
            else if (comboBox1.Text == "Yönetim Elemanları")
                cmd.Parameters.AddWithValue("departmanNo", 1);
            cmd.ExecuteNonQuery();

            
            sorgu = "select * from firma.sigortaekle(:id,:isbasi,:maas,:sigortaturu)";
            cmd = new NpgsqlCommand(sorgu, baglantiAdresi);
            cmd.Parameters.AddWithValue("id", counter);
            cmd.Parameters.AddWithValue("isbasi", textBox5.Text.ToString());
            cmd.Parameters.AddWithValue("maas", int.Parse(textBox7.Text));
            cmd.Parameters.AddWithValue("sigortaturu", textBox6.Text.ToString());
            cmd.ExecuteNonQuery();

            baglantiAdresi.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglantiAdresi.Open();
            if (comboBox1.Text == "Dikim Elemanları")
             {
                 string sorguDikim = "select * from firma.dikimelemaniekle(:id,:tip,:yer);";
                 NpgsqlCommand cmdDikim = new NpgsqlCommand(sorguDikim, baglantiAdresi);

                 cmdDikim.Parameters.AddWithValue("id", 13);
                 cmdDikim.Parameters.AddWithValue("tip", int.Parse(comboBox2.Text));
                 cmdDikim.Parameters.AddWithValue("yer", int.Parse(textBox3.Text));

                 cmdDikim.ExecuteNonQuery();
             }
             else if (comboBox1.Text == "Paketleme Elemanları")
             {
                int counter = 13;
                string sorguPaketelme = "insert into \"firma\".\"paketlemeElemani\" (\"personelNo\") values ("+counter+");";
                NpgsqlCommand cmdPAketleme = new NpgsqlCommand(sorguPaketelme, baglantiAdresi);


                cmdPAketleme.ExecuteNonQuery();
             }
             else if (comboBox1.Text == "Kesim Elemanları")
             {

                int counter = 13;
                string sorguKesim = "insert into \"firma\".\"kesimmElemani\" (\"personelNo\",\"kullanilanMasa\",\"kumasTuru\") values (" + counter + ","+int.Parse(textBox3.Text)+","+int.Parse(comboBox2.Text)+" );";
                NpgsqlCommand cmdKesim= new NpgsqlCommand(sorguKesim, baglantiAdresi);


                cmdKesim.ExecuteNonQuery();
            }
             else if (comboBox1.Text == "Ofis Elemanları")
             {
                int counter = 13;
                string sorguOfis = "insert into \"firma\".\"ofisElemani\" (\"personelNo\",\"isTuru\") values (" + counter + "," + int.Parse(textBox3.Text) + " );";
                NpgsqlCommand cmdOfis = new NpgsqlCommand(sorguOfis, baglantiAdresi);
                cmdOfis.ExecuteNonQuery();
            }
             else if (comboBox1.Text == "Yönetim Elemanları")
             {
                int counter = 13;
                string sorguOfis = "insert into \"firma\".\"yonetimElemani\" (\"personelNo\",\"departmanNo\") values (" + counter + "," + int.Parse(comboBox2.Text) + " );";
                NpgsqlCommand cmdOfis = new NpgsqlCommand(sorguOfis, baglantiAdresi);
                cmdOfis.ExecuteNonQuery();
            }
            baglantiAdresi.Close();
            MessageBox.Show("Başarıyla Eklendi!");
        }
       
    }
}
