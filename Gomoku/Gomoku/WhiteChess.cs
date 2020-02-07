using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class WhiteChess : Chess
    {
        public WhiteChess(int x, int y) : base(x, y)
        {
            this.Image = Properties.Resources.white;
        }
    }
}
