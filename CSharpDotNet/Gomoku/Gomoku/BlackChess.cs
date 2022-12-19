using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class BlackChess : Chess
    {
        public BlackChess(int x, int y, ChessType chesstype) : base(x, y, chesstype)
        {
            this.Image = Properties.Resources.black;
        }
    }
}
