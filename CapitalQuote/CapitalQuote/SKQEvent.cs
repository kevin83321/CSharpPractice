using System;
using System.Collections.Generic;
using System.Text;

namespace CapitalQuote
{
    class SKQEvent
    {
        public static ConnectionType connected = ConnectionType.Not;
        
        private static readonly Dictionary<int, string> marketType = new Dictionary<int, string>
        {
            {0,"STOCK" }, {1,"STOCK" }, {2,"FUTURE" }, {3,"OPTION" }, {4,"OTC" }, {9999,"END" } };

        public static readonly Dictionary<string, string> typeDict = new Dictionary<string, string> { };
        public static void OnConnection(int nKind, int nCode)
        {
            string strMsg = "";
            if (nKind == 3001)
            {
                if (nCode == 0)
                {
                    strMsg += "Login Success";
                    connected = ConnectionType.Connected;
                }
            } 
            else if (nKind == 3002)
            {
                strMsg +=  "Login Failed";
                connected = ConnectionType.Failed;
            }
            else if (nKind == 3003)
            {
                strMsg +=  "EnterMonitor Success";
                connected = ConnectionType.Ready;
            }
            else if (nKind == 3021)
            {
                strMsg +=  "The Problem with Internet";
                connected = ConnectionType.Error;
            }
            Console.WriteLine(strMsg);
        }
        
        public static void OnNotifyQuote(short sMarketNo, short sStockIdx)
        {
            skObj.skQ.SKQuoteLib_GetStockByIndex(sMarketNo, sStockIdx, ref skObj.pstock);
            skObj.skQ.SKQuoteLib_GetBest5(sMarketNo, sStockIdx, ref skObj.best5);
            string[] dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff").Split(" ");
            Dictionary<string, dynamic> quote = new Dictionary<string, dynamic>
            {
                {"ID", skObj.pstock.bstrStockNo},
                {"Name", skObj.pstock.bstrStockName},
                {"Date", dt[0]},
                {"Time", dt[1]},
                {"High", skObj.pstock.nHigh / 100.0},
                {"Open", skObj.pstock.nOpen / 100.0},
                {"Low", skObj.pstock.nLow / 100.0},
                {"Close", skObj.pstock.nClose / 100.0},
                {"Qty", skObj.pstock.nTickQty},
                {"Pre-Close", skObj.pstock.nRef / 100.0},
                {"Bid", skObj.pstock.nBid / 100.0},
                {"BidQty", skObj.pstock.nBc},
                {"Ask", skObj.pstock.nAsk / 100.0},
                {"AskQty", skObj.pstock.nAc},
                {"TotalBidQty", skObj.pstock.nTBc},
                {"TotalAskQty", skObj.pstock.nTAc},
                {"FutureOI", skObj.pstock.nFutureOI},
                {"TotalQty", skObj.pstock.nTQty},
                {"YesterdayQty", skObj.pstock.nYQty},
                {"Up", skObj.pstock.nUp / 100.0},
                {"Down", skObj.pstock.nDown / 100.0},
                {"Simulate", skObj.pstock.nSimulate}
            };

            Dictionary<string, dynamic> best5 = new Dictionary<string, dynamic>
            {
                {"ID", skObj.pstock.bstrStockNo},
                {"Name", skObj.pstock.bstrStockName},
                {"Date", dt[0]},
                {"Time", dt[1]},
                {"Pre-Close", skObj.pstock.nRef / 100.0},
                {"BestBid1", skObj.best5.nBid1 / 100.0},
                {"BestBidQty1", skObj.best5.nBidQty1},
                {"BestBid2", skObj.best5.nBid2 / 100.0},
                {"BestBidQty2", skObj.best5.nBidQty2},
                {"BestBid3", skObj.best5.nBid3 / 100.0},
                {"BestBidQty3", skObj.best5.nBidQty3},
                {"BestBid4", skObj.best5.nBid4 / 100.0},
                {"BestBidQty4", skObj.best5.nBidQty4},
                {"BestBid5", skObj.best5.nBid5 / 100.0},
                {"BestBidQty5", skObj.best5.nBidQty5},
                {"BestAsk1", skObj.best5.nAsk1 / 100.0},
                {"BestAskQty1", skObj.best5.nAskQty1},
                {"BestAsk2", skObj.best5.nAsk2 / 100.0},
                {"BestAskQty2", skObj.best5.nAskQty2},
                {"BestAsk3", skObj.best5.nAsk3 / 100.0},
                {"BestAskQty3", skObj.best5.nAskQty3},
                {"BestAsk4", skObj.best5.nAsk4 / 100.0},
                {"BestAskQty4", skObj.best5.nAskQty4},
                {"BestAsk5", skObj.best5.nAsk5 / 100.0},
                {"BestAskQty5", skObj.best5.nAskQty5},
            };
            //foreach (KeyValuePair<string, dynamic> kvp in quote)
            //   Console.WriteLine("{0}:{1}", kvp.Key, kvp.Value);
            //Console.WriteLine("" + quote);
            //Console.WriteLine("" + sMarketNo + "," + sStockIdx + "," + skObj.pstock.bstrStockNo + "," + skObj.pstock.bstrStockName + "," + Close + "," + dt);
        }
        
