using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GarbageCollection
{
    class Student
    {
        // Property
        public int StudentID;
        public string Name;
        public int Grade;

        public int Score;
        public static int PassScore = 60;

        // Method
        // public OutputType MethodName(Input Type and Name)
        public string Say()
        {
            return "我叫 " + Name + " ，我是 " + Grade + " 年級的學生，我的學號是 " + StudentID;
        }
        public void Upgrade()
        {
            Grade++;
        }
        //public string Talk(int sgrade, string sname)
        //{
        //    return Grade + " 年級的 " + Name + " 對 " + sgrade + " 年級的 " + sname + " 說你好!";
        //}

        public string Talk(Student s2)
        {
            return Grade + " 年級的 " + Name + " 對 " + s2.Grade + " 年級的 " + s2.Name + " 說你好!";
        }

        public Student(int studentID, string name) // Constructor 建構子，用於初始化
        {
            Grade = 1;
            Name = name;
            StudentID = studentID;

            MessageBox.Show(Say());
        }
        public Student(int studentID, string name, int grade) // Constructor 建構子，用於初始化
        {
            Grade = grade;
            Name = name;
            StudentID = studentID;

            MessageBox.Show(Say());
        }
    }
}
