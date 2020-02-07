using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gomoku
{
    public partial class Form1 : Form
    {
        private Board board = new Board();
        //private bool isBlack = true;
        private ChessType nextChessType = ChessType.BLACK;
        public Form1()
        {
            InitializeComponent();
            //this.Controls.Add(new WhiteChess(80, 20));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Chess chess = board.PlaceAChess(e.X, e.Y, nextChessType);

            if (chess != null)
            {
                this.Controls.Add(chess);
                if (nextChessType == ChessType.BLACK)
                    nextChessType = ChessType.WHITE;
                else if (nextChessType == ChessType.WHITE)
                    nextChessType = ChessType.BLACK;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (board.CanBePlaced(e.X, e.Y))
            {
                this.Cursor = Cursors.Hand;
            } else
            {
                this.Cursor = Cursors.Default;
            }
                
        }
    }
}
