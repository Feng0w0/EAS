using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EAS
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

        }
    }
}
