using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CapitalQuote
{
    class SKOEvent
    {
        public static Dictionary<string, string> myAccount = new Dictionary<string, string> {};

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

        public static void OnRequestProfitReport(string bstrData)
        {
            // 證券即時損益試算
            // Call GetRequestProfitReport(bstrLogInID, bstrAccount)

            if (bstrData.StartsWith("##") != true)
            {
                string[] data = bstrData.Split(",");
                Dictionary<string, dynamic> profitreport = new Dictionary<string, dynamic>
                {
                    { "券商代號", data[0]},
                    { "帳號", data[1]},
                    { "股票代號", data[2]},
                    { "交易種類", data[3]},
                    { "庫存股數",  Convert.ToSingle(data[4])},
                    { "市價",  Convert.ToSingle(data[5])},
                    { "市值",  Convert.ToSingle(data[6])},
                    { "淨值",  (data[7] != "--") ? Convert.ToSingle(data[7]) : 0.0},
                    { "損益",  (data[8] != "--") ? Convert.ToSingle(data[8]) : 0.0},
                    { "平均成本",  (data[9] != "--") ? Convert.ToSingle(data[9]) : 0.0},
                    { "付出成本",  (data[10] != "--") ? Convert.ToSingle(data[10]) : 0.0},
                    { "成交價金",  data[11]},
                    { "手續費",  data[12]},
                    { "預估手續費",  data[13]},
                    { "交易稅",  data[14]},
                    { "預估交易稅",  data[15]},
                    { "自備款/保證金",  data[16]},
                    { "融資金/擔保品",  data[17]},
                    { "預估利息",  (data[18] != "--") ? Convert.ToSingle(data[18]) : 0.0},
                    { "試算報酬率",  (data[19] != "--") ? Convert.ToSingle(data[19]) : 0.0},
                    { "未知成本股數",  data[20]},
                };
            }
        }

        public static void OnOverSeaFutureRight(string bstrData)
        {
            // 證券即時損益試算
            // Call GetRequestProfitReport(bstrLogInID, bstrAccount)

            if (bstrData.StartsWith("##") != true)
            {
                string[] data = bstrData.Split(",");
                if (data[0] == "000")
                {
                    Dictionary<string, dynamic> osfutureRights = new Dictionary<string, dynamic>
                    {
                        { "期貨商代號", data[1]},
                        { "IB 代號", data[2]},
                        { "帳號", data[3]},
                        { "幣別",  data[4]},
                        { "風險指標/維持率",  data[5]},
                        { "足額維持率",  data[6]},
                        { "可動用(出金)保證金",  data[7]},
                        { "委託保證金",  data[8]},
                        { "維持保證金",  data[9]},
                        { "原始保證金",  data[10]},
                        { "淨值權益數、權益總值",  data[11]},
                        { "預扣權利金",  data[12]},
                        { "未沖銷買方選擇權市值",  data[13]},
                        { "未沖銷賣方選擇權市值",  data[14]},
                        { "帳戶權益、權益數",  data[15]},
                        { "盤中未實現",  data[16]},
                        { "未沖銷期貨浮動損益",  data[17]},
                        { "今日權利金支付",  data[18]},
                        { "本日期貨平倉損益淨額",  data[19]},
                        { "已實現費用、手續費",  data[20]},
                        { "今日存提款",  data[21]},
                        { "前日帳戶餘額",  data[22]},
                        { "參考匯率",  data[23]},
                        { "選擇權到期差異",  data[24]},
                        { "選擇權到期差損",  data[25]},
                        { "期貨交割損益",  data[26]},
                        { "超額/追繳保證金",  data[27]},
                        { "到期履約損益",  data[28]},
                        { "帳戶餘額",  data[29]},
                        { "固定保證金",  data[30]},
                        { "變動保證金",  data[31]},
                    };
                }

            }
        }

        public static void OnBalanceQuery(string bstrData)
        {
            if (bstrData.StartsWith("M003"))
            {
                Console.WriteLine("No Query");
            }
            else
            {
                string[] data = bstrData.Split(",");
                Dictionary<string, dynamic> query = new Dictionary<string, dynamic>
                {
                    {"證券帳號", data[0] },
                    {"股票代號", data[1] },
                    {"股票股數", data[2] },
                    {"融資股數", data[3] },
                    {"融資金額", data[4] },
                    {"融券股數", data[5] },
                    {"融券金額", data[6] },
                    {"保證金", data[7] },
                    {"擔保品", data[8] },
                };
            }
        }

        public static void OnOpenInterest(string bstrData)
        {
            if (bstrData.StartsWith("M003"))
            {
                Console.WriteLine("No OI");
            }
            else
            {
                Dictionary<string, string> bs_map = new Dictionary<string, string>
                {
                    { "B", "BUY"},{"S", "SELL"}
                };
                string[] data = bstrData.Split(",");
                Dictionary<string, dynamic> oi = new Dictionary<string, dynamic>
                {
                    {"市場別", data[0] },
                    {"帳號", data[1] },
                    {"商品", data[2] },
                    {"買賣別", bs_map[data[3]] },
                    {"未平倉部位", Convert.ToSingle(data[4]) },
                    {"當沖未平倉部位", Convert.ToSingle(data[5]) },
                    {"平均成本", Convert.ToSingle(data[6]) / 100 },
                    {"一點價值", Convert.ToSingle(data[7]) },
                    {"單口手續費", Convert.ToSingle(data[8]) },
                    {"交易稅(萬分之X)", Convert.ToSingle(data[9]) },
                };
            }
        }

        public static void OnRealBalanceReport(string bstrData)
        {
            if (bstrData.StartsWith("##") != true)
            {
                Dictionary<string, string> store_type = new Dictionary<string, string>
                {
                    { "T", "集保"},{"C", "融資"},{"L", "融券"}
                };
                string[] data = bstrData.Split(",");
                Dictionary<string, dynamic> rbr = new Dictionary<string, dynamic>
                {
                    {"股票代號", data[0] },
                    {"庫存種類", store_type[data[1]] },
                    {"資額度(原始)", data[2] },
                    {"資額度(可用)", data[3] },
                    {"券額度(原始)", Convert.ToSingle(data[4]) },
                    {"券額度(可用)", Convert.ToSingle(data[5]) },
                    {"股數", Convert.ToSingle(data[6]) },
                    {"今日委買", Convert.ToSingle(data[7]) },
                    {"今日委賣", Convert.ToSingle(data[8]) },
                    {"今日買進成交", Convert.ToSingle(data[9]) },
                    {"今日賣出成交", Convert.ToSingle(data[10]) },
                    {"今日資券可回補/集保可賣出", Convert.ToSingle(data[11]) },
                    {"可資沖股數", Convert.ToSingle(data[12]) },
                    {"可券沖股數", Convert.ToSingle(data[13]) },
                    {"即時庫存", Convert.ToSingle(data[14]) },
                    {"即時個股維持率", Convert.ToSingle(data[15]) },
                };
            }
        }
    }
}
