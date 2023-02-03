using NUnit.Framework;

namespace G.Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var node1 = new Node(5);
            var node2 = new Node(1);
            var node3 = new Node(-3)
            {
                Left = node2,
                Right = node1,
            };

            var node4 = new Node(2);
            var node5 = new Node(2)
            {
                Left = node4,
                Right = node3
            };

            Assert.AreEqual(6, Solution.Solve(node5));
        }

        [Test]
        public void Test2()
        {
            var node1 = new Node(5);
            Assert.AreEqual(5, Solution.Solve(node1));
        }

        [Test]
        public void Test3()
        {
            var node2 = new Node(4);
            var node1 = new Node(5)
            {
                Left = node2,
            };
            Assert.AreEqual(9, Solution.Solve(node1));
        }

        [Test]
        public void Test4()
        {
            var node3 = new Node(-4);
            var node2 = new Node(4);
            var node1 = new Node(5)
            {
                Left = node2,
                Right = node3,
            };
            Assert.AreEqual(9, Solution.Solve(node1));
        }

        [Test]
        public void Test5()
        {
            var node5 = new Node(5);
            var node4 = new Node(-1)
            {
                Left = node5,
            };
            var node3 = new Node(-4);
            var node2 = new Node(4)
            {
                Left = node4,
            };
            var node1 = new Node(5)
            {
                Left = node2,
                Right = node3,
            };
            Assert.AreEqual(13, Solution.Solve(node1));
        }

        [Test]
        public void Test6()
        {
            var node6 = new Node(-5);
            var node5 = new Node(5);
            var node4 = new Node(-1)
            {
                Left = node5,
                Right = node6,
            };
            var node3 = new Node(-4);
            var node2 = new Node(4)
            {
                Left = node4,
            };
            var node1 = new Node(5)
            {
                Left = node2,
                Right = node3,
            };
            Assert.AreEqual(13, Solution.Solve(node1));
        }

        [Test]
        public void Test7()
        {
            var node = new Node(-1);
            Assert.AreEqual(-1, Solution.Solve(node));
        }
    }
}