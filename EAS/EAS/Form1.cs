using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace EAS
{
    public partial class Form1 : Form
    {
        public bool login = false;
        public string number;
        public int user = 0;    //1管理员，2学生，3教师
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //label1.Left = (this.ClientSize.Width - label1.Width) / 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入账号");
            }
            else if (radioButton1.Checked || radioButton2.Checked|| radioButton3.Checked)
            {
                string name = textBox1.Text.Trim();
                if (radioButton1.Checked)    //管理员被选中
                {
                    if (name == "root")
                    {
                        this.Close();
                        login = true;
                        number = "root";
                        user = 1;
                    }
                    else
                    {
                        MessageBox.Show("登陆失败！");
                        textBox1.Focus();   //用户名文本框获得输入光标焦点
                    }
                }
                else if (radioButton2.Checked)   //选择学生
                {
                    if (db.select("select * from student where s_id=" + name).Read())
                    {
                        this.Close();
                        login = true;
                        number = name;
                        user = 2;
                    }
                    else
                    {
                        MessageBox.Show("登录失败！");
                        textBox1.Focus();   //用户名文本框获得输入光标焦点
                    }
                }
                else if (radioButton3.Checked)   //选择学生
                {
                    if (db.select("select * from teacher where t_id=" + name).Read())
                    {
                        this.Close();
                        login = true;
                        number = name;
                        user = 3;
                    }
                    else
                    {
                        MessageBox.Show("登录失败！");
                        textBox1.Focus();   //用户名文本框获得输入光标焦点
                    }
                }
            }
            else  //都没有选中
            {
                MessageBox.Show("请选择登录身份");
            }
            db.close();
        }
    }
}
