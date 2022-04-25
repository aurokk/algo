using NUnit.Framework;

namespace L.Tests
{
    public class Tests
    {
        [TestCase("abcd", "abcde", "e")]
        [TestCase("go", "ogg", "g")]
        public void Test1(string str1, string str2, string result)
        {
            var actual = L.GetResult(str1, str2);
            Assert.AreEqual(result, actual);
        }
    }
}