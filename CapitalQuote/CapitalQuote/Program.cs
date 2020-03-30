using System;
using System.IO;
using SKCOMLib;
using System.Threading;
using System.Collections.Generic;

namespace CapitalQuote
{
    class Program
    {
        static void Main(string[] args)
        {
            // RedisConnector redis = new RedisConnector();
            SubscribesAll();
            string user = "F128497445";
            string pwd = "j7629864";
            // SKCOMObject.skC.SK
            string logpath = System.Environment.CurrentDirectory; // 取得當前執行檔的目錄
            skObj.skC.SKCenterLib_SetLogPath(Path.Combine(logpath, "Capital_Log"));
            // Login
            int m_nCode = skObj.skC.SKCenterLib_Login(user, pwd);
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
            m_nCode = skObj.skO.ReadCertByID(user);
            skmsg = skObj.skC.SKCenterLib_GetReturnCodeMessage(m_nCode);
            Console.WriteLine("Read Certification : " + skmsg);

            //ConnectByID
            m_nCode = skObj.skR.SKReplyLib_ConnectByID(user);
            skmsg = skObj.skC.SKCenterLib_GetReturnCodeMessage(m_nCode);
            Console.WriteLine("Reply Server ConnectByID : " + skmsg);

            while (SKQEvent.connected != ConnectionType.Ready && SKOSQEvent.osq_con != ConnectionType.Ready && SKOOQEvent.ooq_con != ConnectionType.Ready)
            {
                Thread.Sleep(1000);
            }

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
        private static void SubscribeSKQEvent()
        {
            skObj.skQ.OnConnection += new _ISKQuoteLibEvents_OnConnectionEventHandler(SKQEvent.OnConnection);
            skObj.skQ.OnNotifyQuote += new _ISKQuoteLibEvents_OnNotifyQuoteEventHandler(SKQEvent.OnNotifyQuote);
            skObj.skQ.OnNotifyTicks += new _ISKQuoteLibEvents_OnNotifyTicksEventHandler(SKQEvent.OnNotifyTicks);
            skObj.skQ.OnNotifyStockList += new _ISKQuoteLibEvents_OnNotifyStockListEventHandler(SKQEvent.OnNotifyStockList);
            skObj.skQ.OnNotifyHistoryTicks += new _ISKQuoteLibEvents_OnNotifyHistoryTicksEventHandler(SKQEvent.OnNotifyHistoryTicks);
            skObj.skQ.OnNotifyKLineData += new _ISKQuoteLibEvents_OnNotifyKLineDataEventHandler(SKQEvent.OnNotifyKLineData);
            skObj.skQ.OnNotifyBest5 += new _ISKQuoteLibEvents_OnNotifyBest5EventHandler(SKQEvent.OnNotifyBest5);
        }

        private static void SubscribeSKOEvent()
        {
            skObj.skO.OnAccount += new _ISKOrderLibEvents_OnAccountEventHandler(SKOEvent.OnAccount);
            skObj.skO.OnFutureRights += new _ISKOrderLibEvents_OnFutureRightsEventHandler(SKOEvent.OnFutureRights);
            skObj.skO.OnRequestProfitReport += new _ISKOrderLibEvents_OnRequestProfitReportEventHandler(SKOEvent.OnRequestProfitReport);
            skObj.skO.OnOverSeaFutureRight += new _ISKOrderLibEvents_OnOverSeaFutureRightEventHandler(SKOEvent.OnOverSeaFutureRight);
            skObj.skO.OnBalanceQuery += new _ISKOrderLibEvents_OnBalanceQueryEventHandler(SKOEvent.OnBalanceQuery);
            skObj.skO.OnOpenInterest += new _ISKOrderLibEvents_OnOpenInterestEventHandler(SKOEvent.OnOpenInterest);
            skObj.skO.OnRealBalanceReport += new _ISKOrderLibEvents_OnRealBalanceReportEventHandler(SKOEvent.OnRealBalanceReport);
        }

        private static void SubscribeSKOSQEvent()
        {
            skObj.skOSQ.OnConnect += new _ISKOSQuoteLibEvents_OnConnectEventHandler(SKOSQEvent.OnConnect);
            skObj.skOSQ.OnNotifyQuote += new _ISKOSQuoteLibEvents_OnNotifyQuoteEventHandler(SKOSQEvent.OnNotifyQuote);
            skObj.skOSQ.OnNotifyBest5 += new _ISKOSQuoteLibEvents_OnNotifyBest5EventHandler(SKOSQEvent.OnNotifyBest5);
            skObj.skOSQ.OnNotifyTicks += new _ISKOSQuoteLibEvents_OnNotifyTicksEventHandler(SKOSQEvent.OnNotifyTicks);
            skObj.skOSQ.OnNotifyHistoryTicks += new _ISKOSQuoteLibEvents_OnNotifyHistoryTicksEventHandler(SKOSQEvent.OnNotifyHistoryTicks);
        }

        private static void SubscribeSKOOQEvent()
        {
            skObj.skOOQ.OnConnect += new _ISKOOQuoteLibEvents_OnConnectEventHandler(SKOOQEvent.OnConnect);
            skObj.skOOQ.OnNotifyQuote += new _ISKOOQuoteLibEvents_OnNotifyQuoteEventHandler(SKOOQEvent.OnNotifyQuote);
            skObj.skOOQ.OnNotifyBest5 += new _ISKOOQuoteLibEvents_OnNotifyBest5EventHandler(SKOOQEvent.OnNotifyBest5);
            skObj.skOOQ.OnNotifyTicks += new _ISKOOQuoteLibEvents_OnNotifyTicksEventHandler(SKOOQEvent.OnNotifyTicks);
            skObj.skOOQ.OnNotifyHistoryTicks += new _ISKOOQuoteLibEvents_OnNotifyHistoryTicksEventHandler(SKOOQEvent.OnNotifyHistoryTicks);
        }

        private static void SubscribeSKREvent()
        {
            skObj.skR.OnConnect += new _ISKReplyLibEvents_OnConnectEventHandler(SKREvent.OnConnect);
            skObj.skR.OnReplyMessage += new _ISKReplyLibEvents_OnReplyMessageEventHandler(SKREvent.OnReplyMessage);
            skObj.skR.OnNewData += new _ISKReplyLibEvents_OnNewDataEventHandler(SKREvent.OnNewData);
            skObj.skR.OnData += new _ISKReplyLibEvents_OnDataEventHandler(SKREvent.OnData);
        }

        private static void SubscribesAll()
        {
            SubscribeSKQEvent();
            SubscribeSKOEvent();
            SubscribeSKOSQEvent();
            SubscribeSKOOQEvent();
            SubscribeSKREvent();
        }
    }
}
