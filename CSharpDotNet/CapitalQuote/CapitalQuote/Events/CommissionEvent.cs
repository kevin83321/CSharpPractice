using System;
using System.Collections.Generic;
using System.Text;

namespace CapitalQuote.Events
{
    class CommissionEvent : AbstractEvent
    {
        public readonly string type_ = "Commission";
        public readonly int priority = 5;

        public CommissionEvent(Dictionary<string, dynamic> data) : base(data)
        {

        }
    }
}
