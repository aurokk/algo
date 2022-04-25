using NUnit.Framework;

namespace B.Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var node1 = new Node(2);
            var node2 = new Node(3)
            {
                Left = node1
            };

            var node3 = new Node(1)
            {
                Right = node2
            };

            var node4 = new Node(6);
            var node5 = new Node(8)
            {
                Left = node4
            };

            var node6 = new Node(10)
            {
                Left = node5
            };

            var node7 = new Node(5)
            {
                Left = node3,
                Right = node6
            };

            var newHead = Solution.Remove(node7, 10);

            Assert.AreEqual(5, newHead.Value);
            Assert.AreEqual(node5, newHead.Right);
            Assert.AreEqual(8, newHead.Right.Value);
        }

        [Test]
        public void Test2()
        {
            var node1 = new Node(1);
            var newHead = Solution.Remove(node1, 10);
            Assert.AreEqual(node1, newHead);
        }

        [Test]
        public void Test3()
        {
            var node1 = new Node(1);
            var newHead = Solution.Remove(node1, 1);
            Assert.AreEqual(null, newHead);
        }

        [Test]
        public void Test4()
        {
            var node2 = new Node(2);
            var node1 = new Node(1)
            {
                Right = node2,
            };
            var newHead = Solution.Remove(node1, 1);
            Assert.AreEqual(node2, newHead);
            Assert.AreEqual(null, newHead.Left);
            Assert.AreEqual(null, newHead.Right);
        }

        [Test]
        public void Test5()
        {
            var node2 = new Node(2);
            var node1 = new Node(1)
            {
                Right = node2,
            };
            var newHead = Solution.Remove(node1, 2);
            Assert.AreEqual(node1, newHead);
            Assert.AreEqual(null, newHead.Left);
            Assert.AreEqual(null, newHead.Right);
        }

        [Test]
        public void Test6()
        {
            var node3 = new Node(3);
            var node2 = new Node(1);
            var node1 = new Node(2)
            {
                Left = node2,
                Right = node3,
            };
            var newHead = Solution.Remove(node1, 1);
            Assert.AreEqual(node1, newHead);
            Assert.AreEqual(null, newHead.Left);
            Assert.AreEqual(node3, newHead.Right);
        }

        [Test]
        public void Test7()
        {
            var node3 = new Node(3);
            var node2 = new Node(1);
            var node1 = new Node(2)
            {
                Left = node2,
                Right = node3,
            };
            var newHead = Solution.Remove(node1, 3);
            Assert.AreEqual(node1, newHead);
            Assert.AreEqual(node2, newHead.Left);
            Assert.AreEqual(null, newHead.Right);
        }

        [Test]
        public void Test8()
        {
            var node3 = new Node(3);
            var node2 = new Node(1);
            var node1 = new Node(2)
            {
                Left = node2,
                Right = node3,
            };
            var newHead = Solution.Remove(node1, 2);
            Assert.AreEqual(node2, newHead);
            Assert.AreEqual(null, newHead.Left);
            Assert.AreEqual(node3, newHead.Right);
        }

        [Test]
        public void Test9()
        {
            var node3 = new Node(3);
            var node2 = new Node(2)
            {
                Right = node3,
            };
            var node1 = new Node(1)
            {
                Right = node2,
            };
            var newHead = Solution.Remove(node1, 1);
            Assert.AreEqual(node2, newHead);
            Assert.AreEqual(null, newHead.Left);
            Assert.AreEqual(node3, newHead.Right);
        }

        [Test]
        public void Test10()
        {
            var node3 = new Node(3);
            var node2 = new Node(2)
            {
                Right = node3,
            };
            var node1 = new Node(1)
            {
                Right = node2,
            };
            var newHead = Solution.Remove(node1, 2);
            Assert.AreEqual(node1, newHead);
            Assert.AreEqual(null, newHead.Left);
            Assert.AreEqual(node3, newHead.Right);
        }

        [Test]
        public void Test11()
        {
            var node3 = new Node(3);
            var node2 = new Node(2)
            {
                Right = node3,
            };
            var node1 = new Node(1)
            {
                Right = node2,
            };
            var newHead = Solution.Remove(node1, 3);
            Assert.AreEqual(node1, newHead);
            Assert.AreEqual(null, newHead.Left);
            Assert.AreEqual(node2, newHead.Right);
        }

        [Test]
        public void Test12()
        {
            var node15 = new Node(15);
            var node14 = new Node(13);
            var node13 = new Node(14)
            {
                Left = node14,
                Right = node15,
            };
            var node12 = new Node(11);
            var node11 = new Node(9);
            var node10 = new Node(10)
            {
                Left = node11,
                Right = node12,
            };
            var node9 = new Node(12)
            {
                Left = node10,
                Right = node13,
            };
            var node8 = new Node(7);
            var node7 = new Node(5);
            var node6 = new Node(6)
            {
                Left = node7,
                Right = node8,
            };
            var node5 = new Node(3);
            var node4 = new Node(1);
            var node3 = new Node(2)
            {
                Left = node4,
                Right = node5,
            };
            var node2 = new Node(4)
            {
                Left = node3,
                Right = node6,
            };
            var node1 = new Node(8)
            {
                Left = node2,
                Right = node9,
            };
            var newHead = Solution.Remove(node1, 12);
            Assert.AreEqual(node1, newHead);
            Assert.AreEqual(node2, newHead.Left);
            Assert.AreEqual(node12, newHead.Right);
            Assert.AreEqual(node9.Left, node12.Left);
            Assert.AreEqual(node9.Right, node12.Right);
            Assert.AreEqual(null, node10.Right);
        }

        [Test]
        public void Test13()
        {
            var node1 = (Node) null;
            var newHead = Solution.Remove(node1, 4);
            Assert.AreEqual(null, newHead);
        }

        [Test]
        public void Test14()
        {
            var node4 = new Node(2);
            var node3 = new Node(3)
            {
                Left = node4,
            };
            var node2 = new Node(1)
            {
                Right = node3,
            };
            var node7 = new Node(6);
            var node6 = new Node(8)
            {
                Left = node7,
            };
            var node5 = new Node(10)
            {
                Left = node6,
            };
            var node1 = new Node(5)
            {
                Left = node2,
                Right = node5,
            };
            var newHead = Solution.Remove(node1, 10);
            Assert.AreEqual(node1, newHead);
            Assert.AreEqual(node2, newHead.Left);
            Assert.AreEqual(node6, newHead.Right);
            Assert.AreEqual(node7, node6.Left);
        }
    }
}