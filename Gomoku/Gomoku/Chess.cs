using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Gomoku
{
    abstract class Chess : PictureBox
    {
        private static readonly int radius = 25;
        public Chess(int x, int y)
        {            
            this.BackColor = Color.Transparent;
            this.Size = new Size(2 * radius, 2 * radius);
            this.Location = new Point(x - radius, y - radius);
            
            // 另外可以定義大小的方式
            //this.Width = 50;
            //this.Height = 50;
        }
    }
}
