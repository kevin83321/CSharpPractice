using System;
using System.Collections.Generic;
using System.Text;
using CapitalQuote.Events;

namespace CapitalQuote
{
    class SKREvent
    {
        // 商品-類型
        private static readonly Dictionary<string, string> markettype = new Dictionary<string, string>
        {
            {"TS", "證券"},{"TA", "盤後"},{"TL", "零股"},{"TF", "期貨"},
            {"TO", "選擇權"},{"OF", "海期"},{"OO", "海選"},{"OS", "複委託"}};
        // 股票-委託形式
        private static readonly Dictionary<string, string> stockOrder = new Dictionary<string, string>
        {
            {"00", "現股"},{"01", "代資"},{"02", "代券"},{"03", "融資"},
            {"04", "融券"}, {"20" ,"零股"}, {"40" ,"拍賣現股"} };
        // 期貨/選擇權-倉別
        private static readonly Dictionary<string, string> OI = new Dictionary<string, string>
        {
            {"Y", "當沖"},{"N", "新倉"},{"O", "平倉"},{"7", "代沖銷"},{"A", "盤中"}, {"B" ,"預約"}};
        // 期貨/選擇權-委託價別, 海外-委託價別
        private static readonly Dictionary<string, string> OrderPrice = new Dictionary<string, string>
        {
            {"1", "市價"},{"2", "限價"},{"3", "停損"},{"4", "停損限價"},{"5", "收市"}};
        // 期貨/選擇權-委託類別
        private static readonly Dictionary<string, string> FOrderType = new Dictionary<string, string>
        {
            {"I", "IOC"},{"R", "ROD"},{"F", "FOK"}};
        // 買賣類型轉換
        private static readonly Dictionary<string, string> bsType = new Dictionary<string, string>
        {
            {"B", "買進"},{"S", "賣出"}};
        // 海外-倉別
        private static readonly Dictionary<string, string> OverSeaOI = new Dictionary<string, string>
        {
            {"Y", "當沖"},{"N", "新倉"},{"O", "平倉"}};
        // 下單-類別
        private static readonly Dictionary<string, string> OrderType = new Dictionary<string, string>
        {
            {"N", "委託"},{"C", "取消"},{"U", "改量"},{"P", "改價"},{"D", "成交"},{"B", "改價改量"}, {"S", "動態退單" } };
        // 下單-狀態
        private static readonly Dictionary<string, string> OrderStatus = new Dictionary<string, string>
        {
            {"Y", "失敗"},{"T", "逾時"},{"N", "正常"}};
        // 盤別
        private static readonly Dictionary<string, string> reserved = new Dictionary<string, string>
        {
            {"A", "T盤"},{"B", "T+1盤"}}; // 其他 -> 盤中
        // 股票-類別
        private static string[] stocktype = new string[] { "TS", "TA", "TL" };
        // 選擇權與期貨-類別
        private static string[] fotype = new string[] { "TF", "TO"};
        // 海外選擇權與期貨-類別
        private static string[] OverSeatype = new string[] { "OS", "OO" };
        private EventManager eventManager;
        public SKREvent(EventManager eventManager)
        {
            this.eventManager = eventManager;
        }
        public void OnConnect(string bstrUserID, int nErrorCode)
        {
            Console.WriteLine(bstrUserID + " " + nErrorCode);
        }

        public void OnReplyMessage(string bstrUserID, string bstrMessage)
        {
            Console.WriteLine(bstrUserID + " " + bstrMessage);
        }
        
