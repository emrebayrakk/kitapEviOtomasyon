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
    public partial class Form4 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=NIRVANA;Initial Catalog=kitapevi;Integrated Security=True");

        public Form4()
        {
            InitializeComponent();
        }
        void DatagridYenile()
        {
          //  conn.Open();
            DataTable tbl = new DataTable();
            SqlDataAdapter adptr = new SqlDataAdapter("Select ISBN,ad,yazar,yayınevi,ytarihi,aciklama,fiyat from Kitaplar ", conn);
            adptr.Fill(tbl);
            conn.Close();
            dataGridView1.DataSource = tbl;
        }
        void kEkle()
        {
            //var tarih = dateTimePicker1.Value.ToShortDateString();
            conn.Open();
            SqlCommand kmt = new SqlCommand("Insert into  Kitaplar VALUES  ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" +textBox4.Text + "','" +textBox5.Text + "','" +textBox6.Text+ "','"+textBox7.Text+ "')", conn);
            kmt.ExecuteNonQuery();
            conn.Close();
        }
        void kSil()
        {
            conn.Open();
            SqlCommand kmt = new SqlCommand("DELETE  Kitaplar where ISBN=" + dataGridView1.CurrentRow.Cells["ISBN"].Value.ToString(), conn);
            kmt.ExecuteNonQuery();
            conn.Close();
            DatagridYenile();
        }
        void kGüncelle()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            kEkle();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kSil();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DatagridYenile();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
           conn.Open();
            SqlCommand komut = new SqlCommand("update Kitaplar set ad='" + textBox2.Text + "',yazar='" + textBox3.Text + "',yayınevi='" + textBox4.Text + "',ytarihi='" + textBox5.Text + "',aciklama='" + textBox6.Text + "',fiyat='" + textBox7.Text + "' WHERE ISBN='" + textBox1.Text + "'", conn);
            komut.ExecuteNonQuery();
            DatagridYenile();
            //conn.Close();
        }
    }
}
