using System;
using System.Collections.Generic;
using System.Text;

namespace CapitalQuote.Events
{
    class InfoEvent : AbstractEvent
    {
        public readonly string type_ = "Info";
        public readonly int priority = 5;
        
        public InfoEvent(Dictionary<string, dynamic> data) : base(data)
        {

        }
    }
}
