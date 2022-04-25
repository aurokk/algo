using NUnit.Framework;

namespace C.Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var node1 = new Node(3);
            var node2 = new Node(4);
            var node3 = new Node(4);
            var node4 = new Node(3);
            var node5 = new Node(2)
            {
                Left = node1,
                Right = node2,
            };

            var node6 = new Node(2)
            {
                Left = node3,
                Right = node4
            };

            var node7 = new Node(1)
            {
                Left = node5,
                Right = node6
            };

            Assert.True(Solution.Solve(node7));
        }

        [Test]
        public void Test2()
        {
            var node1 = new Node(3);
            var node3 = new Node(4);
            var node4 = new Node(3);
            var node5 = new Node(2)
            {
                Left = node1,
            };

            var node6 = new Node(2)
            {
                Left = node3,
                Right = node4
            };

            var node7 = new Node(1)
            {
                Left = node5,
                Right = node6
            };

            Assert.False(Solution.Solve(node7));
        }

        // 4
        // 0 1 1 2
        // 1 1 3 None
        // 2 1 None None
        // 3 1 None None
        [Test]
        public void Test3()
        {
            var node3 = new Node(1);
            var node1 = new Node(1)
            {
                Left = node3,
            };
            var node2 = new Node(1);
            var node0 = new Node(1)
            {
                Left = node1,
                Right = node2,
            };

            Assert.False(Solution.Solve(node0));
        }
    }
}