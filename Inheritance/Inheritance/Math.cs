using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Math
    {
        //const 被編譯後會直接替換成該變數所代表的數值，而readonly則不會有此問題
        //public const double PI = 3.1415926; //常數不可改
        public static readonly double PI = 3.1415926; //唯獨可設為static不須初始化class

        public void meow()
        {
            const int a = 10; // method內不可宣告readonly的變數
        }
    }
}
