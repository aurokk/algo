using NUnit.Framework;

namespace F.Tests
{
    public class Tests
    {
        [TestCase("A man, a plan, a canal: Panama", "True")]
        [TestCase("zo", "False")]
        public void Test1(string text, string result)
        {
            var actual = F.GetResult(text);
            Assert.AreEqual(result, actual);
        }
    }
}