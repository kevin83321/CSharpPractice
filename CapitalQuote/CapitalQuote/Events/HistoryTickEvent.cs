using System;
using System.Collections.Generic;
using System.Text;

namespace CapitalQuote.Events
{
    class HistoryTickEvent : AbstractEvent
    {
        public readonly string type_ = "History_Tick";
        public readonly int priority = 5;

        public HistoryTickEvent(Dictionary<string, dynamic> data) : base(data)
        {

        }
    }
}
