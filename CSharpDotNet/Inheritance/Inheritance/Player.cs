using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Player : Creature
    {

        private string name;
        public Player(string name)
        {
            this.name = name;
        }
    }
}
