using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoustonRadar2Csv
{
    internal class TrafficDataPoint
    {
        internal string Direction { get; set; }
        internal string Class { get; set; }
        internal string Time { get; set; }
        internal string Speed { get; set; }
    }
}
