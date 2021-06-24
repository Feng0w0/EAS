using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EAS.Student;

namespace EAS.Student
{
    public partial class Student : Form
    {
        private string number;
        public Student(string number)
        {
            this.number = number;
            InitializeComponent();
        }

        private void Student_Load(object sender, EventArgs e)
        {
            this.label2.Text = this.number;
        }

   
        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            studentin sim = new studentin(this.number);
            sim.Dock = System.Windows.Forms.DockStyle.Fill;
            sim.FormBorderStyle = FormBorderStyle.None;
            sim.TopLevel = false;
            sim.Show();
            this.panel1.Controls.Add(sim);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            studenttake st = new studenttake(this.number);
            st.Dock = System.Windows.Forms.DockStyle.Fill;
            st.FormBorderStyle = FormBorderStyle.None;
            st.TopLevel = false;
            st.Show();
            this.panel1.Controls.Add(st);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
