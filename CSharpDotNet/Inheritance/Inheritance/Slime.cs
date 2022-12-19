using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Slime : Monster
    {
        private int hp;
        //private string name;

        public Slime(string name) : base(name)
        {
            this.hp = 500;
            base.hp = 234234;
        }

        public string say()
        {
            return base.introduceSelf().Replace("生","怪") + ", 我叫史萊姆~~";
        }

        //public override string attack()
        //{
        //    return "史萊姆正在攻擊別人";
        //}
    }
}
