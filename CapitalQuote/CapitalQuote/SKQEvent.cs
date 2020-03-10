using System;
using System.Collections.Generic;
using System.Text;

namespace CapitalQuote
{
    class SKQEvent
    {
        public static void OnConnection(int nKind, int nCode)
        {
            if (nKind == 3001)
            {
                if (nCode == 0)
                {
                    Console.WriteLine("Login Success");
                }
            } 
            else if (nKind == 3002)
            {
                Console.WriteLine("Login Failed");
            }
            else if (nKind == 3003)
            {
                Console.WriteLine("EnterMonitor Success");
            }
            else if (nKind == 3021)
            {
                Console.WriteLine("The Problem with Internet");
            }
        }
        public static void OnNotifyQuote(short sMarketNo, short sStockIdx)
        {
            skObj.skQ.SKQuoteLib_GetStockByIndex(sMarketNo, sStockIdx, ref skObj.pstock);
        }
        public static void OnNotifyTicks(short sMarketNo, short sStockIdx, int nPtr, int nDate, int Timehms, int Timemillismicros, int nBid, int nAsk, int nClose, int nQty, int nSimulation)
        {
            // TODO edit time to Time obj

            // TODO transfor Tick information
        }

        public static void OnNotifyHistoryTicks(short sMarketNo, short sStockIdx, int nPtr, int nDate, int lTimehms, int lTimemillismicros, int nBid, int nAsk, int nClose, int nQty, int nSimulate)
        {
            // TODO edit time to Time obj

            // TODO transfor Tick information
        }
        public static void OnNotifyBest5(short sMarketNo, short sStockIdx, int nBestBid1, int nBestBidQty1, int nBestBid2, int nBestBidQty2, int nBestBid3, int nBestBidQty3, int nBestBid4, int nBestBidQty4, int nBestBid5, int nBestBidQty5, int nExtendBid, int nExtendBidQty, int nBestAsk1, int nBestAskQty1, int nBestAsk2, int nBestAskQty2, int nBestAsk3, int nBestAskQty3, int nBestAsk4, int nBestAskQty4, int nBestAsk5, int nBestAskQty5, int nExtendAsk, int nExtendAskQty, int nSimulate)
        {
            // TODO edit time to Time obj

            // TODO transfor Best5 information
        }
        public static void OnNotifyKLineData(string bstrStockNo, string bstrData)
        {
            // TODO transfor kline information
        }
    }
}
