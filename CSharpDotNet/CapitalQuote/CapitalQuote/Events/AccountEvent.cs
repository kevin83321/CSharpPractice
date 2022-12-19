using System;
using System.Collections.Generic;
using System.Text;

namespace CapitalQuote.Events
{
    class AccountEvent : AbstractEvent
    {
        public readonly string type_ = "Account";
        public readonly int priority = 3;
        public AccountEvent(Dictionary<string, string> data) : base(data)
        {

        }
    }
}
