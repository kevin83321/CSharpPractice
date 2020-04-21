using System;
using System.Collections.Generic;
using System.Text;

namespace CapitalQuote.Events
{
    class TickEvent : AbstractEvent
    {
        public readonly string type_ = "Tick";
        public readonly int priority = 5;
        
        public TickEvent(Dictionary<string, dynamic> data) : base(data)
        {

        }
    }
}
