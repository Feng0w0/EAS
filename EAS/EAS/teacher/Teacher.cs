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
    public partial class Teacher : Form
    {
        private string number;
        public Teacher(string number)
        {
            this.number = number;
            InitializeComponent();
            this.panel2.Controls.Clear();
            personal cim = new personal(number);
            cim.Dock = System.Windows.Forms.DockStyle.Fill;
            cim.FormBorderStyle = FormBorderStyle.None;
            cim.TopLevel = false;
            cim.Show();
            this.panel2.Controls.Add(cim);

        }

        private void Teacher_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

 

        private void button1_Click(object sender, EventArgs e)
        {
            this.panel2.Controls.Clear();
            course cim = new course(number);
            cim.Dock = System.Windows.Forms.DockStyle.Fill;
            cim.FormBorderStyle = FormBorderStyle.None;
            cim.TopLevel = false;
            cim.Show();
            this.panel2.Controls.Add(cim);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.panel2.Controls.Clear();
            personal  cim = new personal (number);
            cim.Dock = System.Windows.Forms.DockStyle.Fill;
            cim.FormBorderStyle = FormBorderStyle.None;
            cim.TopLevel = false;
            cim.Show();
            this.panel2.Controls.Add(cim);
        }
    }
}
