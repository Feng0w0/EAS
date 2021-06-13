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
    public partial class Teacher : Form
    {
        private string number;
        public Teacher(string number)
        {
            this.number = number;
            InitializeComponent();
        }

        private void Teacher_Load(object sender, EventArgs e)
        {

        }
    }
}