        // 下單回傳New
        public void OnNewData(string bstrUserID, string bstrData)
        {
            string[] data = bstrData.Split(",");
            string bs = "";
            if (Array.Exists(stocktype, element => element == data[1])) // 股票
            {
                bs += stockOrder.GetValueOrDefault(data[6].Substring(1), "退單"); // 委託
                bs += bsType[data[0]]; // 買賣別
            }
            else if (Array.Exists(fotype, element => element == data[1])) // 期貨與選擇權
            {
                bs += OI[data[6].Substring(1, 1)]; // 倉別
                bs += OrderPrice.GetValueOrDefault(data[6].Substring(3, 1), "退單"); // 委託價
                bs += bsType[data[6].Substring(0, 1)]; // 買賣別
                bs += FOrderType[data[6].Substring(2, 1)];
            }
            else if (Array.Exists(OverSeatype, element => element == data[1]))
            {
                bs += OverSeaOI[data[6].Substring(1, 1)];
                bs += bsType[data[6].Substring(0, 1)];
                bs += OrderPrice.GetValueOrDefault(data[6].Substring(3, 1), "退單"); // 委託價
            }
            Dictionary<string, string> newdata = new Dictionary<string, string>
            {
                {"KeyNo", data[0]},
                {"MarketType", markettype[data[1]]},
                {"Type", OrderType[data[2]]},
                {"OrderErr", OrderStatus[data[3]]},
                {"Broker", data[4]},
                {"CustNo", data[5]},
                {"BuySell", bs},
                {"ExchangeID", data[7]},
                {"ComId", data[8]},
                {"StrikePrice", data[9]},
                {"OrderNo", data[10]},
                {"Price", data[11]},
                {"Numerator", data[12]},
                {"Denominator", data[13]},
                {"Price1", data[14]},
                {"Numerator1", data[15]},
                {"Denominator1", data[16]},
                {"Price2", data[17]},
                {"Numerator2", data[18]},
                {"Denominator2", data[19]},
                {"Qty", data[20]},
                {"BeforeQty", data[21]},
                {"AfterQty", data[22]},
                {"Date", data[23]},
                {"Time", data[24]},
                {"OkSeq", data[25]},
                {"SubID", data[26]},
                {"SaleNo", data[27]},
                {"Agent", data[28]},
                {"TradeDate", data[29]},
                {"MsgNo", data[30]},
                {"PreOrder", data[31]},
                {"ComId1", data[32]},
                {"YearMonth1", data[33]},
                {"StrikePrice1", data[34]},
                {"ComId2", data[35]},
                {"YearMonth2", data[36]},
                {"StrikePrice2", data[37]},
                {"ExecutionNo", data[38]},
                {"PriceSymbol", data[39]},
                {"Reserved", reserved.GetValueOrDefault(data[40], "盤中")},
                {"OrderEffective", data[41]},
                {"CallPut", data[42]},
                {"OrderError", data[43]}
            };
            eventManager.put(new NewDataEvent(newdata));
        }
        // 下單回傳
        public void OnData(string bstrUserID, string bstrData)
        {
            string[] data = bstrData.Split(",");
            string bs = "";
            if (Array.Exists(stocktype, element => element == data[1])) // 股票
            {
                bs += stockOrder.GetValueOrDefault(data[6].Substring(1), "退單"); // 委託
                bs += bsType[data[0]]; // 買賣別
            }
            else if (Array.Exists(fotype, element => element == data[1])) // 期貨與選擇權
            {
                bs += OI[data[6].Substring(1, 1)]; // 倉別
                bs += OrderPrice.GetValueOrDefault(data[6].Substring(3, 1), "退單"); // 委託價
                bs += bsType[data[6].Substring(0, 1)]; // 買賣別
                bs += FOrderType[data[6].Substring(2, 1)];
            }
            else if (Array.Exists(OverSeatype, element => element == data[1]))
            {
                bs += OverSeaOI[data[6].Substring(1, 1)];
                bs += bsType[data[6].Substring(0, 1)];
                bs += OrderPrice.GetValueOrDefault(data[6].Substring(3, 1), "退單"); // 委託價
            }
            Dictionary<string, string> newdata = new Dictionary<string, string>
            {
                { "KeyNo", data[0] },
                { "MarketType", markettype[data[1]] },
                { "Type", OrderType[data[2]] },
                { "OrderErr", OrderStatus[data[3]] },
                { "Broker", data[4] },
                { "CustNo", data[5] },
                { "BuySell", bs },
                { "ExchangeID", data[7] },
                { "ComId", data[8] },
                { "StrikePrice", data[9] },
                { "OrderNo", data[10] },
                { "Price", data[11] },
                { "Numerator", data[12] },
                { "Denominator", data[13] },
                { "Price1", data[14] },
                { "Numerator1", data[15] },
                { "Denominator1", data[16] },
                { "Price2", data[17] },
                { "Numerator2", data[18] },
                { "Denominator2", data[19] },
                { "Qty", data[20] },
                { "BeforeQty", data[21] },
                { "AfterQty", data[22] },
                { "Date", data[23] },
                { "Time", data[24] },
                { "OkSeq", data[25] },
                { "SubID", data[26] },
                { "SaleNo", data[27] },
                { "Agent", data[28] },
                { "TradeDate", data[29] },
                { "MsgNo", data[30] },
                { "PreOrder", data[31] },
                { "ComId1", data[32] },
                { "YearMonth1", data[33] },
                { "StrikePrice1", data[34] },
                { "ComId2", data[35] },
                { "YearMonth2", data[36] },
                { "StrikePrice2", data[37] },
                { "ExecutionNo", data[38] },
                { "PriceSymbol", data[39] },
                { "Reserved", reserved.GetValueOrDefault(data[40], "盤中") },
                { "OrderEffective", data[41] },
                { "CallPut", data[42] },
                { "OrderError", data[43] }
            };
        }
    }
}
