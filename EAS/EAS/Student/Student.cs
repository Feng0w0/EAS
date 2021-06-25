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
using System.Text.RegularExpressions;
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
            this.panel1.Controls.Clear();
            studentin sim = new studentin(this.number);
            sim.Dock = System.Windows.Forms.DockStyle.Fill;
            sim.FormBorderStyle = FormBorderStyle.None;
            sim.TopLevel = false;
            sim.Show();
            this.panel1.Controls.Add(sim);
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

        //private void button4_Click(object sender, EventArgs e)
        //{

        //    DataBase db = new DataBase();

        //    string[] arr = new string[textBox1.Lines.Length];
        //    for (int i = 0; i < textBox1.Lines.Length; i++)
        //    {
        //        arr[i] = textBox1.Lines[i];
        //        string[] test = new string[5];
        //        string[] sArray = arr[i].Split(' ');
        //        string[] sArray = Regex.Split(arr[i], "\\s+");
        //        string sql = "insert into student(s_id,s_name,d_name,class) values('{0}','{1}','{2}','{3}')";
        //        int tt = 0;
        //        foreach (string j in sArray)
        //        {
        //            test[tt] = j.ToString();
        //            tt++;
        //        }

        //        填充占位符
        //        sql = string.Format(sql, test[0], test[1], test[3], test[4]);
        //        db.insert(sql);
        //    }




       // }

        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{

        //}
    }
}
