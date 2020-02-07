using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Villager : Creature
    {
        private string name;
        public Villager(string name)
        {
            this.name = name;
        }
        public String Talk()
        {
            return "呀呼~ 今天天氣真好啊~~~ ㄏㄏ";
        }

        public override string attack(Creature target)
        {
            return this.name + " 不能攻擊其他人 ";
        }

        // .... More ....
    }
}
