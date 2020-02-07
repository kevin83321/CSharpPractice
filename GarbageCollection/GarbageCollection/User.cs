using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarbageCollection
{
    class User
    {
        public string UserName;
        private string Password;
        private int hp;
        private int count1, count5, count10;
        public int HP
        {
            get { return hp; } // 在讀取大HP時自動呼叫
            set
            { // 再存入數值時自動呼叫
                if (value < 0)
                    hp = 0;
                else
                    hp = value;
            }
        }

        public User(string Username, string Password)
        {
            this.UserName = Username;
            this.Password = Password;
            this.hp = 20;
            this.count1 = 1;
            this.count5 = 1;
            this.count10 = 1;
        }

        public int Money
        {
            get { return count1 + count5 * 5 + count10 * 10; } 
        }
        private void reset()
        {
            Password = "";
        }

        public void hurt(int decreaseHP)
        {
            if (hp >= decreaseHP)
                hp -= decreaseHP;
            else
                hp = 0;
        }

        public int getHP()
        {
            return hp;
        }

        public bool comparePassword(string targetPassword)
        {
            if (this.Password == targetPassword)
                return true;
            else
                return false;
        }
    }
}
