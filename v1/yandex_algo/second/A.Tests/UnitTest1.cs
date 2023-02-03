using NUnit.Framework;

namespace A.Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var input = new[]
            {
                new[] {1, 2},
                new[] {3, 4},
                new[] {5, 6},
            };
            var n = 3;
            var m = 2;
            var expected = new[]
            {
                new[] {1, 3, 5},
                new[] {2, 4, 6},
            };
            var actual = A.Transpose(input, n, m);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            var input = new[]
            {
                new[] {1, 2, 3},
                new[] {0, 2, 6},
                new[] {7, 4, 1},
                new[] {2, 7, 0},
            };
            var n = 4;
            var m = 3;
            var expected = new[]
            {
                new[] {1, 0, 7, 2},
                new[] {2, 2, 4, 7},
                new[] {3, 6, 1, 0},
            };
            var actual = A.Transpose(input, n, m);
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}