using System;
using System.Collections.Generic;
using System.Text;

namespace CapitalQuote
{
    class TransforFunc
    {
        public static string timeToStr(int nTimehms, int nTimemillismicros = 0)
        {
            float ssdec = nTimehms % 100;
            nTimehms /= 100;
            float mmdec = nTimehms % 100;
            nTimehms /= 100;
            float hhdec = nTimehms;
            return string.Format("{0:00}:{1:00}:{2:00}.{3:000000}", hhdec, mmdec, ssdec, nTimemillismicros);
        }

        public static string dateToStr(int nDate)
        {
            string d = Convert.ToString(nDate);
            string y = d.Substring(0, 4);
            string m = d.Substring(4, 2);
            string dd = d.Substring(6, 2);
            return String.Join("-", y, m, dd);
        }
    }
}
