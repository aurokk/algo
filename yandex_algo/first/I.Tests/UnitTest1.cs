using NUnit.Framework;

namespace I.Tests
{
    public class Tests
    {
        [TestCase(1, "True")]
        [TestCase(4, "True")]
        [TestCase(15, "False")]
        [TestCase(16, "True")]
        [TestCase(64, "True")]
        public void Test1(int num, string result)
        {
            var actual = I.GetResult(num);
            Assert.AreEqual(result, actual);
        }
    }
}