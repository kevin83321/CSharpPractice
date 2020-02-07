using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inheritance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Villager vi = new Villager("aaa");
            MessageBox.Show("" + vi.Talk());
            MessageBox.Show("Villager's HP : " + vi.GetHP());

            //Monster mon = new Monster("bbb");
            //MessageBox.Show("Monster's HP : " + mon.GetHP());

            //Monster m2 = new Monster("ccc");

            //mon.Attack(vi);
            MessageBox.Show("After Injured,Villager's HP : " + vi.GetHP());
            //mon.Attack(m2);
            //MessageBox.Show("After Injured, Monster2's HP : " + m2.GetHP());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int power = 100; // 攻擊力

            Random random = new Random();
            
            int injured = random.Next(power / 2, power); //受到的傷害

            MessageBox.Show("kkk受到傷害 " + injured + " 點!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Player p = new Player("kkk");
            //Monster m = new Monster("ccc");
            Villager v = new Villager("qqq");
            //MessageBox.Show(m.attack(p));
            //MessageBox.Show(v.attack(m));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Fruit f = new Apple();
            MessageBox.Show(f.saySomething());
            
            Fruit f2 = new Orange();
            MessageBox.Show(f2.saySomething());
            Orange o = new Orange();
            MessageBox.Show(o.saySomething());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Slime s = new Slime("aaa");
            MessageBox.Show(s.say());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Slime s = new Slime("bbb");

            MessageBox.Show(s.say());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Monster m = new Slime("ddd");
            //MessageBox.Show("" + m.attack());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            double r = 2.0;
            double area = Math.PI * r * r;
            MessageBox.Show("圓周率 = " + area);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Monster m = new Monster("aac");
            m.move2(Direction.UP);
            m.move2(Direction.UP);
            m.move2(Direction.UP);
            m.move2(Direction.RIGHT);
            MessageBox.Show("" + m.ReportPosition());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int[,] board;
            int[,] A = new int[,] { { 1, 2 }, { 3, 4 } };
            int[,] B = new int[,] { { 3, 4 }, { 5, 6 } };
            //board = new int[4, 4];
            //board = new int[,] { { 1, 2 }, { 3, 4 } };
            //board[0, 1] = 10;

            //int[] scores = new int[] { 12, 30, 100 };
            int[,] MatrixAdd(int[,] a, int[,] b)
            {
                int[,] C = new int[2,2];
                for (int i=0; i<2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        C[i, j] = a[i, j] + b[i, j];
                    }
                }
                return C;
            }

            int[,] MatrixSubstract(int[,] a, int[,] b)
            {
                int[,] C = new int[2, 2];
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        C[i, j] = a[i, j] - b[i, j];
                    }
                }
                return C;
            }

            int[,] MatrixMultiply(int[,] a, int[,] b)
            {
                int[,] C = new int[2, 2];
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        for (int k = 0; k < 2; k++)
                        {
                            C[j, i] += a[j, k] * b[k, i];
                        }
                        Console.WriteLine("C[" + j + "," + i + "]=" + C[j, i] + "\n");
                    }
                }
                //Console.WriteLine();
                return C;
            }
            int[,] c = MatrixAdd(A, B);
            int[,] d = MatrixSubstract(A, B);
            int[,] f = MatrixMultiply(A, B);

            MessageBox.Show(""+f[0,1]);
        }
    }
}
