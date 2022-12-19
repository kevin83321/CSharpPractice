using System;
using System.Collections.Generic;
using System.Text;

namespace CapitalQuote.Events
{
    class Best5Event : AbstractEvent
    {
        public readonly string type_ = "BEST5";
        public readonly int priority = 5;
        // public readonly Dictionary<string, dynamic> data;
        public Best5Event(Dictionary<string, dynamic> data): base(data)
        {
            //this.data = data;
        }
    }
}
