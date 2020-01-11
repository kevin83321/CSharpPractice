using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormPractice_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Practice 1 的 messagebox
            // MessageBox.Show("你好啊，這是第一個按鈕的反應唷~~");


            // Practice 2 : variable 
            // int number, zero, hhh; // 可同時宣告多個變數
            // number = 20;
            // 或是可以在宣告時直接給值
            // int number = 300;
            // MessageBox.Show("number = " + number);


            // Practice 3 : calculate
            //int number;
            //number = 40 + 8;
            //number = 40 - 8;
            //number = 40 * 8;
            //number = 40 / 25; // 取商數
            //number = 40 % 25; // 取餘數
            //number = 40 + 20 * 2 - 30 / 15;
            //number = (40 + 20) * 2 - 30 / 15;
            //number = number + 30;
            //number += 30;
            //number++;
            //number--;
            //number *= 2;
            //number /= 3;
            //MessageBox.Show("number = " + number);


            // Practice 4, define variable and type
            //int number; // 整數
            //float fnumber; // 浮點數
            //double dnumber; // 雙倍精準度
            //dnumber = 3.14159265;
            //MessageBox.Show("dnumber = " + dnumber);

            //bool b = true;
            //bool a = false;

            // Practice 5
            //string str1 = "阿宏你好";
            //string str2 = "我是你的第一個C#程式唷~";
            //string str3 = str1 + "," + str2;
            //MessageBox.Show(str3);

        }
    }
}
