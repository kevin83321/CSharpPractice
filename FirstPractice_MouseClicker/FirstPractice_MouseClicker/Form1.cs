using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstPractice_MouseClicker
{
    public partial class Form1 : Form
    {
        int times = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            times++;
            TimesLabel.Text = "你已經按了..." + times + "下了";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            times = 0;
            TimesLabel.Text = "你已經按了..." + times + "下了";
        }
    }
}
