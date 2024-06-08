using System;
using NUnit.Framework;

namespace IdentifiableObject
{
    [TestFixture]
    public class IdentifiableObjectTest
    {
        private IdentifiableObject testObj;
        private string testStr;
        private string[] testArr;

        private IdentifiableObject testObj_arg;
        private string testStr_arg;
        private string[] testArr_arg;

        [SetUp]
        public void Setup()
        {
            testStr = "Phuc";
            testArr = new string[] { "Phuc", "Bao" };
            testObj = new IdentifiableObject(testArr);
            testObj.AddIdentifier(testStr);
            testStr_arg = "";
            testArr_arg = new string[] { };
            testObj_arg = new IdentifiableObject(testArr_arg);
            testObj_arg.AddIdentifier(testStr_arg);
        }

        [Test]
        public void TestAreYou()
        {
            Assert.IsTrue(testObj.AreYou(testStr));
        }

        [Test]
        public void TestNotAreYou()
        {
            Assert.IsFalse(testObj.AreYou("An"));
        }

        [Test]
        public void Insensitive()
        {
            Assert.IsTrue(testObj.AreYou("PHUC"));
        }

        [Test]
        public void TestFirstId()
        {
            Assert.AreEqual("phuc", testObj.FirstID);
            Assert.AreNotEqual("Duck", testObj.FirstID);
        }

        [Test]
        public void TestFirstIdWithNoId()
        {
            Assert.AreEqual("", testObj_arg.FirstID);
        }

        [Test]
        public void TestAddID()
        {
            testObj.AddIdentifier("An");
            testObj.AddIdentifier("Dung");
            Assert.IsTrue(testObj.AreYou("An"));
            Assert.IsTrue(testObj.AreYou("Dung"));
        }
    }
}
