using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace EAS
{
    class DataBase
    {
        public MySqlConnection conn;
        DataBase()
        {
            string connString = "server=XinBall.top;database=hyf;uid=hyf;pwd=mysqlhyf";//数据连接字段
            conn = new MySqlConnection(connString);//之前SQLServer的连接名是SqlConnection
            try
            {
                conn.Open();
                MessageBox.Show("连接成功！");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        ~DataBase()
        {
            conn.Close();
        }
        public int insert()
        {
            string sql="";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            return cmd.ExecuteNonQuery();
        }
        public void delete()
        {

        }
        public void upgrade()
        {

        }
        public void select()
        {

        }
        public void close()
        {
            conn.Close();
        }
    }
}
