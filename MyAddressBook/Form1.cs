using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAddressBook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strCon = "Data Source = SKY-20180703WKL\\MSSQLSERVERAAA;Initial Catalog = addressbook;User ID = sa;Password = 996714;Integrated Security = true";
            SqlConnection conn = new SqlConnection(strCon);
            conn.Open();

            String born = comboBox1.Text.ToString() + "-" + comboBox2.Text.ToString() + "-" + comboBox3.Text.ToString();
            String sex = "男";
            if (radioButton1.Checked == true)
            {
                sex = radioButton1.Text;
            }
            else
            {
                sex = radioButton2.Text;
            }
            String sSQL = "insert into Table_1 values('"+textBox1.Text+"','"+born+"','"+sex+"','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox2.Text+"')";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            int iRet = cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2 fm2 = new Form2();
            fm2.Show();
            //this.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
