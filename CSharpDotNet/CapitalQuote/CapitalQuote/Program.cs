using System;
using System.IO;
using SKCOMLib;
using System.Threading;
using System.Collections.Generic;

namespace CapitalQuote
{
    class Program
    {
        private string user;
        private string pwd;
        private EventManager quoteEventManager;
        private EventManager orderEventManager;
        private SKREvent skREvent;
        private SKOEvent skOEvent;
        private SKQEvent skQEvent;
        private SKOSQEvent skOSQEvent;
        private SKOOQEvent skOOQEvent;
        private RedisConnector redis;
        private bool listenOrders = true;
        private bool listenFutureRight = true;
        private bool listenPosition = true;
        private bool listenStock = true;
        private bool listenOSStock = true;
        private List<string> Stock;
        private List<string> osStock;
        static void Main(string[] args)
        {
            // RedisConnector redis = new RedisConnector();
            Program program = new Program();
            program.SubscribesAll();
            // SKCOMObject.skC.SK
            string logpath = System.Environment.CurrentDirectory; // 取得當前執行檔的目錄
            skObj.skC.SKCenterLib_SetLogPath(Path.Combine(logpath, "Capital_Log"));
            // Login
            int m_nCode = skObj.skC.SKCenterLib_Login(program.user, program.pwd);
            string skmsg = skObj.skC.SKCenterLib_GetReturnCodeMessage(m_nCode);
            Console.WriteLine("Login : " + skmsg);

            // EnterMonitor
            m_nCode = skObj.skQ.SKQuoteLib_EnterMonitor();
            skmsg = skObj.skC.SKCenterLib_GetReturnCodeMessage(m_nCode);
            Console.WriteLine("EnterMonitor : " + skmsg);

            // Initialize
            m_nCode = skObj.skO.SKOrderLib_Initialize();
            skmsg = skObj.skC.SKCenterLib_GetReturnCodeMessage(m_nCode);
            Console.WriteLine("Initialize Order : " + skmsg);

            // ReadCertByID
            m_nCode = skObj.skO.ReadCertByID(program.user);
            skmsg = skObj.skC.SKCenterLib_GetReturnCodeMessage(m_nCode);
            Console.WriteLine("Read Certification : " + skmsg);

            //ConnectByID
            m_nCode = skObj.skR.SKReplyLib_ConnectByID(program.user);
            skmsg = skObj.skC.SKCenterLib_GetReturnCodeMessage(m_nCode);
            Console.WriteLine("Reply Server ConnectByID : " + skmsg);

            while (SKQEvent.connected != ConnectionType.Ready && SKOSQEvent.osq_con != ConnectionType.Ready && SKOOQEvent.ooq_con != ConnectionType.Ready)
            {
                Thread.Sleep(1000);
            }
            skObj.skO.GetUserAccount();
            string symbol_list = "TX00,TE00,TF00";
            m_nCode = skObj.skQ.SKQuoteLib_RequestStocks(-1, symbol_list);
            skmsg = skObj.skC.SKCenterLib_GetReturnCodeMessage(m_nCode);
            Console.WriteLine("RequestStock : " + skmsg);

            string[] symbol_arr = symbol_list.Split(',');
            Console.WriteLine("After join" + string.Join(",", symbol_arr));

            for (int i = 0; i < symbol_arr.Length; i++)

            {
                m_nCode = skObj.skQ.SKQuoteLib_RequestTicks(-1, symbol_arr[i]);
                skmsg = skObj.skC.SKCenterLib_GetReturnCodeMessage(m_nCode);
                Console.WriteLine(string.Format("Request {0} Tick : {1}", symbol_arr[i] , skmsg));
            }

            for (int i = 1; i <= 30; i++)

            {

                Console.WriteLine("Thread paused for {0} second", 1);

                // Pause thread for 1 second

                Thread.Sleep(1000);

                Console.WriteLine("i value: {0}", i);

            }
        }
        //private void initialEvents()
        public Program()
        {
            quoteEventManager = new EventManager();
            orderEventManager = new EventManager();
            skREvent = new SKREvent(orderEventManager);
            skOEvent = new SKOEvent(orderEventManager);
            skQEvent = new SKQEvent(quoteEventManager);
            skOSQEvent = new SKOSQEvent(quoteEventManager);
            skOOQEvent = new SKOOQEvent(quoteEventManager);

            user = "F128497445";
            pwd = "j7629864";
        }

        private void startAccountThread()
        {
            Thread orderthread = new Thread(new ThreadStart(NotifyNewOrder));
            Thread futureRightthread = new Thread(new ThreadStart(NotifyFutureRights));
            Thread positionthread = new Thread(new ThreadStart(NotifyPosition));
            orderthread.Start();
            futureRightthread.Start();
            positionthread.Start();
        }

