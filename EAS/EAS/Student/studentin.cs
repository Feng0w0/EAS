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
namespace EAS.Student
{
    public partial class studentin : Form
    {
        private string number;
        public studentin(string number)
        {
            this.number = number;
            InitializeComponent();
        }

        private void studentin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            string sql = "";
            sql = "select * from student where s_id like '%{0}%'";
            sql = string.Format(sql, this.number);
            //创建SqlDataAdapter类的对象
            MySqlDataAdapter sda = new MySqlDataAdapter(sql, db.conn);
            //创建DataSet类的对象
            DataSet ds = new DataSet();
           
            //使用SqlDataAdapter对象sda将查新结果填充到DataSet对象ds中
            sda.Fill(ds);
            //设置表格控件的DataSource属性
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].HeaderText = "学号";
            dataGridView1.Columns[1].HeaderText = "姓名";
            dataGridView1.Columns[2].HeaderText = "学院";
            dataGridView1.Columns[3].HeaderText = "班级";
            dataGridView1.Columns[4].HeaderText = "总学分";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            string sql = "";
            sql = "select * from take where s_id like '%{0}%'";
            sql = string.Format(sql, this.number);
            //创建SqlDataAdapter类的对象
            MySqlDataAdapter sda = new MySqlDataAdapter(sql, db.conn);
            //创建DataSet类的对象
            DataSet ds = new DataSet();
            //使用SqlDataAdapter对象sda将查新结果填充到DataSet对象ds中
            sda.Fill(ds);
            //设置表格控件的DataSource属性
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].HeaderText = "课程号";
            dataGridView1.Columns[1].HeaderText = "学号";
            dataGridView1.Columns[2].HeaderText = "分数";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            string sql = "";
            sql = "select * from take where s_id like '%{0}%' and grade!=0";
            sql = string.Format(sql, this.number);
            //创建SqlDataAdapter类的对象
            MySqlDataAdapter sda = new MySqlDataAdapter(sql, db.conn);
            //创建DataSet类的对象
            DataSet ds = new DataSet();
            //使用SqlDataAdapter对象sda将查新结果填充到DataSet对象ds中
            sda.Fill(ds);
            //设置表格控件的DataSource属性
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
