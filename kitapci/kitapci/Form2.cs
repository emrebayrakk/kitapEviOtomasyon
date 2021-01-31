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
    public partial class Form2 : Form
    {
        Form1 frm1 = new Form1();
        SqlConnection con = new SqlConnection("Data Source=NIRVANA;Initial Catalog=kitapevi;Integrated Security=True");

        void DatagridYenile()
        {
            con.Open();
            DataTable tbl = new DataTable();
            SqlDataAdapter adptr = new SqlDataAdapter("Select * from Sepet_bilgi ", con);
            adptr.Fill(tbl);
            con.Close();
            dataGridView3.DataSource = tbl;
        }
        void griddoldur()
        {
           
            SqlDataAdapter da = new SqlDataAdapter("Select ISBN,ad,yazar,yayınevi,ytarihi,aciklama,fiyat From Kitaplar", con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds, "Kitaplar");
            dataGridView1.DataSource = ds.Tables["Kitaplar"];
            con.Close();
        }
        void griddoldur2()
        {
            
            SqlDataAdapter da = new SqlDataAdapter("Select ISBN,ad,yazar,yayınevi,ytarihi,aciklama,fiyat From Kitaplar Where aciklama='korku'", con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds, "Kitaplar");
            dataGridView1.DataSource = ds.Tables["Kitaplar"];
            con.Close();
        }
        void griddoldur3()
        {
            
            SqlDataAdapter da = new SqlDataAdapter("Select ISBN,ad,yazar,yayınevi,ytarihi,aciklama,fiyat From Kitaplar Where aciklama='gizem'", con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds, "Kitaplar");
            dataGridView1.DataSource = ds.Tables["Kitaplar"];
            con.Close();
        }
        public Form2()
        {
            InitializeComponent();
        }
       
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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

        private void Button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frm1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Add(textBox4.Text, textBox5.Text);
            
            
                /*con.Open();
                SqlCommand kmt = new SqlCommand("Insert into  Sepet_bilgi VALUES  ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')", con);
                kmt.ExecuteNonQuery();
                con.Close();
                DatagridYenile();*/
            
            
            
            textBox4.Text = "";
            textBox5.Text = "";





        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            dataGridView2.DataSource = null;

            con.Open();
            SqlCommand kmt = new SqlCommand("DELETE  Sepet_bilgi where sepetid=" + dataGridView1.CurrentRow.Cells["sepetid"].Value.ToString(), con);
            kmt.ExecuteNonQuery();
            con.Close();
        }
    }
}
