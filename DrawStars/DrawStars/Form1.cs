using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawStars
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int row = (int) rowchooser.Value; // 強制轉型
            string result = "";
            for (int i = 1; i <= row; i++)
            {
                //result += " " * (row - i) + "*" * i + " " * (row - i);
                for (int k = 1; k <= row - i; k++)
                {
                    result += " ";
                }
                for (int j = 1; j <= 2*i-1; j++)
                {
                    result += "*";
                }
                for (int k = 1; k <= row - i; k++)
                {
                    result += " ";
                }
                result += "\r\n";
            }

            MessageBox.Show(result);
        }
    }
}
