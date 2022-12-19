using System;
using System.Collections.Generic;
using System.Text;

namespace CapitalQuote.Events
{
    class OSQuoteEvent : AbstractEvent
    {

        public readonly string type_ = "OS_Quote";
        public readonly int priority = 5;

        public OSQuoteEvent(Dictionary<string, dynamic> data) : base(data)
        {

        }
    }
}
