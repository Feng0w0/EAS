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

namespace EAS.teacher
{
    public partial class course : Form
    {
        private string number;
        public course(string number)
        {
            this.number = number;
            InitializeComponent();
            //label5.Text = number;
            QueryAllcourse();

        }

        private void course_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string cc;
            cc = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
             QueryAllstudent(cc);
            label4.Text = "";
            textBox2.Text = "";
            label10.Text = "";
            label1.Text = "";
            label13.Text = "";
            label8.Text = "";

        }
        private void QueryAllcourse()
        {
            DataBase db = new DataBase();
            try
            {
                string sql = "select * from course where course.c_id in (select teach.c_id from teach where teach.t_id='{0}')";
                sql = string.Format(sql, number);
                //创建SqlDataAdapter类的对象
                MySqlDataAdapter sda = new MySqlDataAdapter(sql, db.conn);
                //创建DataSet类的对象
                DataSet ds = new DataSet();
                //使用SqlDataAdapter对象sda将查新结果填充到DataSet对象ds中
                sda.Fill(ds);
                //设置表格控件的DataSource属性
                dataGridView1.DataSource = ds.Tables[0];
                //设置数据表格上显示的列标题
                dataGridView1.Columns[0].HeaderText = "课程ID";
                dataGridView1.Columns[1].HeaderText = "课程名";
                dataGridView1.Columns[2].HeaderText = "学院";
                dataGridView1.Columns[3].HeaderText = "学分";
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
        private void QueryAllstudent( string cc)
        {
            DataBase db = new DataBase();
            try
            {
                string sql = "select * from take where c_id='{0}'";
                sql = string.Format(sql, cc);
                //创建SqlDataAdapter类的对象
                MySqlDataAdapter sda = new MySqlDataAdapter(sql, db.conn);
                //创建DataSet类的对象
                DataSet ds = new DataSet();
                //使用SqlDataAdapter对象sda将查新结果填充到DataSet对象ds中
                sda.Fill(ds);
                //设置表格控件的DataSource属性
                dataGridView2.DataSource = ds.Tables[0];
                //设置数据表格上显示的列标题
                dataGridView2.Columns[0].HeaderText = "课程ID";
                dataGridView2.Columns[1].HeaderText = "学生ID";
                dataGridView2.Columns[2].HeaderText = "课程成绩";
                
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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
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
                                sql = "select * from course where c_id like '%{0}%' and course.c_id=(select teach.c_id from teach where teach.t_id='{1}')";
                                //sql = "select * from student where s_id like '%{0}%'";
                                sql = string.Format(sql, textBox5.Text,number);
                            }
                            else
                            {
                                sql = "select * from course where c_id like '%{0}%' and c_name like '%{1}%' and course.c_id=(select teach.c_id from teach where teach.t_id='{2}')";
                                sql = string.Format(sql, textBox5.Text, textBox6.Text,number);
                            }
                        }
                        else if (textBox6.Text != "")
                        {
                            sql = "select * from course where c_name like '%{0}%' and course.c_id = (select teach.c_id from teach where teach.t_id = '{1}')";
                            sql = string.Format(sql, textBox6.Text,number);
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
                    QueryAllcourse();
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string cre;
            string cid;
            cid= dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            label4.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
            DataBase db = new DataBase();
            string sql = "select * from student where s_id='{0}'";
            sql = string.Format(sql, label4.Text);
            try
            {
                MySqlDataReader reader = db.select(sql);

                while (reader.Read())
                {
                    label10.Text = (reader.GetString(1));
                    label1.Text = (reader.GetString(2));
                    label13.Text = (reader.GetString(3));

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
            DataBase dc = new DataBase();
            string sql2 = "select credit from course where c_id='{0}'";
            sql2 = string.Format(sql2, cid);
            try
            {
                MySqlDataReader reader = dc.select(sql2);

                while (reader.Read())
                {
                    cre = (reader.GetString(0));
                    label8.Text = cre;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("出现错误！" + ex.Message);
            }
            finally
            {
                if (dc.conn != null)
                {
                    dc = null;
                }
            }
        }
        
        

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double g=0;
            string cid;
            cid= dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            DataBase db = new DataBase();
            string sql = "select * from take where s_id='{0}' and c_id='{1}'";
            sql = string.Format(sql, label4.Text,cid);
            try
            {
                MySqlDataReader reader = db.select(sql);

                while (reader.Read())
                {
                    g = (reader.GetDouble(2));

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
            if (textBox2.Text == "")
            {
                MessageBox.Show("修改失败！");
                return;
            }
            DataBase dc = new DataBase();
            try
            {
                double newg = Convert.ToDouble(textBox2.Text);
                string sql2 = "update take set grade={0}  where s_id='{1}'and c_id='{2}'";
                //填充占位符
                sql2 = string.Format(sql2, newg, label4.Text,cid);
                dc.upgrade(sql2);
                if (g >= 60 && newg < 60)
                {
                    Double newc = 0;
                    
                    newc = Convert.ToDouble(label8.Text);
                    //MessageBox.Show("a"+newc);
                    string sql3 = "update student set tot_credit=tot_credit-{0}  where s_id='{1}'";
                    sql3 = string.Format(sql3,newc, label4.Text);
                    dc.upgrade(sql3);
                }
                else if (g < 60 && newg >= 60)
                {
                    Double newc = 0;
                    newc = Convert.ToDouble(label8.Text);
                    string sql3 = "update student set tot_credit=tot_credit+{0}  where s_id='{1}'";
                    sql3 = string.Format(sql3, newc, label4.Text);
                    dc.upgrade(sql3);
                }
                MessageBox.Show("修改成功！");
                string cc;
                cc = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                QueryAllstudent(cc);
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改失败！" + ex.Message);
            }
            finally
            {
                if (dc.conn != null)
                {
                    //关闭数据库连接
                    dc = null;
                    
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
