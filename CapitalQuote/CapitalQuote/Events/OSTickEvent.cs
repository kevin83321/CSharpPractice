using System;
using System.Collections.Generic;
using System.Text;

namespace CapitalQuote.Events
{
    class OSTickEvent : AbstractEvent
    {

        public readonly string type_ = "OS_Tick";
        public readonly int priority = 5;

        public OSTickEvent(Dictionary<string, dynamic> data) : base(data)
        {

        }
    }
}
