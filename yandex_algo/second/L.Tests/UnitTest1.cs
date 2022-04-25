using NUnit.Framework;

namespace L.Tests
{
    public class Tests
    {
        [TestCase(0, 1, 1)]
        [TestCase(1, 1, 1)]
        [TestCase(2, 1, 2)]
        [TestCase(3, 1, 3)]
        [TestCase(4, 1, 5)]
        [TestCase(5, 1, 8)]
        [TestCase(6, 1, 3)]
        [TestCase(10, 1, 9)]
        public void Test1(int n, int k, int expected)
        {
            var actual = L.GetResult(n, k);
            Assert.AreEqual(expected, actual);
        }
    }
}