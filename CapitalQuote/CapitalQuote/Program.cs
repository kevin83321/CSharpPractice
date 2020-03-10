using System;
using SKCOMLib;

namespace CapitalQuote
{
    class Program
    {
        static void Main(string[] args)
        {
            skObj.skQ.OnConnection += new _ISKQuoteLibEvents_OnConnectionEventHandler(SKQEvent.OnConnection);
            string user = "F128497445";
            string pwd = "j7629864";
            // SKCOMObject.skC.SK
            int m_nCode = skObj.skC.SKCenterLib_Login(user, pwd);
            string skmsg = skObj.skC.SKCenterLib_GetReturnCodeMessage(m_nCode);
            Console.WriteLine(skmsg);
        }
    }
}
