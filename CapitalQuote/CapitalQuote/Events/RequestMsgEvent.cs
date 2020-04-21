using System;
using System.Collections.Generic;
using System.Text;

namespace CapitalQuote.Events
{
    class RequestMsgEvent : AbstractEvent
    {
        public readonly string type_ = "RequestMsg";
        public readonly int priority = 5;

        public RequestMsgEvent(string data) : base(data)
        {

        }
    }
}
