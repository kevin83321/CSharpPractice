using System;
using System.Collections.Generic;
using System.Text;

namespace CapitalQuote.Events
{
    class OSHistoryTickEvent : AbstractEvent
    {
        public readonly string type_ = "OS_History_Tick";
        public readonly int priority = 5;

        public OSHistoryTickEvent(Dictionary<string, dynamic> data) : base(data)
        {

        }
    }
}
