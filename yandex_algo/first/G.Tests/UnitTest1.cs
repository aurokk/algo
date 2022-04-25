using NUnit.Framework;

namespace G.Tests
{
    public class Tests
    {
        [TestCase(5, "101")]
        [TestCase(14, "1110")]
        [TestCase(0, "0")]
        [TestCase(1, "1")]
        [TestCase(2, "10")]
        public void Test1(int number, string result)
        {
            var actual = F.GetResult(number);
            Assert.AreEqual(result, actual);
        }
    }
}