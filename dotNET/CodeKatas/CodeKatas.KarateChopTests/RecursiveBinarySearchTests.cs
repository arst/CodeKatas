using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeKatas.KarateChop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeKatas.KarateChop.Tests
{
    [TestClass()]
    public class RecursiveBinarySearchTests
    {
        [TestMethod()]
        public void SearchTest()
        {
            RecursiveBinarySearch day2Search = new RecursiveBinarySearch();
            Assert.AreEqual(-1, day2Search.Search(3, new int[0]));
            Assert.AreEqual(-1, day2Search.Search(3, new int[1] { 1 }));
            Assert.AreEqual(0, day2Search.Search(1, new int[1] { 1 }));
            Assert.AreEqual(0, day2Search.Search(1, new int[3] { 1, 3, 5 }));
            Assert.AreEqual(1, day2Search.Search(3, new int[3] { 1, 3, 5 }));
            Assert.AreEqual(2, day2Search.Search(5, new int[3] { 1, 3, 5 }));
            Assert.AreEqual(-1, day2Search.Search(0, new int[3] { 1, 3, 5 }));
            Assert.AreEqual(-1, day2Search.Search(2, new int[3] { 1, 3, 5 }));
            Assert.AreEqual(-1, day2Search.Search(4, new int[3] { 1, 3, 5 }));
            Assert.AreEqual(-1, day2Search.Search(6, new int[3] { 1, 3, 5 }));

            Assert.AreEqual(0, day2Search.Search(1, new int[4] { 1, 3, 5, 7 }));
            Assert.AreEqual(1, day2Search.Search(3, new int[4] { 1, 3, 5, 7 }));
            Assert.AreEqual(2, day2Search.Search(5, new int[4] { 1, 3, 5, 7 }));
            Assert.AreEqual(3, day2Search.Search(7, new int[4] { 1, 3, 5, 7 }));
            Assert.AreEqual(-1, day2Search.Search(0, new int[4] { 1, 3, 5, 7 }));
            Assert.AreEqual(-1, day2Search.Search(2, new int[4] { 1, 3, 5, 7 }));
            Assert.AreEqual(-1, day2Search.Search(4, new int[4] { 1, 3, 5, 7 }));
            Assert.AreEqual(-1, day2Search.Search(6, new int[4] { 1, 3, 5, 7 }));
            Assert.AreEqual(-1, day2Search.Search(8, new int[4] { 1, 3, 5, 7 }));
        }
    }
}