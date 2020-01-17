using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Student
    {
        // Property
        public int StudentID;
        public string Name;
        public int Grade;
        public int height;
        public static int passScore = 60;
        public int Score;

        //Method
        // public output_type method_name (input type and name)
        public Student(int studentID, string name, int height)
        {
            StudentID = studentID;
            Name = name;
            Grade = 1;
        }
        public Student(int studentID, string name, int height, int grade)
        {
            StudentID = studentID;
            Name = name;
            this.height = height; // 指定Student這個物件的變數
            Grade = grade;
        }

        public bool isPass()
        {
            if (Score >= passScore)
                return true;
            else
                return false;
        }

    }
}
