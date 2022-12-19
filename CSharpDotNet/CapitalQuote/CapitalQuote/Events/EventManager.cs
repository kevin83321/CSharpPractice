using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CapitalQuote
{
    class EventManager
    {
        public delegate void callbackfuncs(dynamic e);
        private bool active = false;
        private PriorityQueue queue = new PriorityQueue();
        private Thread thread;
        private Dictionary<string, List<callbackfuncs>> handlers = new Dictionary<string, List<callbackfuncs>> ();
        private Dictionary<string, int> encountMap;
        private int quoteEncount = 1;
        private int positionEncount = 1;
        private int futurerightEncount = 1;

        public EventManager()
        {
            createEncountMap();
            thread = new Thread(new ThreadStart(Run));
        }

        private void createEncountMap()
        {
            
            encountMap = new Dictionary<string, int>
            {
                {"ProfitReport",positionEncount },
                {"Account",1 },
                {"QUOTE", quoteEncount},
                {"Tick", quoteEncount},
                {"History_Tick",quoteEncount },
                {"BEST5",quoteEncount },
                {"Info",quoteEncount },
                {"Commission",quoteEncount },
                {"OpenInterest",positionEncount },
                {"Origin_Kline",quoteEncount },
                {"Connection",1 },
                {"RequestMsg",1 },
                {"RealBalanceReport",positionEncount },
                {"Query",positionEncount },
                {"NewData",1 },
                {"OrderMsg",1 },
                {"StockList",1 },
                {"OS_Quote",quoteEncount },
                {"OS_Tick",quoteEncount },
                {"OS_History_Tick",quoteEncount },
                {"FutureRights",futurerightEncount },
                {"OSFutureRight",futurerightEncount },
                {"ERROR",1 }
            };
        }
        private void Run()
        {
            while (active)
            {
                try
                {
                    dynamic[] events = queue.get();
                    EventProcess(events);
                }
                catch (IndexOutOfRangeException)
                {
                    Thread.SpinWait(1);
                }
                catch (Exception)
                {
                    string msg = $"In EventManager Run, Error : {new Exception()}";
                    put(new ErrorEvent(msg));
                    Thread.SpinWait(1);
                }
            }
        }

        private void EventProcess(dynamic[] events)
        {
            dynamic e = events[events.Length - 1];
            if (handlers.ContainsKey(e.type_))
            {
                foreach(Action<dynamic> handler in handlers[e.type_])
                {
                    try
                    {
                        handler(e);
                    }
                    catch
                    {
                        string msg = $"In EventManager EventProcess, Error : {new Exception()}";
                        put(new ErrorEvent(msg));
                    }
                }
            }
        }

        public void Start()
        {
            active = true;
            thread.Start();
        }

        public void Stop()
        {
            active = false;
            thread.Join();
        }

        public void AddEventListener(string type_, callbackfuncs handler)
        {
            try
            {
                List<callbackfuncs> handlerList = handlers[type_];
                if (!handlerList.Contains(handler))
                {
                    handlerList.Add(handler);
                }
            }
            catch (KeyNotFoundException)
            {
                List<callbackfuncs> handlerList = new List<callbackfuncs> { handler };
                handlers.Add(type_, handlerList);
            }
        }

        public void RemoveEventListener(string type_, callbackfuncs handler)
        {
            try
            {
                List<callbackfuncs> handlerList = handlers[type_];
                if (handlerList.Contains(handler))
                {
                    handlerList.Remove(handler);
                }
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine($"{handler} not in the listener list");
            }
        }

        public void put(dynamic events)
        {
            try
            {
                queue.put(new dynamic[] { events.priority, encountMap[events.type_], events });
                encountMap[events.type_]++;
            }
            catch (Exception)
            {

            }
        }
    }
}
