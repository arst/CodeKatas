﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeKatas.Karateday1Search.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeKatas.KarateChop;

namespace CodeKatas.Karateday1Search.Search.Tests
{
    [TestClass()]
    public class SimpleBinarySearchTests
    {
        [TestMethod()]
        public void SearchTest()
        {
            SimpleBinarySearch day1Search = new SimpleBinarySearch();
            Assert.AreEqual(-1, day1Search.Search(3, new int[0]));
            Assert.AreEqual(-1, day1Search.Search(3, new int[1] { 1 }));
            Assert.AreEqual(0, day1Search.Search(1, new int[1] { 1 }));
            Assert.AreEqual(0, day1Search.Search(1, new int[3] { 1, 3, 5 }));
            Assert.AreEqual(1, day1Search.Search(3, new int[3] { 1, 3, 5 }));
            Assert.AreEqual(2, day1Search.Search(5, new int[3] { 1, 3, 5 }));
            Assert.AreEqual(-1, day1Search.Search(0, new int[3] { 1, 3, 5 }));
            Assert.AreEqual(-1, day1Search.Search(2, new int[3] { 1, 3, 5 }));
            Assert.AreEqual(-1, day1Search.Search(4, new int[3] { 1, 3, 5 }));
            Assert.AreEqual(-1, day1Search.Search(6, new int[3] { 1, 3, 5 }));

            Assert.AreEqual(0, day1Search.Search(1, new int[4] { 1, 3, 5, 7 }));
            Assert.AreEqual(1, day1Search.Search(3, new int[4] { 1, 3, 5, 7 }));
            Assert.AreEqual(2, day1Search.Search(5, new int[4] { 1, 3, 5, 7 }));
            Assert.AreEqual(3, day1Search.Search(7, new int[4] { 1, 3, 5, 7 }));
            Assert.AreEqual(-1, day1Search.Search(0, new int[4] { 1, 3, 5, 7 }));
            Assert.AreEqual(-1, day1Search.Search(2, new int[4] { 1, 3, 5, 7 }));
            Assert.AreEqual(-1, day1Search.Search(4, new int[4] { 1, 3, 5, 7 }));
            Assert.AreEqual(-1, day1Search.Search(6, new int[4] { 1, 3, 5, 7 }));
            Assert.AreEqual(-1, day1Search.Search(8, new int[4] { 1, 3, 5, 7 }));
        }
    }
}