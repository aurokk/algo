using NUnit.Framework;

namespace C.Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var table = new[]
            {
                new[] {1, 2, 3},
                new[] {0, 2, 6},
                new[] {7, 4, 1},
                new[] {2, 7, 0},
            };
            var actual = C.GetResult(table, 3, 0);
            Assert.AreEqual("7 7", actual);
        }

        [Test]
        public void Test2()
        {
            var table = new[]
            {
                new[] {1, 2, 3},
                new[] {0, 2, 6},
                new[] {7, 4, 1},
                new[] {2, 7, 0},
            };
            var actual = C.GetResult(table, 0, 0);
            Assert.AreEqual("0 2", actual);
        }

        [Test]
        public void Test3()
        {
            var table = new[]
            {
                new[] {1, 2, 3},
                new[] {0, 2, 6},
                new[] {7, 4, 1},
                new[] {2, 7, 0},
            };
            var actual = C.GetResult(table, 1, 1);
            Assert.AreEqual("0 2 4 6", actual);
        }

        [Test]
        public void Test4()
        {
            var table = new[]
            {
                new[] {1, 2, 3},
                new[] {0, 2, 6},
                new[] {7, 4, 1},
                new[] {2, 7, 0},
            };
            var actual = C.GetResult(table, 1, 2);
            Assert.AreEqual("1 2 3", actual);
        }
    }
}