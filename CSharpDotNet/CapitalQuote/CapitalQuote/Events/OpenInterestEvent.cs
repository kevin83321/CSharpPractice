using System;
using System.Collections.Generic;
using System.Text;

namespace CapitalQuote.Events
{
    class OpenInterestEvent : AbstractEvent
    {

        public readonly string type_ = "OpenInterest";
        public readonly int priority = 3;

        public OpenInterestEvent(Dictionary<string, dynamic> data) : base(data)
        {

        }
    }
}