        private void startQuoteThread()
        {

        }

        private delegate void someDelegate(dynamic e);
        private void functions(dynamic e)
        {

        }
        private void mainfunction(someDelegate thedelegate)
        {
            thedelegate(3);
        }

        private void addEventListener()
        {
            this.quoteEventManager.AddEventListener("QUOTE", sendToRedis);
        }

        private void addRedisListener()
        {

        }

        private void sendToRedis(dynamic e)
        {
            redis.publish(e.type_, e.data);
        }

        private static void testPriorityQueue()
        {
            dynamic[] e1 = new dynamic[] { 1, 2, 3 };
            dynamic[] e2 = new dynamic[] { 1, 3, 5 };
            dynamic[] e3 = new dynamic[] { 1, 1, 6 };
            dynamic[] e4 = new dynamic[] { 0, 1, 6 };
            PriorityQueue queue = new PriorityQueue();
            Console.WriteLine($"add element e1");
            queue.put(e1);
            Console.WriteLine($"add element e2");
            queue.put(e2);
            Console.WriteLine($"add element e3");
            queue.put(e3);
            Console.WriteLine($"add element e4");
            queue.put(e4);
            Thread.Sleep(1000);
            if (!queue.empty) Console.WriteLine("first element get from priority queue is "+ queue.get()[2]);
            if (!queue.empty) Console.WriteLine("second element get from priority queue is " + queue.get()[2]);
            if (!queue.empty) Console.WriteLine("third element get from priority queue is " + queue.get()[2]);
            if (!queue.empty) Console.WriteLine("fourth element get from priority queue is " + queue.get()[2]);
        }
        private void SubscribeSKQEvent()
        {
            skObj.skQ.OnConnection += new _ISKQuoteLibEvents_OnConnectionEventHandler(skQEvent.OnConnection);
            skObj.skQ.OnNotifyQuote += new _ISKQuoteLibEvents_OnNotifyQuoteEventHandler(skQEvent.OnNotifyQuote);
            skObj.skQ.OnNotifyTicks += new _ISKQuoteLibEvents_OnNotifyTicksEventHandler(skQEvent.OnNotifyTicks);
            skObj.skQ.OnNotifyStockList += new _ISKQuoteLibEvents_OnNotifyStockListEventHandler(skQEvent.OnNotifyStockList);
            skObj.skQ.OnNotifyHistoryTicks += new _ISKQuoteLibEvents_OnNotifyHistoryTicksEventHandler(skQEvent.OnNotifyHistoryTicks);
            skObj.skQ.OnNotifyKLineData += new _ISKQuoteLibEvents_OnNotifyKLineDataEventHandler(skQEvent.OnNotifyKLineData);
            skObj.skQ.OnNotifyBest5 += new _ISKQuoteLibEvents_OnNotifyBest5EventHandler(skQEvent.OnNotifyBest5);
        }

        private void SubscribeSKOEvent()
        {
            skObj.skO.OnAccount += new _ISKOrderLibEvents_OnAccountEventHandler(skOEvent.OnAccount);
            skObj.skO.OnFutureRights += new _ISKOrderLibEvents_OnFutureRightsEventHandler(skOEvent.OnFutureRights);
            skObj.skO.OnRequestProfitReport += new _ISKOrderLibEvents_OnRequestProfitReportEventHandler(skOEvent.OnRequestProfitReport);
            skObj.skO.OnOverSeaFutureRight += new _ISKOrderLibEvents_OnOverSeaFutureRightEventHandler(skOEvent.OnOverSeaFutureRight);
            skObj.skO.OnBalanceQuery += new _ISKOrderLibEvents_OnBalanceQueryEventHandler(skOEvent.OnBalanceQuery);
            skObj.skO.OnOpenInterest += new _ISKOrderLibEvents_OnOpenInterestEventHandler(skOEvent.OnOpenInterest);
            skObj.skO.OnRealBalanceReport += new _ISKOrderLibEvents_OnRealBalanceReportEventHandler(skOEvent.OnRealBalanceReport);
        }

