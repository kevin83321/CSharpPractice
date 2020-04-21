using System;
using System.Collections.Generic;
using System.Text;

namespace CapitalQuote.Events
{
    class ProfitReportEvent : AbstractEvent
    {
        public readonly string type_ = "ProfitReport";
        public readonly int priority = 3;
        public ProfitReportEvent(Dictionary<string, dynamic> data): base(data)
        {

        }
    }
}
