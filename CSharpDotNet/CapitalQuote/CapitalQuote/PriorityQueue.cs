using System;
using System.Collections.Generic;
using System.Text;

namespace CapitalQuote
{
    class PriorityQueue
    {
        private List<dynamic> queue;
        public bool empty { get { return Count == 0; } }
        private int Count { get { return queue.Count; } }
        public PriorityQueue()
        {
            queue = new List<dynamic>();
        }
                
        public void put (dynamic[] e)
        {
            int maxlen = e.Length;
            int temp = 0;
            for (int k = 0; k <= e.Length - 2; k++)
            {
                for (int i = temp; i <= Count; i++)
                {
                    if (empty)
                    {
                        queue.Add(e);
                        break;
                    }
                    else if (e[k] == queue[i][k])
                    {
                        temp = i;
                        break;
                    }
                    else
                    {
                        queue.Insert(i, e);
                        break;
                    }
                    
                }
            }
        }

        public dynamic get()
        {
            if (!empty)
            {
                dynamic element = queue[0];
                queue.RemoveAt(0);
                return element;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
            
        }
    }
}
