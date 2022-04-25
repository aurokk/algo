using NUnit.Framework;

namespace D.Tests
{
    public class Tests
    {
        [TestCase(new[] {-1, -10, -8, 0, 2, 0, 5}, 3)]
        [TestCase(new[] {1, 2, 5, 4, 8}, 2)]
        public void Test1(int[] temps, int result)
        {
            var actual = D.GetResult(temps);
            Assert.AreEqual(result, actual);
        }
    }
}