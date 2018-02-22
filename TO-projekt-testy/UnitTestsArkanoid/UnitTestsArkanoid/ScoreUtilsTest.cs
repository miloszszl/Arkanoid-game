using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.InteropServices;
using UnityEngine;
using System.IO;

namespace UnitTestsArkanoid
{
    [TestClass]
    public class ScoreUtilsTest
    {
        [TestMethod]
        public void ScoreUtilsExceptionTest1()
        {
            string expected = "The file could not be read";
            ScoreUtils.ScoresFileName = "ble.pl";
            string tested = ScoreUtils.GetScoresFromDB("bleble");
            Assert.AreEqual(expected,tested);
        }

        [TestMethod]
        public void ScoreUtilsExceptionTest2()
        {
            string notExpected = "The file could not be read";
            ScoreUtils.ScoresFileName = "Scores.txt";
            string tested = ScoreUtils.GetScoresFromDB("../../db");
            Assert.AreNotEqual(notExpected, tested);
        }
    }
}
