using NUnit.Framework;

namespace E.Tests
{
    public class Tests
    {
        [TestCase("i love segment tree", "segment")]
        [TestCase("frog jumps from river", "jumps")]
        [TestCase("frog", "frog")]
        public void Test1(string text, string result)
        {
            var actual = E.GetResult(text);
            Assert.AreEqual(result, actual);
        }
    }
}