using NUnit.Framework;

namespace A.Tests
{
    public class Tests
    {
        [TestCase(-8, -5, -2, 7, -183)]
        [TestCase(8, 2, 9, -10, 40)]
        [TestCase(0, 0, 0, 0, 0)]
        public void Test1(int a, int x, int b, int c, int y)
        {
            var actual = A.GetY(a, b, c, x);
            Assert.AreEqual(y, actual);
        }
    }
}