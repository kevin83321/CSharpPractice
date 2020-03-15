using System;
using System.IO;
using SKCOMLib;
using System.Threading;

namespace CapitalQuote
{
    class Program
    {
        // public SKQEvent skqE = new SKQEvent();
        static void Main(string[] args)
        {
            SubscribeSKQEvent();
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

            while (SKQEvent.connected != ConnectionType.Ready)
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

        private static void SubscribeSKQEvent()
        {
            skObj.skQ.OnConnection += new _ISKQuoteLibEvents_OnConnectionEventHandler(SKQEvent.OnConnection);
            skObj.skQ.OnNotifyQuote += new _ISKQuoteLibEvents_OnNotifyQuoteEventHandler(SKQEvent.OnNotifyQuote);
            skObj.skQ.OnNotifyTicks += new _ISKQuoteLibEvents_OnNotifyTicksEventHandler(SKQEvent.OnNotifyTicks);
            skObj.skQ.OnNotifyStockList += new _ISKQuoteLibEvents_OnNotifyStockListEventHandler(SKQEvent.OnNotifyStockList);
        }
    }
}
