using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class Game
    {
        private Board board = new Board();
        //private bool isBlack = true;
        private ChessType CurrentPlayer = ChessType.BLACK;
        private ChessType winner = ChessType.NONE;
        public ChessType Winner { get { return winner; } }

        public bool CanBePlaced(int x, int y)
        {
            return board.CanBePlaced(x, y);
        }

        public Chess PlaceAChess(int x, int y)
        {
            Chess chess = board.PlaceAChess(x, y, CurrentPlayer);

            if (chess != null)
            {
                CheckWinner();
                if (CurrentPlayer == ChessType.BLACK)
                {
                    CurrentPlayer = ChessType.WHITE;
                }                    
                else if (CurrentPlayer == ChessType.WHITE)
                {
                    CurrentPlayer = ChessType.BLACK;
                }                
                return chess;

            }
            else
                return null;
        }

        private void CheckWinner()
        {
            int CenterX = board.LastPlacedNode.X;
            int CenterY = board.LastPlacedNode.Y;

            //檢查8個不同方向，當最後一子位於最邊邊
            for (int xDir = -1; xDir <= 1; xDir++)
            {
                for (int yDir = -1; yDir <= 1; yDir++)
                {
                    // 排除中間的狀況
                    if (xDir != 0 && yDir != 0)
                    {
                        // 紀錄現在看到幾顆相同的旗子
                        int count = 1;
                        while (count < 5)
                        {
                            int targetX = CenterX + count * xDir;
                            int targetY = CenterY + count * yDir;

                            // 檢查顏色是否相同
                            if (targetX < 0 || targetX > Board.NODE_COUNT ||
                                targetY < 0 || targetY > Board.NODE_COUNT ||
                                board.GetChessType(targetX, targetY) != CurrentPlayer)
                                break;
                            count++;
                        }

                        //檢查是否看到五顆棋子
                        if (count == 5)
                            winner = CurrentPlayer;
                    }                    
                }
            }                       
        }
    }
}
