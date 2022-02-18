using Assignment.ConsoleApp;
using NUnit.Framework;

namespace Assignment.UnitTests
{
    public class ListProcessorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestName()
        {
            string name = "testName";
            string last = "testLast";

            var retVal = ListProcessor.PrepareList(1, 100, name, last);
            Assert.AreEqual(name, retVal[2], "Wrong replacement of Name");
        }

        [Test]
        public void TestLastName()
        {
            string name = "testName";
            string last = "testLast";

            var retVal = ListProcessor.PrepareList(1, 100, name, last);
            Assert.AreEqual(last, retVal[4], "Wrong replacement of LastName");
        }

        [Test]
        public void TestNameLastName()
        {
            string name = "testName";
            string last = "testLast";

            var retVal = ListProcessor.PrepareList(1, 100, name, last);
            Assert.AreEqual($"{name}{last}", retVal[14], "Wrong replacement of Name and LastName");
        }       
    }
}