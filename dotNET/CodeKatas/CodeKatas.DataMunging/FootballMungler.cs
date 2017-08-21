using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeKatas.DataMunging
{
    public class FootballMungler : DataMunglerBase
    {
        private readonly Regex dataExtractor = new Regex(@"(^\d+)\.\s(\w+)\s+(\d+)\s+(\d+)\s+(\d+)\s+(\d+)\s+(\d+)\s+-\s+(\d+)");
        private readonly List<TeamScore> data = new List<TeamScore>();

        private struct TeamScore
        {
            public string Name { get; set; }
            public int GoalsForTeam { get; set; }
            public int GoalsToTeam { get; set; }
        }

        protected override Regex DataExtractor => this.dataExtractor;

        protected override string DataFile => "Data/football.dat";

        public override void ProcessDataEntry(MatchCollection values)
        {
            this.data.Add(new TeamScore() {
                Name = values[0].Groups[2].Value,
                GoalsForTeam = Int32.Parse(values[0].Groups[7].Value),
                GoalsToTeam = Int32.Parse(values[0].Groups[8].Value)
            });
        }

        public string GetSmallestSpreadInGoaalsTeam()
        {
            return data.OrderBy(team => team.GoalsForTeam = team.GoalsToTeam).Last().Name;
        }
    }
}
