using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CapitalQuote
{
    class SKOEvent
    {
        public static readonly Dictionary<string, string> myAccount;

        public static void OnAccount(string sLoginID, string sAccountData)
        {
            string[] Accounts = sAccountData.Split(",");
            myAccount.Add(Accounts[1] + Accounts[3], Accounts[0]);
            
        }
        public static void OnFutureRights(string bstrData)
        {
            if (bstrData.StartsWith("##") != true)
            {
                string[] data = bstrData.Split(",");
                Dictionary<string, dynamic> futurerights = new Dictionary<string, dynamic>
                {
                    {"帳戶餘額", Convert.ToSingle(data[0]) / 100},
                    {"浮動損益", Convert.ToSingle(data[1]) / 100 },
                    {"已實現費用", Convert.ToSingle(data[2]) / 100 },
                    {"交易稅", Convert.ToSingle(data[3]) / 100 },
                    {"預扣權利金", Convert.ToSingle(data[4]) / 100 },
                    {"權利金收付", Convert.ToSingle(data[5]) / 100 },
                    {"權益數", Convert.ToSingle(data[6]) / 100 },
                    {"超額保證金", Convert.ToSingle(data[7]) / 100 },
                    {"存提款", Convert.ToSingle(data[8]) / 100 },
                    {"買方市值", Convert.ToSingle(data[9]) / 100 },
                    {"賣方市值", Convert.ToSingle(data[10]) / 100 },
                    {"期貨平倉損益", Convert.ToSingle(data[11]) / 100 },
                    {"盤中未實現", Convert.ToSingle(data[12]) / 100 },
                    {"原始保證金", Convert.ToSingle(data[13]) / 100 },
                    {"維持保證金", Convert.ToSingle(data[14]) / 100 },
                    {"部位原始保證金", Convert.ToSingle(data[15]) / 100 },
                    {"部位維持保證金", Convert.ToSingle(data[16]) / 100 },
                    {"委託保證金", Convert.ToSingle(data[17]) / 100 },
                    {"超額最佳保證金", Convert.ToSingle(data[18]) / 100 },
                    {"權利總值", Convert.ToSingle(data[19]) / 100 },
                    {"預扣費用", Convert.ToSingle(data[20]) / 100 },
                    {"原始保證金2", Convert.ToSingle(data[21]) / 100 },
                    {"昨日餘額", Convert.ToSingle(data[22]) / 100 },
                    {"選擇權組合單加不加收保證金", Convert.ToSingle(data[23]) / 100 },
                    {"維持率", Convert.ToSingle(data[24]) / 100 },
                    {"幣別", data[25] },
                    {"足額原始保證金", Convert.ToSingle(data[26]) / 100 },
                    {"足額維持保證金", Convert.ToSingle(data[27]) / 100 },
                    {"足額可用", Convert.ToSingle(data[28]) / 100 },
                    {"抵繳金額", Convert.ToSingle(data[29]) / 100 },
                    {"有價可用", Convert.ToSingle(data[30]) / 100 },
                    {"超額保證金2", Convert.ToSingle(data[31]) / 100 },
                    {"足額現金可用", Convert.ToSingle(data[32]) / 100 },
                    {"有價價值", Convert.ToSingle(data[33]) / 100 },
                    {"風險指標", Convert.ToSingle(data[34]) / 100 },
                    {"選擇權到期差異", Convert.ToSingle(data[35]) / 100 },
                    {"選擇權到期差損", Convert.ToSingle(data[36]) / 100 },
                    {"期貨到期損益", Convert.ToSingle(data[37]) / 100 },
                    {"加收保證金", Convert.ToSingle(data[38]) / 100 }
                };
            }
        }
    }
}
