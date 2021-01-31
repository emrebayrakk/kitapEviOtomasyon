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
    public partial class Form1 : Form
    {
        
        SqlConnection baglanti = new SqlConnection("Data Source=NIRVANA;Initial Catalog=kitapevi;Integrated Security=True");
        
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            
            try
            {
                baglanti.Open();
                String sql = "select ad,soyad,parola from uyeler where ad=@ad and soyad=@soyad and parola=@parola";
                SqlParameter ad = new SqlParameter("ad", textBox1.Text.Trim());
                SqlParameter soyad = new SqlParameter("soyad", textBox2.Text.Trim());
                SqlParameter parola = new SqlParameter("parola", textBox3.Text.Trim());
                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.Parameters.Add(ad);
                komut.Parameters.Add(soyad);
                komut.Parameters.Add(parola);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(komut);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Form5 trm = new Form5();
                    trm.Show();
                    this.Hide();
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı Giriş");
            }
              
          // Form5 gec = new Form5();
           // gec.Show();
           // Hide();
            
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form3 forum = new Form3();
            forum.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
