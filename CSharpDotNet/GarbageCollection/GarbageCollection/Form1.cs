using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GarbageCollection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Student s = new Student(100, "kkk");
            //s.Grade = 3;
            //s.Name = "123";

            User user = new User("kkk", "1234");
            //user.UserName = "slmt";
            string result = "";

            if (user.comparePassword("1234"))
                result = "密碼正確!!";
            else
                result = "密碼錯誤!哈哈!";

            //MessageBox.Show(result);
            //user.hurt(10);
            //user.hurt(10);
            //user.hurt(10);
            
            user.HP = -5;// 呼叫user.HP裡的set
            MessageBox.Show("HP : " + user.HP); // 呼叫user.HP裡的get
            MessageBox.Show("Money : " + user.Money);

        }
    }
}
