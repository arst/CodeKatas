using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeKatas.DataMunging
{
    public class WeatherMungler : DataMunglerBase
    {
        private struct DayWeather
        {
            public int Day { get; set; }
            public int MinTemp { get; set; }
            public int MaxTemp { get; set; }
        }

        private readonly List<DayWeather> data = new List<DayWeather>();

        private readonly Regex dataExtractor = new Regex(@"(^\d+)\s+(\d+)\s+(\d+)\s+(\d+)");

        protected override string DataFile { get => "Data/weather.dat";  }

        protected override Regex DataExtractor { get => dataExtractor; }

        public override void ProcessDataEntry(MatchCollection values)
        {
            this.data.Add(new DayWeather() {
                Day = Int32.Parse(values[0].Groups[1].Value),
                MaxTemp = Int32.Parse(values[0].Groups[2].Value),
                MinTemp = Int32.Parse(values[0].Groups[3].Value)}
            );
        }

        public int GetMinimumSpreadDay()
        {
            return this.data.OrderBy(d => d.MaxTemp - d.MinTemp).First().Day;
        }
    }
}
