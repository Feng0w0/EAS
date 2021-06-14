﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EAS.Manger
{
    public partial class Manger : Form
    {
        private string number;
        public Manger(string number)
        {
            this.number = number;
            InitializeComponent();
        }

        private void Manger_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
      
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.panel2.Controls.Clear();
            StudentInfoMgr sim = new StudentInfoMgr();
            sim.Dock = System.Windows.Forms.DockStyle.Fill;
            sim.FormBorderStyle = FormBorderStyle.None;
            sim.TopLevel = false;
            sim.Show();
            this.panel2.Controls.Add(sim);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.panel2.Controls.Clear();
            TeacherInfoMgr tim = new TeacherInfoMgr();
            tim.Dock = System.Windows.Forms.DockStyle.Fill;
            tim.FormBorderStyle = FormBorderStyle.None;
            tim.TopLevel = false;
            tim.Show();
            this.panel2.Controls.Add(tim);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.panel2.Controls.Clear();
            CourseInfoMgr cim = new CourseInfoMgr();
            cim.Dock = System.Windows.Forms.DockStyle.Fill;
            cim.FormBorderStyle = FormBorderStyle.None;
            cim.TopLevel = false;
            cim.Show();
            this.panel2.Controls.Add(cim);
        }
    }
}