        public static void OnNotifyTicks(short sMarketNo, short sStockIdx, int nPtr, int nDate, int Timehms, int Timemillismicros, int nBid, int nAsk, int nClose, int nQty, int nSimulate)
        {
            skObj.skQ.SKQuoteLib_GetStockByIndex(sMarketNo, sStockIdx, ref skObj.pstock);
            string t = TransforFunc.timeToStr(Timehms, Timemillismicros);
            string d = TransforFunc.dateToStr(nDate);
            Dictionary<string, dynamic> tick = new Dictionary<string, dynamic>
            {
                {"Date", d },
                {"Time", t },
                {"ID", skObj.pstock.bstrStockNo},
                {"Name", skObj.pstock.bstrStockName},
                {"Close", nClose / 100.0 },
                {"Ask", nAsk / 100.0 },
                {"Bid", nBid / 100.0 },
                {"Qty", nQty},
                {"Pre-Close", skObj.pstock.nRef / 100.0},
                {"Simulate", nSimulate}
            };
            //Console.WriteLine("" + sMarketNo + "," + sStockIdx + "," + skObj.pstock.bstrStockNo + "," + skObj.pstock.bstrStockName + "," + Close + "," + dt);
            
        }

        public static void OnNotifyHistoryTicks(short sMarketNo, short sStockIdx, int nPtr, int nDate, int Timehms, int Timemillismicros, int nBid, int nAsk, int nClose, int nQty, int nSimulate)
        {
            skObj.skQ.SKQuoteLib_GetStockByIndex(sMarketNo, sStockIdx, ref skObj.pstock);
            string t = TransforFunc.timeToStr(Timehms, Timemillismicros);
            string d = TransforFunc.dateToStr(nDate);
            Dictionary<string, dynamic> tick = new Dictionary<string, dynamic>
            {
                {"Date", d },
                {"Time", t },
                {"ID", skObj.pstock.bstrStockNo},
                {"Name", skObj.pstock.bstrStockName},
                {"Close", nClose / 100.0 },
                {"Ask", nAsk / 100.0 },
                {"Bid", nBid / 100.0 },
                {"Qty", nQty},
                {"Pre-Close", skObj.pstock.nRef / 100.0},
                {"Simulate", nSimulate}
            };
        }
        
        public static void OnNotifyBest5(short sMarketNo, short sStockIdx, int nBestBid1, int nBestBidQty1, int nBestBid2, int nBestBidQty2, int nBestBid3, int nBestBidQty3, int nBestBid4, int nBestBidQty4, int nBestBid5, int nBestBidQty5, int nExtendBid, int nExtendBidQty, int nBestAsk1, int nBestAskQty1, int nBestAsk2, int nBestAskQty2, int nBestAsk3, int nBestAskQty3, int nBestAsk4, int nBestAskQty4, int nBestAsk5, int nBestAskQty5, int nExtendAsk, int nExtendAskQty, int nSimulate)
        {
            skObj.skQ.SKQuoteLib_GetStockByIndex(sMarketNo, sStockIdx, ref skObj.pstock);
            double denominator = Math.Pow(10, skObj.pOSstock.sDecimal);
            string[] dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff").Split(" ");
            Dictionary<string, dynamic> best5 = new Dictionary<string, dynamic>
            {
                {"ID", skObj.pstock.bstrStockNo},
                {"Name", skObj.pstock.bstrStockName},
                {"Date", dt[0]},
                {"Time", dt[1]},
                {"Pre-Close", skObj.pstock.nRef / 100.0},
                {"BestBid1", nBestBid1 / 100.0},
                {"BestBidQty1", nBestBidQty1},
                {"BestBid2", nBestBid2 / 100.0},
                {"BestBidQty2", nBestBidQty2},
                {"BestBid3", nBestBid3 / 100.0},
                {"BestBidQty3", nBestBidQty3},
                {"BestBid4", nBestBid4 / 100.0},
                {"BestBidQty4", nBestBidQty4},
                {"BestBid5", nBestBid5 / 100.0},
                {"BestBidQty5", nBestBidQty5},
                {"BestAsk1", nBestAsk1 / 100.0},
                {"BestAskQty1", nBestAskQty1},
                {"BestAsk2", nBestAsk2 / 100.0},
                {"BestAskQty2", nBestAskQty2},
                {"BestAsk3", nBestAsk3 / 100.0},
                {"BestAskQty3", nBestAskQty3},
                {"BestAsk4", nBestAsk4 / 100.0},
                {"BestAskQty4", nBestAskQty4},
                {"BestAsk5", nBestAsk5 / 100.0},
                {"BestAskQty5", nBestAskQty5},
            };
        }
        
        public static void OnNotifyKLineData(string bstrStockNo, string bstrData)
        {
            Console.WriteLine("Origin Kline " + bstrData + "" + bstrStockNo);
            // TODO transfor kline information
        }

        public static void OnNotifyStockList(short sMarketNo, string bstrStockData)
        {
            foreach (var stock in bstrStockData.Split(";"))
                if (marketType.ContainsKey(sMarketNo))
                    typeDict.Add(stock, marketType[sMarketNo]);
        }
    }
}
