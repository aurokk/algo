using NUnit.Framework;

namespace K.Tests
{
    public class Tests
    {
        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(4, 5)]
        [TestCase(5, 8)]
        [TestCase(6, 13)]
        public void Test1(int n, int expected)
        {
            var actual = K.GetResult(n);
            Assert.AreEqual(expected, actual);
        }
    }
}