using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeKatas.DataMunging
{
    public abstract class DataMunglerBase
    {
        protected abstract Regex DataExtractor { get; }
        protected abstract string DataFile { get;}
        public DataMunglerBase()
        {
            Init();
        }
        
        public void Init()
        {
            foreach (var entry in File.ReadAllLines(DataFile))
            {
                var preparedLine = entry.TrimEnd(' ').TrimStart(' ');
                var values = DataExtractor.Matches(preparedLine);
                if (DataExtractor.IsMatch(preparedLine))
                {
                    this.ProcessDataEntry(values);
                }
            }
        }

        public abstract void ProcessDataEntry(MatchCollection entry);
    }
}
