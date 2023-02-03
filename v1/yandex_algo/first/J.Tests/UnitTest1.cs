using NUnit.Framework;

namespace J.Tests
{
    public class Tests
    {
        [TestCase(8, "2 2 2")]
        [TestCase(13, "13")]
        [TestCase(100, "2 2 5 5")]
        [TestCase(917521579, "13 70578583")]
        public void Test1(int num, string result)
        {
            var actual = J.GetResult(num);
            Assert.AreEqual(result, actual);
        }
    }
}