using NUnit.Framework;

namespace K.Tests
{
    public class Tests
    {
        [TestCase(new[] {1, 2, 0, 0}, new[] {34}, "1 2 3 4")]
        [TestCase(new[] {9, 5}, new[] {17}, "1 1 2")]
        public void Test1(int[] num1, int[] num2, string result)
        {
            var actual = K.GetResult(num1, num2);
            Assert.AreEqual(result, actual);
        }
    }
}