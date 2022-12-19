using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowControl2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = "";
            //text += "7 x 1 = " + 7 * 1 + "\r\n";
            //text += "7 x 2 = " + 7 * 2 + "\r\n";
            //text += "7 x 3 = " + 7 * 3 + "\r\n";
            //text += "7 x 4 = " + 7 * 4 + "\r\n";
            //text += "7 x 5 = " + 7 * 5 + "\r\n";
            //text += "7 x 6 = " + 7 * 6 + "\r\n";
            //text += "7 x 7 = " + 7 * 7 + "\r\n";
            //text += "7 x 8 = " + 7 * 8 + "\r\n";
            //text += "7 x 9 = " + 7 * 9 + "\r\n";

            // for loop
            for (int i = 1; i <= 9; i++)
            {
                text += "7 x " + i + " = " + 7 * i + "\r\n";
            }

            //int i = 1;
            //while (i <= 9)
            //{
            //    text += "7 x " + i + " = " + 7 * i + "\r\n";
            //    i++;
            //}

            MessageBox.Show(text);

            /*
             * 多行註解
             * 
             * 
             */
        }
    }
}
