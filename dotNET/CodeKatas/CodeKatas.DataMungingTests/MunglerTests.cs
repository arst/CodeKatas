using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeKatas.DataMunging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeKatas.DataMunging.Tests
{
    [TestClass()]
    public class WheatherMunglerTests
    {
        [TestMethod()]
        public void GetDayWithSmallestSpreadTest()
        {
            WeatherMungler wMungler = new WeatherMungler();
            FootballMungler fMungler = new FootballMungler();
            var wResult = wMungler.GetMinimumSpreadDay();
            var fResult = fMungler.GetSmallestSpreadInGoaalsTeam();
            Assert.AreEqual(wResult, 14);
            Assert.AreEqual(fResult, "Leicester");
        }
    }
}