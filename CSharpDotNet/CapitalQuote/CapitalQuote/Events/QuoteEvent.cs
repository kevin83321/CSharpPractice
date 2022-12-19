using System;
using System.Collections.Generic;
using System.Text;

namespace CapitalQuote.Events
{
    class QuoteEvent : AbstractEvent
    {
        public readonly string type_ = "QUOTE";
        public readonly int priority = 5;
        // public readonly Dictionary<string, dynamic> data;
        public QuoteEvent(Dictionary<string, dynamic> data) : base(data)
        {
            //this.data = data;
        }
    }
}
