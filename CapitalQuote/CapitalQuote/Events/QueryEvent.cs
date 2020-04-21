using System;
using System.Collections.Generic;
using System.Text;

namespace CapitalQuote
{
    class QueryEvent : AbstractEvent
    {
        public readonly string type_ = "Query";
        public readonly int priority = 3;

        public QueryEvent(Dictionary<string, dynamic> data) : base(data)
        {

        }
    }
}
