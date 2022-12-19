using System;
using System.Collections.Generic;
using System.Text;

namespace CapitalQuote.Events
{
    class OriginKLineEvent : AbstractEvent
    {
        public readonly string type_ = "Origin_Kline";
        public readonly int priority = 5;

        public OriginKLineEvent(Dictionary<string, dynamic> data) : base(data)
        {
            
        }
    }
}
