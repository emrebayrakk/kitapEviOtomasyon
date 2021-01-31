using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace kitapci
{
    public partial class Form5 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=NIRVANA;Initial Catalog=kitapevi;Integrated Security=True");
        public Form5()
        {
            InitializeComponent();
        }
        void DatagridYenile()
        {
            baglanti.Open();
            DataTable tbl = new DataTable();
            SqlDataAdapter adptr = new SqlDataAdapter("Select * from Sepetbilgi ", baglanti);
            adptr.Fill(tbl);
            baglanti.Close();
            dataGridView3.DataSource = tbl;
        }
        void griddoldur()
        {

            SqlDataAdapter da = new SqlDataAdapter("Select ISBN,ad,yazar,yayınevi,ytarihi,aciklama,fiyat,kno,adi,bilgi,bastarih,bittarih From Kitaplar LEFT JOIN Kampanyalar  ON Kitaplar.ISBN!=Kampanyalar.kno", baglanti);
            DataSet ds = new DataSet();
            baglanti.Open();
            da.Fill(ds, "Kitaplar");
            dataGridView5.DataSource = ds.Tables["Kitaplar"];
            baglanti.Close();
        }
        void griddoldur2()
        {

            SqlDataAdapter da = new SqlDataAdapter("Select ISBN,ad,yazar,yayınevi,ytarihi,aciklama,fiyat,kno,adi,bilgi,bastarih,bittarih From Kitaplar Where aciklama='korku' LEFT JOIN Kampanyalar  ON Kitaplar.ISBN!=Kampanyalar.kno", baglanti);
            DataSet ds = new DataSet();
            baglanti.Open();
            da.Fill(ds, "Kitaplar");
            dataGridView5.DataSource = ds.Tables["Kitaplar"];
            baglanti.Close();
        }
        void griddoldur3()
        {

            SqlDataAdapter da = new SqlDataAdapter("Select ISBN,ad,yazar,yayınevi,ytarihi,aciklama,fiyat,kno,adi,bilgi,bastarih,bittarih From Kitaplar Where aciklama='gizem' LEFT JOIN Kampanyalar  ON Kitaplar.ISBN!=Kampanyalar.kno", baglanti);
            DataSet ds = new DataSet();
            baglanti.Open();
            da.Fill(ds, "Kitaplar");
            dataGridView5.DataSource = ds.Tables["Kitaplar"];
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ("Hepsi" == comboBox1.SelectedItem.ToString())
            {
                griddoldur();
            }
            else if ("Korku" == comboBox1.SelectedItem.ToString())
            {
                griddoldur2();
            }
            else if ("Gizem" == comboBox1.SelectedItem.ToString())
            {
                griddoldur3();
            }
            else if (null == comboBox1.SelectedItem.ToString())
            {
                MessageBox.Show("kategori seçiniz ");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 forum = new Form1();
            forum.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox5.Text);
            dataGridView4.Rows.Add(textBox4.Text, x / 2);

            


            baglanti.Open();
            SqlCommand kmt = new SqlCommand("Insert into  Sepet_bilgi VALUES  ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')", baglanti);
            kmt.ExecuteNonQuery();
            baglanti.Close();
            DatagridYenile();



            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView5.DataSource = null;

            baglanti.Open();
            SqlCommand kmt = new SqlCommand("DELETE  Sepet_bilgi where sepetid=" + dataGridView5.CurrentRow.Cells["sepetid"].Value.ToString(), baglanti);
            kmt.ExecuteNonQuery();
            baglanti.Close();
        }
    }
}
