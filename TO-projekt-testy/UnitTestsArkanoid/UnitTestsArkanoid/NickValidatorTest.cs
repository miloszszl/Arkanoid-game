using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestsArkanoid
{
    [TestClass]
    public class NickValidatorTest
    {
        [TestMethod]
        [ExpectedException(typeof(Exception), "To short")]
        public void NickTest1()
        {
            NickValidator.CheckNick("");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "To long (limit: 20 chars)")]
        public void NickTest2()
        {
            NickValidator.CheckNick("sdaczczxvfdaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        }

        [TestMethod]
        public void NickTest3()
        {
            try
            {
                NickValidator.CheckNick("milosz");
            }catch(Exception)
            {
                Assert.Fail();
            }
        }

    }
}