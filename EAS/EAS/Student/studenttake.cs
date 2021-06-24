﻿using System;
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
    public partial class studenttake : Form
    {
        private string number;
        public studenttake(string number)
        {
            this.number = number;
            InitializeComponent();
        }

        private void studenttake_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)    //所有课程
            {
                DataBase db = new DataBase();
                string sql = "";
                sql = "select * from course";
                //创建SqlDataAdapter类的对象
                MySqlDataAdapter sda = new MySqlDataAdapter(sql, db.conn);
                //创建DataSet类的对象
                DataSet ds = new DataSet();
                //使用SqlDataAdapter对象sda将查新结果填充到DataSet对象ds中
                sda.Fill(ds);
                //设置表格控件的DataSource属性
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                DataBase db = new DataBase();
                string sql = "";
                sql = "select *from course where d_name =(select d_name from student where s_id like '%{0}%')";
                sql = string.Format(sql, this.number);
                sql = "select * from course";
                //创建SqlDataAdapter类的对象
                MySqlDataAdapter sda = new MySqlDataAdapter(sql, db.conn);
                //创建DataSet类的对象
                DataSet ds = new DataSet();
                //使用SqlDataAdapter对象sda将查新结果填充到DataSet对象ds中
                sda.Fill(ds);
                //设置表格控件的DataSource属性
                dataGridView1.DataSource = ds.Tables[0];
            }
            this.button3.Visible = false;
            this.button4.Visible = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            string sql = "";
            sql = "select * from take where s_id like '%{0}%' and grade=0";
            sql = string.Format(sql, this.number);
            //创建SqlDataAdapter类的对象
            MySqlDataAdapter sda = new MySqlDataAdapter(sql, db.conn);
            //创建DataSet类的对象
            DataSet ds = new DataSet();
            //使用SqlDataAdapter对象sda将查新结果填充到DataSet对象ds中
            sda.Fill(ds);
            //设置表格控件的DataSource属性
            dataGridView1.DataSource = ds.Tables[0];
            this.button4.Visible = false;
            this.button3.Visible = true;

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            DataBase db = new DataBase();
            try
            {
                string sql = "delete from take where c_id='{0}'";
                //填充占位符
                sql = string.Format(sql, id);
                db.delete(sql);
                MessageBox.Show("删除成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除失败！" + ex.Message);
            }
            finally
            {
                if (db.conn != null)
                {
                    //关闭数据库连接
                    db = null;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            DataBase db = new DataBase();
            try
            {
                string sql = "insert into take(c_id,s_id,grade) values('{0}','{1}','0')";
                //填充占位符
                sql = string.Format(sql, id,this.number);
                db.insert(sql);
                MessageBox.Show("选课成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("选课失败！" + ex.Message);
            }
            finally
            {
                if (db.conn != null)
                {
                    //关闭数据库连接
                    db = null;
                }
            }
        }
    }
}
