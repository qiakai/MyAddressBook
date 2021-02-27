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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            panel2.Visible = true;
            panel1.Visible = false;
        }
        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
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
            String sSQL = "insert into Table_1 values('" + textBox1.Text + "','" + born + "','" + sex + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox2.Text + "')";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            int iRet = cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strCon = "Data Source = SKY-20180703WKL\\MSSQLSERVERAAA;Initial Catalog = addressbook;User ID = sa;Password = 996714;Integrated Security = true";
            SqlConnection conn = new SqlConnection(strCon);
            conn.Open();
            if (textBox5.Text == "" && textBox6.Text == "")
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
                    textBox12.Text = reader["姓名"].ToString();
                    textBox11.Text = reader["电话"].ToString();
                    textBox10.Text = reader["居住地址"].ToString();
                    textBox9.Text = reader["工作单位"].ToString();
                    textBox8.Text = reader["生日"].ToString();
                    textBox7.Text = reader["性别"].ToString();
                }
            }
            conn.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
