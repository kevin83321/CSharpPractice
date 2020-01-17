using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrayPractice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student[] scores = new Student[10];
            //scores[0] = 92;
            //scores[1] = 83;
            //scores[2] = 100;
            scores[0] = new Student(0, "aaa");
            scores[1] = new Student(1, "bbb");
            scores[2] = new Student(2, "ccc");

            MessageBox.Show("" + scores[2].Name);
        }
    }
}
