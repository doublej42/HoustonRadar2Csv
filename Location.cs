using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoustonRadar2Csv
{
    internal class Location
    {
        public int Id { get; internal set; }
        public string Mainstreet { get; internal set; }
        public string Sidestreet { get; internal set; }
        public double Latitude { get; internal set; }
        public double Longitude { get; internal set; }
        public int INT_ID { get; internal set; }
        public string OWNER { get; internal set; }
        public string FTYPE { get; internal set; }
        public string[] Oriantation { get; internal set; }
    }
}
