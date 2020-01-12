using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Practice1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Student s = new Student();
            //s.Name = "Kevin";
            //s.Grade = 7;
            //s.StudentID = 55688;

            ////MessageBox.Show(s.Say());
            ////s.Upgrade();
            ////MessageBox.Show(s.Say());
            ////MessageBox.Show(s.Talk(9, "cc"));

            //Student s2 = new Student();
            //s2.Name = "kiki";
            //s2.Grade = 3;
            //MessageBox.Show(s.Talk(s2));

            //// value type
            ////int a = 10;
            ////int b = a;
            ////b = 20;
            ////MessageBox.Show("a = " + a + ", b = " + b);

            //// reference type
            ////Student s1 = new Student();
            ////s1.Name = "kkk";
            ////s1.Grade = 5;

            ////Student s3 = s1;
            ////s3.Name = "iii";
            ////s3.Grade = 7;
            ////MessageBox.Show(s1.Say());

            // Constuctor

            Student s1 = new Student(10201, "aaa");

            Student s2 = new Student(10202, "bbb", 2);

        }
    }
}
