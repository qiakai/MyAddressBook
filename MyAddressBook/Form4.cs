using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAddressBook
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            panel2.Visible = true;
            if (textBox12.Text == "")
            {
                button3.Enabled = button4.Enabled = false;
            }
            panel1.BackColor = Color.DarkSeaGreen;
        }

        //默认图片地址
        String picloa = "F:\\360MoveData\\Users\\Administrator\\Pictures\\tongxunlu.png";

        //添加个人信息
        private void button1_Click(object sender, EventArgs e)
        {
            string strCon = "Data Source = SKY-20180703WKL\\MSSQLSERVERAAA;Initial Catalog = addressbook;User ID = sa;Password = 996714;Integrated Security = true";
            SqlConnection conn = new SqlConnection(strCon);
            conn.Open();

            String born = comboBox1.Text.ToString() + "-" + comboBox2.Text.ToString() + "-" + comboBox3.Text.ToString();
            String sex = "保密";
            if (radioButton1.Checked == true)
            {
                sex = radioButton1.Text;
            }
            else if(radioButton2.Checked == true)
            {
                sex = radioButton2.Text;
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("姓名不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("电话不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            String sSQL = "insert into Table_1 values('" + textBox1.Text + "','" + born + "','" + sex + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox2.Text + "','"+picloa+"')";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            int iRet = cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("添加成功");
        }

        //查询个人信息
        private void button2_Click(object sender, EventArgs e)
        {
            
            string strCon = "Data Source = SKY-20180703WKL\\MSSQLSERVERAAA;Initial Catalog = addressbook;User ID = sa;Password = 996714;Integrated Security = true";
            SqlConnection conn = new SqlConnection(strCon);
            conn.Open();
            if (textBox5.Text == "")
            {
                MessageBox.Show("姓名不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else
            {
                String sSQL = "select * from Table_1 where(姓名='" + textBox5.Text + "')";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    textBox12.Text = reader["姓名"].ToString();
                    textBox11.Text = reader["电话"].ToString();
                    textBox10.Text = reader["居住地址"].ToString();
                    textBox9.Text = reader["工作单位"].ToString();
                    textBox8.Text = reader["生日"].ToString();
                    textBox7.Text = reader["性别"].ToString();
                    picloa = reader["头像"].ToString();
                    if (picloa == "NULL")
                    {
                        picloa = "F:\\360MoveData\\Users\\Administrator\\Pictures\\tongxunlu.png";
                    }
                    else
                    {
                        picloa = picloa.Replace(@"\", @"\\");
                        //MessageBox.Show(str);
                    }
                    pictureBox3.Image = Image.FromFile(picloa);
                    button3.Enabled = button4.Enabled = true;
                }
                else
                {
                    MessageBox.Show("查无此人", "错误", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
            conn.Close();
        }

        //修改个人信息
        private void button3_Click(object sender, EventArgs e)
        {
            string strCon = "Data Source = SKY-20180703WKL\\MSSQLSERVERAAA;Initial Catalog = addressbook;User ID = sa;Password = 996714;Integrated Security = true";
            SqlConnection conn = new SqlConnection(strCon);
            conn.Open();

            String sSQL = "update Table_1 set 姓名='" + textBox12.Text + "',头像='"+ picloa + "',电话='" + textBox11.Text + "',居住地址='" + textBox10.Text + "',工作单位='" + textBox9.Text + "',生日='" + textBox8.Text + "',性别='" + textBox7.Text + "' where(姓名='" + textBox12.Text + "')";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            int iRet = cmd.ExecuteNonQuery();
            conn.Close();
            //MessageBox.Show(picloa);
            MessageBox.Show("修改成功");
        }

        //跳转到查询页面
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        //跳转到添加页面，且添加页面内容清零，并默认头像
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = comboBox1.Text = comboBox2.Text = comboBox3.Text = "";
            radioButton1.Checked = radioButton2.Checked = false;
            pictureBox4.Image = Image.FromFile("F:\\360MoveData\\Users\\Administrator\\Pictures\\tongxunlu.png");
        }
        
        //删除个人数据
        private void button4_Click(object sender, EventArgs e)
        {
            string strCon = "Data Source = SKY-20180703WKL\\MSSQLSERVERAAA;Initial Catalog = addressbook;User ID = sa;Password = 996714;Integrated Security = true";
            SqlConnection conn = new SqlConnection(strCon);
            conn.Open();
            String sSQL = "delete from Table_1 where(姓名='" + textBox12.Text + "')";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            int iRet = cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("删除成功");
            pictureBox3.Image = Image.FromFile("F:\\360MoveData\\Users\\Administrator\\Pictures\\tongxunlu.png");
            textBox12.Text = textBox11.Text = textBox10.Text = textBox9.Text = textBox8.Text = textBox7.Text = textBox5.Text = "";
        }

        //查询所有人信息（姓名和电话）
        private void button5_Click(object sender, EventArgs e)
        {
            string strCon = "Data Source = SKY-20180703WKL\\MSSQLSERVERAAA;Initial Catalog = addressbook;User ID = sa;Password = 996714;Integrated Security = true";
            SqlConnection conn = new SqlConnection(strCon);
            conn.Open();
            String sSQL = "select * from Table_1";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            String rtext="";
            while (reader.Read()) {
                rtext += reader["姓名"].ToString() + "\t" + reader["电话"].ToString() + "\n";
            }
            richTextBox1.Text = rtext;
        }

        //查询页面修改个人头像
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();  //选择图片文件窗体
            ofd.Title = "选择要上传的图片";  //窗体抬头
            ofd.Filter = "位图(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|图片(*.png)|*.png|All Files(*.*)|*.*"; //选择文件格式（在打开窗体中以下拉列表方式筛选）
            if (ofd.ShowDialog(this) == DialogResult.OK)//打开窗体，并且点击确定按钮后触发
            {
                Image newImage = Image.FromFile(ofd.FileName);//获取图片文件，ofd.FileName获取路径
                if (!File.Exists(ofd.FileName))//判断路径
                {
                    MessageBox.Show("照片为空");
                    return;
                }
                else
                {
                    pictureBox3.Image = newImage;
                    picloa = ofd.FileName;
                    //MessageBox.Show(picloa);//把PictrueBox路径显示出来
                }
            }
        }

        //添加页面添加个人头像
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();  //选择图片文件窗体
            ofd.Title = "选择要上传的图片";  //窗体抬头
            ofd.Filter = "位图(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|图片(*.png)|*.png|All Files(*.*)|*.*"; //选择文件格式（在打开窗体中以下拉列表方式筛选）
            if (ofd.ShowDialog(this) == DialogResult.OK)//打开窗体，并且点击确定按钮后触发
            {
                Image newImage = Image.FromFile(ofd.FileName);//获取图片文件，ofd.FileName获取路径
                if (!File.Exists(ofd.FileName))//判断路径
                {
                    MessageBox.Show("照片为空");
                    return;
                }
                else
                {
                    pictureBox4.Image = newImage;
                    picloa = ofd.FileName;
                    //MessageBox.Show(picloa);//把PictrueBox路径显示出来
                }
            }
        }

        //关闭窗体
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //清空窗体内容，头像默认
        private void button7_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = comboBox1.Text = comboBox2.Text = comboBox3.Text = "";
            radioButton1.Checked = radioButton2.Checked = false;
            pictureBox3.Image = pictureBox4.Image = Image.FromFile("F:\\360MoveData\\Users\\Administrator\\Pictures\\tongxunlu.png");
            textBox12.Text = textBox11.Text = textBox10.Text = textBox9.Text = textBox8.Text = textBox7.Text = textBox5.Text = "";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
