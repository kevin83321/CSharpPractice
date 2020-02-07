using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class Board
    {
        private static readonly Point NO_MATCH_NODE = new Point(-1, -1);

        private static readonly int offset = 75;
        private static readonly int NODE_RADIUS = 10;
        private static readonly int NODE_DISTANCE = 75;

        private Chess[,] chesses = new Chess[9, 9];
        public bool CanBePlaced(int x, int y)
        {
            // TODO:找出最近的節點(Node)
            Point Node = findTheClosestNode(x, y);
            // TODO:如果沒有的話，回傳false
            if (Node == NO_MATCH_NODE)
                return false;
            // TODO:如果有的畫，檢查是否已經有旗子存在
            if (chesses[Node.X, Node.Y] != null)
                return false;
            return true;
        }

        public Chess PlaceAChess(int x, int y, ChessType type)
        {
            // TODO: 
            // TODO:找出最近的節點(Node)
            Point Node = findTheClosestNode(x, y);
            // TODO:如果沒有的話，回傳false
            if (Node == NO_MATCH_NODE)
                return null;
            // TODO:如果有的話，檢查是否已經有旗子存在
            if (chesses[Node.X, Node.Y] != null)
                return null;

            // TODO: 根據type產生對應的棋子
            if (type == ChessType.BLACK)
            {
                Point formPos = convertToFormPosition(Node);
                chesses[Node.X, Node.Y] = new BlackChess(formPos.X, formPos.Y);
            }
            else if (type == ChessType.WHITE){
                Point formPos = convertToFormPosition(Node);
                chesses[Node.X, Node.Y] = new WhiteChess(formPos.X, formPos.Y);
            }
            return chesses[Node.X, Node.Y];
        }

        private Point convertToFormPosition(Point nodeId)
        {
            Point formPosition = new Point();
            formPosition.X = nodeId.X * NODE_DISTANCE + offset;
            formPosition.Y = nodeId.Y * NODE_DISTANCE + offset;
            return formPosition;
        }

        private Point findTheClosestNode(int x, int y)
        {
            int NodeX = findTheClosestNode(x);
            if (NodeX == -1)
                return NO_MATCH_NODE;
            
            int NodeY = findTheClosestNode(y);
            if (NodeY == -1)
                return NO_MATCH_NODE;

            return new Point(NodeX, NodeY);
        }

        private int findTheClosestNode(int pos)
        {
            if (pos < offset - NODE_RADIUS)
                return -1;
            pos -= offset;

            int quotient = pos / NODE_DISTANCE;
            int remainder = pos % NODE_DISTANCE;

            if (remainder <= NODE_RADIUS)
                return quotient;
            else if (remainder >= NODE_DISTANCE - NODE_RADIUS)
                return quotient + 1;
            else
                return -1;
        }
    }
}
