using System;
using System.Collections.Generic;
using System.Text;

namespace CapitalQuote.Events
{
    class FutureRightsEvent : AbstractEvent
    {
        public readonly string type_ = "FutureRights";
        public readonly int priority = 1;

        public FutureRightsEvent(Dictionary<string, dynamic> data) : base(data)
        {

        }
    }
}
