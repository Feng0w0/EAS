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
    public partial class personal : Form
    {
        private string number;
        public personal(string number)
        {
            this.number = number;
            InitializeComponent();
            DataBase db = new DataBase();
           string sql = "select * from teacher where t_id='{0}'";
            sql = string.Format(sql, number);
            try
            {
                MySqlDataReader reader = db.select(sql);

                while (reader.Read())
                {
                    label5.Text = (reader.GetString(1));
                    label6.Text = number;
                    label7.Text = (reader.GetString(2));
                    
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

        private void personal_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
