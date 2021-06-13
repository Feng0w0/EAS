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
    }
}
