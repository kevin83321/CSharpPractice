using System;
using System.Collections.Generic;
using System.Text;

namespace CapitalQuote.Events
{
    class RealBalanceReportEvent : AbstractEvent
    {
        public readonly string type_ = "RealBalanceReport";
        public readonly int priority = 3;

        public RealBalanceReportEvent(Dictionary<string, dynamic> data) : base(data)
        {

        }
    }
}
