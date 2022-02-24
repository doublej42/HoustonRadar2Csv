using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoustonRadar2Csv
{
    internal class OutputCSV
    {
        public List<TrafficDataPoint> Data = new();
        public void WriteFile(string filename)
        {
            //TODO, write file
            using var outFile = new StreamWriter(filename);
            outFile.WriteLine("Time,Direction,Class,Speed");
            foreach(var dp in Data)
            {
                
                outFile.WriteLine($"{dp.Time},{dp.Direction},{dp.Class},{dp.Speed}");
            }
        }
    }
}
