using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayPractice
{
    class Student
    {
        //Property
        public int StudentID;
        public string Name;
        public int Grade;

        public Student(int studentID, string name)
        {
            StudentID = studentID;
            Name = name;
            Grade = 1;
        }
    }
}
