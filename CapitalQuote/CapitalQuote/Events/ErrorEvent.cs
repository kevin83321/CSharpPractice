using System;
using System.Collections.Generic;
using System.Text;

namespace CapitalQuote
{
    class ErrorEvent : AbstractEvent
    {
        public readonly string type_ = "ERROR";
        public readonly int priority = 2;

        public ErrorEvent(string data) : base(data)
        {
            
        }
    }
}
