using System;
using System.Collections.Generic;
using System.Text;

namespace CapitalQuote.Events
{
    class StockListEvent : AbstractEvent
    {

        public readonly string type_ = "StockList";
        public readonly int priority = 2;

        public StockListEvent(Dictionary<string, dynamic> data) : base(data)
        {

        }
    }
}
