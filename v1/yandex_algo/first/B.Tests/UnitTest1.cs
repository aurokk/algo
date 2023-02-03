using NUnit.Framework;

namespace B.Tests
{
    public class Tests
    {
        [TestCase(new[] {0, 0, 0}, "WIN")]
        [TestCase(new[] {0, 0, 1}, "FAIL")]
        [TestCase(new[] {0, 0, -1}, "FAIL")]
        [TestCase(new[] {0, 1, 1}, "FAIL")]
        [TestCase(new[] {1, 1, 1}, "WIN")]
        [TestCase(new[] {2, 2, 2}, "WIN")]
        [TestCase(new[] {1, 2, -3}, "FAIL")]
        [TestCase(new[] {7, 11, 7}, "WIN")]
        [TestCase(new[] {6, -2, 0}, "WIN")]
        [TestCase(new[] {6, -2, 0}, "WIN")]
        [TestCase(new[] {-1, -3, -5}, "WIN")]
        public void Test1(int[] ints, string result)
        {
            var actual = B.GetResult(ints);
            Assert.AreEqual(result, actual);
        }
    }
}