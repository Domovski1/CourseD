using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseD
{
    public partial class Contract : Form
    {
        public Contract()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            updatePage uPage = new updatePage();
            uPage.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            contractPage cPage = new contractPage();
            cPage.Show();
        }
    }
}
