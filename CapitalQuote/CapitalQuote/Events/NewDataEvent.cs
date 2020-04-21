using System;
using System.Collections.Generic;
using System.Text;

namespace CapitalQuote.Events
{
    class NewDataEvent : AbstractEvent
    {

        public readonly string type_ = "NewData";
        public readonly int priority = 2;

        public NewDataEvent(Dictionary<string, string> data) : base(data)
        {

        }
    }
}
