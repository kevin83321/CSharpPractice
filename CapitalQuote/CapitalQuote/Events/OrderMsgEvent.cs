using System;
using System.Collections.Generic;
using System.Text;

namespace CapitalQuote.Events
{
    class OrderMsgEvent : AbstractEvent
    {

        public readonly string type_ = "OrderMsg";
        public readonly int priority = 4;

        public OrderMsgEvent(string data) : base(data)
        {

        }
    }
}
