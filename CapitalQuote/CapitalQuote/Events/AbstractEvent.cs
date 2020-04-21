using System;
using System.Collections.Generic;
using System.Text;

namespace CapitalQuote
{
    abstract class AbstractEvent
    {
        public string name = "";
        public dynamic data;
        public AbstractEvent(dynamic data)
        {
            this.data = data;
        }

        public AbstractEvent(dynamic data, string name)
        {
            this.data = data;
            this.name = name;
        }
    }
}
