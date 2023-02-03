using NUnit.Framework;

namespace A.Tests
{
    public class Tests
    {
        [TestCase(new[] {0, 1, 4, 9, 0}, new[] {0, 1, 2, 1, 0})]
        [TestCase(new[] {0, 7, 9, 4, 8, 20}, new[] {0, 1, 2, 3, 4, 5})]
        [TestCase(new[] {0}, new[] {0})]
        [TestCase(new[] {1, 0, 3}, new[] {1, 0, 1})]
        [TestCase(new[] {4, 1, 0, 3}, new[] {2, 1, 0, 1})]
        [TestCase(new int[] { }, new int[] { })]
        public void Test1(int[] input, int[] result)
        {
            var actual = A.GetDistances(input);
            CollectionAssert.AreEqual(result, actual);
        }
    }
}