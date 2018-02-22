using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestsArkanoid
{
    [TestClass]
    public class ConverterUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception), "No results")]
        public void ConverterTest1()
        {
            string text = "";
            List<KeyValuePair<string,int>> converted=TextConverter.strToOrderedStructure(text);
        }

        [TestMethod]
        public void ConverterTest2()
        {
            string text = "milosz 111\nagnieszka 222";
            List<KeyValuePair<string, int>> tested = TextConverter.strToOrderedStructure(text);
            List<KeyValuePair<string, int>> expected=new List<KeyValuePair<string, int>>();
            foreach (KeyValuePair<string, int> x in tested)
            {
                Console.Write(Environment.NewLine + x.Key + " " + x.Value);
            }
            expected.Add(new KeyValuePair<string, int>("agnieszka", 222));
            expected.Add(new KeyValuePair<string, int>("milosz",111));
            foreach (KeyValuePair<string, int> x in expected)
            {
                Console.Write( Environment.NewLine + x.Key + " " + x.Value);
            }

            Assert.AreEqual(expected.Count,tested.Count);
            Assert.AreEqual(expected[0], tested[0]);
            Assert.AreEqual(expected[1], tested[1]);
        }
    
    }

}
