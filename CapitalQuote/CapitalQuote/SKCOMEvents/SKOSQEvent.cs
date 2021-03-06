﻿using System;
using System.Collections.Generic;
using System.Text;
using CapitalQuote.Events;

namespace CapitalQuote
{
    class SKOSQEvent
    {
        public static ConnectionType osq_con = ConnectionType.Not;

        private EventManager eventManager;
        public SKOSQEvent(EventManager eventManager)
        {
            this.eventManager = eventManager;
        }
        public void OnConnect(int nKind, int nCode)
        {
            string strMsg = "OverSea Future ";
            if (nKind == 3001)
            {
                strMsg += "Connected";
                osq_con = ConnectionType.Not;
            }
            else if (nKind == 3002)
            {
                strMsg += "Disconnected";
                osq_con = ConnectionType.Not;
            }
            else if (nKind == 3003)
            {
                strMsg += "Stocks ready";
                osq_con = ConnectionType.Ready;
            }
            else if (nKind == 3021)
            {
                strMsg += "Connect Error";
                osq_con = ConnectionType.Error;
            }
            Console.WriteLine(strMsg);
            this.eventManager.put(new ConnectionEvent(osq_con, "OS"));
        }

        public void OnNotifyQuote(short sIndex)
        {
            skObj.skOSQ.SKOSQuoteLib_GetStockByIndex(sIndex, skObj.pOSstock);
            string dt = DateTime.Now.ToString();
            Dictionary<string, dynamic> q = new Dictionary<string, dynamic>
            {
                {"ID", String.Join(skObj.pOSstock.bstrExchangeNo, skObj.pOSstock.bstrStockNo)},
                {"Name", String.Join(skObj.pOSstock.bstrExchangeName, skObj.pOSstock.bstrStockName)},
                {"Date", dt.Split(" ")[0]},
                {"Time", dt.Split(" ")[1]},
                {"Close", skObj.pOSstock.nClose},
                {"Qty", skObj.pOSstock.nTickQty}
            };
            this.eventManager.put(new QuoteEvent(q));
        }

        public void OnNotifyBest5(short sStockidx, int nBestBid1, int nBestBidQty1, int nBestBid2, int nBestBidQty2, int nBestBid3, int nBestBidQty3, int nBestBid4, int nBestBidQty4, int nBestBid5, int nBestBidQty5
                                        , int nBestAsk1, int nBestAskQty1, int nBestAsk2, int nBestAskQty2, int nBestAsk3, int nBestAskQty3, int nBestAsk4, int nBestAskQty4, int nBestAsk5, int nBestAskQty5)
        {
            skObj.skOSQ.SKOSQuoteLib_GetStockByIndex(sStockidx, skObj.pOSstock);
            double denominator = Math.Pow(10, skObj.pOSstock.sDecimal);
            string dt = DateTime.Now.ToString();
            Dictionary<string, dynamic> best5 = new Dictionary<string, dynamic>
            {
                {"ID", String.Join(skObj.pOSstock.bstrExchangeNo, skObj.pOSstock.bstrStockNo)},
                {"Name", String.Join(skObj.pOSstock.bstrExchangeName, skObj.pOSstock.bstrStockName)},
                {"Date", dt.Split(" ")[0]},
                {"Time", dt.Split(" ")[1]},
                {"Pre-Close", skObj.pOSstock.nRef},
                {"BestBid1", nBestBid1 / denominator},
                {"BestBidQty1", nBestBidQty1},
                {"BestBid2", nBestBid2 / denominator},
                {"BestBidQty2", nBestBidQty2},
                {"BestBid3", nBestBid3 / denominator},
                {"BestBidQty3", nBestBidQty3},
                {"BestBid4", nBestBid4 / denominator},
                {"BestBidQty4", nBestBidQty4},
                {"BestBid5", nBestBid5 / denominator},
                {"BestBidQty5", nBestBidQty5},
                {"BestAsk1", nBestAsk1 / denominator},
                {"BestAskQty1", nBestAskQty1},
                {"BestAsk2", nBestAsk2 / denominator},
                {"BestAskQty2", nBestAskQty2},
                {"BestAsk3", nBestAsk3 / denominator},
                {"BestAskQty3", nBestAskQty3},
                {"BestAsk4", nBestAsk4 / denominator},
                {"BestAskQty4", nBestAskQty4},
                {"BestAsk5", nBestAsk5 / denominator},
                {"BestAskQty5", nBestAskQty5},
            };
            this.eventManager.put(new Best5Event(best5));
        }
    
        public void OnNotifyTicks(short sIndex, int nPtr, int nDate, int nTime, int nClose, int nQty)
        {
            skObj.skOSQ.SKOSQuoteLib_GetStockByIndex(sIndex, skObj.pOSstock);
            double denominator = Math.Pow(10, skObj.pOSstock.sDecimal);
            string date = Convert.ToString(nDate);
            string d = string.Join("-", date.Substring(0 ,4), date.Substring(4, 6), date.Substring(6, 8));
            Dictionary<string, dynamic> tick = new Dictionary<string, dynamic>
            {
                {"Date", d},
                {"Time", TransforFunc.timeToStr(nTime, 0)},
                {"ID", String.Join(skObj.pOSstock.bstrExchangeNo, skObj.pOSstock.bstrStockNo)},
                {"Name", String.Join(skObj.pOSstock.bstrExchangeName, skObj.pOSstock.bstrStockName)},
                {"Close", nClose / denominator},
                {"Qty", nQty},
            };
            this.eventManager.put(new TickEvent(tick));
        }

        public void OnNotifyHistoryTicks(short sIndex, int nPtr, int nDate, int nTime, int nClose, int nQty)
        {
            skObj.skOSQ.SKOSQuoteLib_GetStockByIndex(sIndex, skObj.pOSstock);
            double denominator = Math.Pow(10, skObj.pOSstock.sDecimal);
            string date = Convert.ToString(nDate);
            string d = string.Join("-", date.Substring(0, 4), date.Substring(4, 6), date.Substring(6, 8));
            Dictionary<string, dynamic> tick = new Dictionary<string, dynamic>
            {
                {"Date", d},
                {"Time", TransforFunc.timeToStr(nTime, 0)},
                {"ID", String.Join(skObj.pOSstock.bstrExchangeNo, skObj.pOSstock.bstrStockNo)},
                {"Name", String.Join(skObj.pOSstock.bstrExchangeName, skObj.pOSstock.bstrStockName)},
                {"Close", nClose / denominator},
                {"Qty", nQty},
            };
            this.eventManager.put(new HistoryTickEvent(tick));
        }
    }
}
