using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(""+math.max(10, 15));
            Student s1 = new Student(10201, "kkk", 135);
            Student.passScore = 49;
            s1.Score = 50;
            MessageBox.Show(""+s1.isPass());
        }
    }
}
