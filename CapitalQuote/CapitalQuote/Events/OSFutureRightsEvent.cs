using System;
using System.Collections.Generic;
using System.Text;

namespace CapitalQuote.Events
{
    class OSFutureRightsEvent : AbstractEvent
    {
        public readonly string type_ = "OSFutureRight";
        public readonly int priority = 1;

        public OSFutureRightsEvent(Dictionary<string, dynamic> data) : base(data)
        {

        }
    }
}
