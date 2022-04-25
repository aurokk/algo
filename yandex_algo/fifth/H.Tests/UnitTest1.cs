using NUnit.Framework;

namespace H.Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var node1 = new Node(2);
            var node2 = new Node(1);
            var node3 = new Node(3)
            {
                Left = node1,
                Right = node2
            };
            var node4 = new Node(2);
            var node5 = new Node(1)
            {
                Left = node4,
                Right = node3
            };
            Assert.AreEqual(275, Solution.Solve(node5));
        }
    }
}