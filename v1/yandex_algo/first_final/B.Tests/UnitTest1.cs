using NUnit.Framework;

namespace B.Tests
{
    public class Tests
    {
        [TestCase(new[] {"1231", "2..2", "2..2", "2..2"}, 3, 2)]
        [TestCase(new[] {"1111", "9999", "1111", "9911"}, 4, 1)]
        [TestCase(new[] {"1111", "1111", "1111", "1111"}, 4, 0)]
        public void Test1(string[] inputStrings, int k, int result)
        {
            var actual = B.Calculate(inputStrings, k);
            Assert.AreEqual(result, actual);
        }
    }
}