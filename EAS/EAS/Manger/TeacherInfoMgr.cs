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

namespace EAS.Manger
{
    public partial class TeacherInfoMgr : Form
    {
        public TeacherInfoMgr()
        {
            InitializeComponent();
            QueryAllTeacher();
            DataBase db = new DataBase();
            try
            {
                MySqlDataReader reader = db.select("select d_name from department");
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetString(0));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("出现错误！" + ex.Message);
            }
            finally
            {
                if (db.conn != null)
                {
                    db = null;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }
        private void QueryAllTeacher()
        {
            DataBase db = new DataBase();
            try
            {
                string sql = "select * from teacher";
                //创建SqlDataAdapter类的对象
                MySqlDataAdapter sda = new MySqlDataAdapter(sql, db.conn);
                //创建DataSet类的对象
                DataSet ds = new DataSet();
                //使用SqlDataAdapter对象sda将查新结果填充到DataSet对象ds中
                sda.Fill(ds);
                //设置表格控件的DataSource属性
                dataGridView1.DataSource = ds.Tables[0];
                //设置数据表格上显示的列标题
                dataGridView1.Columns[0].HeaderText = "教师号";
                dataGridView1.Columns[1].HeaderText = "姓名";
                dataGridView1.Columns[2].HeaderText = "学院";
                //设置数据表格为只读
                dataGridView1.ReadOnly = true;
                //不允许添加行
                dataGridView1.AllowUserToAddRows = false;
                //背景为白色
                dataGridView1.BackgroundColor = Color.White;
                //只允许选中单行
                dataGridView1.MultiSelect = false;
                //整行选中
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询错误！" + ex.Message);
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

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("修改失败！");
                return;
            }
            DataBase db = new DataBase();
            try
            {
                string sql = "update teacher set t_name='{0}',d_name='{1}'  where s_id='{2}'";
                //填充占位符
                sql = string.Format(sql, textBox2.Text, comboBox1.Text, textBox1.Text);
                db.upgrade(sql);
                MessageBox.Show("修改成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改失败！" + ex.Message);
            }
            finally
            {
                if (db.conn != null)
                {
                    //关闭数据库连接
                    db = null;
                    QueryAllTeacher();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("添加失败！");
                return;
            }
            DataBase db = new DataBase();
            try
            {
                string sql = "insert into teacher(t_id,t_name,d_name) values('{0}','{1}','{2}')";
                //填充占位符
                sql = string.Format(sql, textBox1.Text, textBox2.Text, comboBox1.Text);
                db.insert(sql);
                MessageBox.Show("添加成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加失败！" + ex.Message);
            }
            finally
            {
                if (db.conn != null)
                {
                    //关闭数据库连接
                    db = null;
                    QueryAllTeacher();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            //int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            DataBase db = new DataBase();
            try
            {
                string sql = "delete from teacher where t_id='{0}'";
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
                    QueryAllTeacher();
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "" || textBox6.Text != "")
            {
                DataBase db = new DataBase();
                try
                {
                    string sql = "";
                    if (textBox5.Text != "")
                    {
                        if (textBox6.Text == "")
                        {
                            sql = "select * from teacher where t_id like '%{0}%'";
                            sql = string.Format(sql, textBox5.Text);
                        }
                        else
                        {
                            sql = "select * from teacher where t_id like '%{0}%' and t_name like '%{1}%'";
                            sql = string.Format(sql, textBox5.Text,textBox6.Text);
                        }
                    }
                    else if (textBox6.Text != "")
                    {
                        sql = "select * from teacher where t_name like '%{0}%'";
                        sql = string.Format(sql, textBox6.Text);
                    }
                    //创建SqlDataAdapter类的对象
                    MySqlDataAdapter sda = new MySqlDataAdapter(sql, db.conn);
                    //创建DataSet类的对象
                    DataSet ds = new DataSet();
                    //使用SqlDataAdapter对象sda将查新结果填充到DataSet对象ds中
                    sda.Fill(ds);
                    //设置表格控件的DataSource属性
                    dataGridView1.DataSource = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("出现错误！" + ex.Message);
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
            else
            {
                QueryAllTeacher();
            }
        }
    }
}
