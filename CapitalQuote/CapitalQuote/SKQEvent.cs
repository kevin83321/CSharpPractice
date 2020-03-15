using System;
using System.Collections.Generic;
using System.Text;

namespace CapitalQuote
{
    class SKQEvent
    {
        public static ConnectionType connected = ConnectionType.Not;

        public static void OnConnection(int nKind, int nCode)
        {
            if (nKind == 3001)
            {
                if (nCode == 0)
                {
                    Console.WriteLine("Login Success");
                    connected = ConnectionType.Connected;
                }
            } 
            else if (nKind == 3002)
            {
                Console.WriteLine("Login Failed");
                connected = ConnectionType.Failed;
            }
            else if (nKind == 3003)
            {
                Console.WriteLine("EnterMonitor Success");
                connected = ConnectionType.Ready;
            }
            else if (nKind == 3021)
            {
                Console.WriteLine("The Problem with Internet");
                connected = ConnectionType.Error;
            }
        }
        public static void OnNotifyQuote(short sMarketNo, short sStockIdx)
        {
            skObj.skQ.SKQuoteLib_GetStockByIndex(sMarketNo, sStockIdx, ref skObj.pstock);
            float Close = Convert.ToSingle(skObj.pstock.nClose / 100.0);
            Console.WriteLine("" + sMarketNo + "," + sStockIdx + "," + skObj.pstock.bstrStockNo + "," + skObj.pstock.bstrStockName + "," + Close);
        }
        public static void OnNotifyTicks(short sMarketNo, short sStockIdx, int nPtr, int nDate, int Timehms, int Timemillismicros, int nBid, int nAsk, int nClose, int nQty, int nSimulation)
        {
            skObj.skQ.SKQuoteLib_GetStockByIndex(sMarketNo, sStockIdx, ref skObj.pstock);
            string dt = timeToStr(Timehms, Timemillismicros);
            float Close = Convert.ToSingle(skObj.pstock.nClose / 100.0);
            Console.WriteLine("" + sMarketNo + "," + sStockIdx + "," + skObj.pstock.bstrStockNo + "," + skObj.pstock.bstrStockName + "," + Close + "," + dt);
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

        public static void OnNotifyStockList(short sMarketNo, string bstrStockData)
        {
            //TODO transfor Stocklist
        }

        public static string timeToStr(int nTimehms, int nTimemillismicros)
        {
            float ssdec = nTimehms % 100;
            nTimehms /= 100;
            float mmdec = nTimehms % 100;
            nTimehms /= 100;
            float hhdec = nTimehms;
            return string.Format("{0:00}:{1:00}:{2:00}.{3:000000}", hhdec, mmdec, ssdec, nTimemillismicros);
        }
    }
}