        private void SubscribeSKOSQEvent()
        {
            skObj.skOSQ.OnConnect += new _ISKOSQuoteLibEvents_OnConnectEventHandler(skOSQEvent.OnConnect);
            skObj.skOSQ.OnNotifyQuote += new _ISKOSQuoteLibEvents_OnNotifyQuoteEventHandler(skOSQEvent.OnNotifyQuote);
            skObj.skOSQ.OnNotifyBest5 += new _ISKOSQuoteLibEvents_OnNotifyBest5EventHandler(skOSQEvent.OnNotifyBest5);
            skObj.skOSQ.OnNotifyTicks += new _ISKOSQuoteLibEvents_OnNotifyTicksEventHandler(skOSQEvent.OnNotifyTicks);
            skObj.skOSQ.OnNotifyHistoryTicks += new _ISKOSQuoteLibEvents_OnNotifyHistoryTicksEventHandler(skOSQEvent.OnNotifyHistoryTicks);
        }

        private void SubscribeSKOOQEvent()
        {
            skObj.skOOQ.OnConnect += new _ISKOOQuoteLibEvents_OnConnectEventHandler(skOOQEvent.OnConnect);
            skObj.skOOQ.OnNotifyQuote += new _ISKOOQuoteLibEvents_OnNotifyQuoteEventHandler(skOOQEvent.OnNotifyQuote);
            skObj.skOOQ.OnNotifyBest5 += new _ISKOOQuoteLibEvents_OnNotifyBest5EventHandler(skOOQEvent.OnNotifyBest5);
            skObj.skOOQ.OnNotifyTicks += new _ISKOOQuoteLibEvents_OnNotifyTicksEventHandler(skOOQEvent.OnNotifyTicks);
            skObj.skOOQ.OnNotifyHistoryTicks += new _ISKOOQuoteLibEvents_OnNotifyHistoryTicksEventHandler(skOOQEvent.OnNotifyHistoryTicks);
        }

        private void SubscribeSKREvent()
        {
            skObj.skR.OnConnect += new _ISKReplyLibEvents_OnConnectEventHandler(skREvent.OnConnect);
            skObj.skR.OnReplyMessage += new _ISKReplyLibEvents_OnReplyMessageEventHandler(skREvent.OnReplyMessage);
            skObj.skR.OnNewData += new _ISKReplyLibEvents_OnNewDataEventHandler(skREvent.OnNewData);
            skObj.skR.OnData += new _ISKReplyLibEvents_OnDataEventHandler(skREvent.OnData);
        }

        private void SubscribesAll()
        {
            SubscribeSKQEvent();
            SubscribeSKOEvent();
            SubscribeSKOSQEvent();
            SubscribeSKOOQEvent();
            SubscribeSKREvent();
        }

        private void NotifyNewOrder()
        {
            while (this.listenOrders)
            {
                try 
                {
                    var order = this.redis.lpop("Order");
                    if (order != null)
                    {
                        Thread.Sleep(1);
                    }
                }
                catch (Exception e)
                {
                    // Write error to log file
                    Thread.Sleep(1);
                    continue;
                }
                    
            }
        }

        private void NotifyFutureRights()
        {
            while (this.listenFutureRight)
            {
                try
                {
                    if (this.redis.lpop("FutureRights") != null)
                    {
                        int res = skObj.skO.GetFutureRights(this.user, this.skOEvent.myAccount["TF"], 1);
                        Console.WriteLine($"Request Future Right, {skObj.skC.SKCenterLib_GetReturnCodeMessage(res)}");
                        Thread.Sleep(1);
                    }
                }
                catch (Exception e)
                {
                    // Write error to log file
                    Thread.Sleep(1);
                    continue;
                }
            }
        }

        private void NotifyPosition()
        {
            while (this.listenPosition)
            {
                try
                {
                    if (this.redis.lpop("OpenInterest") != null)
                    {
                        int res = skObj.skO.GetOpenInterest(this.user, this.skOEvent.myAccount["TF"]);
                        Console.WriteLine($"Request OpenInterest, {skObj.skC.SKCenterLib_GetReturnCodeMessage(res)}");
                    }
                }
                catch (Exception e)
                {
                    // Write error to log file
                }
            }
        }

        private void NotifyStockFromRedis()
        {
            while (this.listenStock)
            {
                try
                {
                    List<string> new_stock = this.redis.lpop("Requests_stock");
                    if (new_stock != null)
                    {
                        //this.addStocks();
                        Thread.Sleep(1);
                    }
                }
                catch (Exception e)
                {
                    //write error to log file
                    Thread.Sleep(1);
                    continue;
                }
            }
        }

        private void NotifyOSStockFromRedis()
        {
            while (this.listenOSStock)
            {
                try
                {
                    List<string> new_stock = this.redis.lpop("Requests_os_stock");
                    if (new_stock != null)
                    {
                        //this.addOSStocks();
                        Thread.Sleep(1);
                    }
                }
                catch (Exception e)
                {
                    //write error to log file
                    Thread.Sleep(1);
                    continue;
                }
            }
        }


    }
}
