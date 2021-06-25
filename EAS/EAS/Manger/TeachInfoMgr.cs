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
    public partial class TeachInfoMgr : Form
    {
        public TeachInfoMgr()
        {
            InitializeComponent();
            QueryAllTeach();
            QueryAllCourse();
            QueryAllTeacher();
        }

       
        private void QueryAllCourse()
        {
            DataBase db = new DataBase();
            try
            {
                string sql = "select * from course";
                //创建SqlDataAdapter类的对象
                MySqlDataAdapter sda = new MySqlDataAdapter(sql, db.conn);
                //创建DataSet类的对象
                DataSet ds = new DataSet();
                //使用SqlDataAdapter对象sda将查新结果填充到DataSet对象ds中
                sda.Fill(ds);
                //设置表格控件的DataSource属性
                dataGridView3.DataSource = ds.Tables[0];
                //设置数据表格上显示的列标题
                dataGridView3.Columns[0].HeaderText = "课程号";
                dataGridView3.Columns[1].HeaderText = "课程名";
                dataGridView3.Columns[2].HeaderText = "学院";
                dataGridView3.Columns[3].HeaderText = "学分";
                //设置数据表格为只读
                dataGridView3.ReadOnly = true;
                //不允许添加行
                dataGridView3.AllowUserToAddRows = false;
                //背景为白色
                dataGridView3.BackgroundColor = Color.White;
                //只允许选中单行
                dataGridView3.MultiSelect = false;
                //整行选中
                dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
                dataGridView2.DataSource = ds.Tables[0];
                //设置数据表格上显示的列标题
                dataGridView2.Columns[0].HeaderText = "教师号";
                dataGridView2.Columns[1].HeaderText = "姓名";
                dataGridView2.Columns[2].HeaderText = "学院";
                //设置数据表格为只读
                dataGridView2.ReadOnly = true;
                //不允许添加行
                dataGridView2.AllowUserToAddRows = false;
                //背景为白色
                dataGridView2.BackgroundColor = Color.White;
                //只允许选中单行
                dataGridView2.MultiSelect = false;
                //整行选中
                dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
        private void QueryAllTeach()
        {
            DataBase db = new DataBase();
            try
            {
                string sql = "select T.t_id,T.t_name,T.d_name,C.c_id,C.c_name,C.d_name,C.credit " +
                    "from teacher T inner join teach inner join course C " +
                    "on T.t_id=teach.t_id and teach.c_id=C.c_id;";
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
                dataGridView1.Columns[3].HeaderText = "课程号";
                dataGridView1.Columns[4].HeaderText = "课程名";
                dataGridView1.Columns[5].HeaderText = "开设学院";
                dataGridView1.Columns[6].HeaderText = "学分";
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
                string sql = "insert into teach(t_id,c_id) values('{0}','{1}')";
                //填充占位符
                sql = string.Format(sql, textBox1.Text, textBox3.Text);
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
                    QueryAllTeach();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string tid = textBox1.Text;
            string cid = textBox3.Text;
            //int tid = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            //int cid = int.Parse(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
            DataBase db = new DataBase();
            try
            {
                string sql = "delete from teach where c_id='{0}' and t_id='{1}'";
                //填充占位符
                sql = string.Format(sql, cid, tid);
                db.delete(sql);
                //MessageBox.Show("删除成功！");
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
                    QueryAllTeach();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                DataBase db = new DataBase();
                try
                {
                    string sql = "select * from teacher where t_name like '%{0}%'";
                    sql = string.Format(sql, textBox5.Text);
                    //创建SqlDataAdapter类的对象
                    MySqlDataAdapter sda = new MySqlDataAdapter(sql, db.conn);
                    //创建DataSet类的对象
                    DataSet ds = new DataSet();
                    //使用SqlDataAdapter对象sda将查新结果填充到DataSet对象ds中
                    sda.Fill(ds);
                    //设置表格控件的DataSource属性
                    dataGridView2.DataSource = ds.Tables[0];
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
            if (textBox6.Text != "")
            {
                DataBase db = new DataBase();
                try
                {
                    string sql = "select * from course where c_name like '%{0}%'";
                    sql = string.Format(sql, textBox6.Text);
                    //创建SqlDataAdapter类的对象
                    MySqlDataAdapter sda = new MySqlDataAdapter(sql, db.conn);
                    //创建DataSet类的对象
                    DataSet ds = new DataSet();
                    //使用SqlDataAdapter对象sda将查新结果填充到DataSet对象ds中
                    sda.Fill(ds);
                    //设置表格控件的DataSource属性
                    dataGridView3.DataSource = ds.Tables[0];
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
                QueryAllCourse();
            }
            if (textBox5.Text == "" && textBox6.Text == "") QueryAllTeach();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            DataBase db = new DataBase();
            try
            {
                string sql = "select T.t_id,T.t_name,T.d_name,C.c_id,C.c_name,C.d_name,C.credit " +
                    "from teacher T inner join teach inner join course C " +
                    "on T.t_id = teach.t_id and teach.c_id = C.c_id " +
                    "where T.t_id ={0};";
                sql = string.Format(sql, textBox1.Text);
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

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
            textBox4.Text = dataGridView3.SelectedRows[0].Cells[1].Value.ToString();
            DataBase db = new DataBase();
            try
            {
                string sql = "select T.t_id,T.t_name,T.d_name,C.c_id,C.c_name,C.d_name,C.credit " +
                    "from teacher T inner join teach inner join course C " +
                    "on T.t_id = teach.t_id and teach.c_id = C.c_id " +
                    "where C.c_id = {0};";
                sql = string.Format(sql, textBox3.Text);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }
    }
}
