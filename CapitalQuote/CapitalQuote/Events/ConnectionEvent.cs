using System;
using System.Collections.Generic;
using System.Text;

namespace CapitalQuote.Events
{
    class ConnectionEvent : AbstractEvent
    {
        public readonly string type_ = "Connection";
        public readonly int priority = 1;

        public ConnectionEvent(ConnectionType data, string name) : base(data, name)
        {

        }
    }
}
