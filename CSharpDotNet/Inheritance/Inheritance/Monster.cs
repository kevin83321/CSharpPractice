using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    //abstract class Monster : Creature
    class Monster : Creature
    {
        private string name;
        private int X;
        private int Y;
        public Monster(string name)
        {
            this.name = name;
        }

        //deraction 1 => Up, 2 => Down, 3 => Left, 4 => Right
        public void move2(Direction direction)
        {
            //if (direction == 1)
            //{
            //    Y++;
            //}
            //else if (direction == 2)
            //{
            //    Y--;
            //}
            //else if (direction == 3)
            //{
            //    X--;
            //}
            //else
            //{
            //    X++;
            //}
            switch (direction)
            {
                case Direction.UP:
                    Y++;
                    break;
                case Direction.DOWN:
                    Y--;
                    break;
                case Direction.LEFT:
                    X--;
                    break;
                case Direction.RIGHT:
                    X++;
                    break;
                default://類似else
                    break;
            }
        }
        public string ReportPosition()
        {
            return "怪物在" + X + "," + Y;
        }
        public void Attack(Creature c)
        {
            c.Injured(10);
        }

        public override string move()
        {
            return name + " 橫著走";
        }

        // class 35
        //public abstract string attack(); // abstract method只能在abstract class裡定義
        
        //.... More ....
    }
}
