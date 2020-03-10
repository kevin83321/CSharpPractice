using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using SKCOMLib;

namespace CapitalQuote
{
    class skObj
    {
        public static SKCenterLib skC = new SKCenterLib();
        public static SKQuoteLib skQ = new SKQuoteLib();
        public static SKOSQuoteLib skOSQ = new SKOSQuoteLib();
        public static SKOOQuoteLib skOOQ = new SKOOQuoteLib();
        public static SKReplyLib skR = new SKReplyLib();
        public static SKOrderLib skO = new SKOrderLib();
        public static SKSTOCK pstock = new SKSTOCK();
        public static SKFOREIGN pOSstock = new SKFOREIGN();
    }
}
