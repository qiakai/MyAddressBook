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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strCon = "Data Source = SKY-20180703WKL\\MSSQLSERVERAAA;Initial Catalog = addressbook;User ID = sa;Password = 996714;Integrated Security = true";
            SqlConnection conn = new SqlConnection(strCon);
            conn.Open();
            if (textBox5.Text=="" && textBox6.Text=="")
            {
                MessageBox.Show("姓名和电话不能同时为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else
            {
                String sSQL = "select * from Table_1 where(姓名='" + textBox5.Text + "')";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    textBox1.Text = reader["姓名"].ToString();
                    textBox2.Text = reader["电话"].ToString();
                    textBox3.Text = reader["居住地址"].ToString();
                    textBox4.Text = reader["工作单位"].ToString();
                    textBox8.Text = reader["生日"].ToString();
                    textBox7.Text = reader["性别"].ToString();
                }
            }
            conn.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 fm1 = new Form1();
            fm1.Show();
            //this.Visible = false;
        }
    }
}
