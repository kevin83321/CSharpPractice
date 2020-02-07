using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Creature
    {
        //property
        protected int hp = 100;
        private string name;

        public void SetName(string name)
        {
            this.name = name;
        }

        //Method
        public int GetHP()
        {
            return hp;
        }

        public void Injured(int injuredPoint)
        {
            hp -= injuredPoint;
            // ... New Code ...
        }

        public virtual string attack(Creature target)
        {
            return this.name + " 攻擊了 " + target.name;
        }

        public virtual string move()
        {
            return name + " 向前走";
        }
        protected virtual string introduceSelf()
        {
            return "我是個生物";
        }


    }
}
