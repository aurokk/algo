using System.Collections.Generic;
using NUnit.Framework;

namespace B.Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var node3 = new Node<string>("node3", null);
            var node2 = new Node<string>("node2", node3);
            var node1 = new Node<string>("node1", node2);
            var node0 = new Node<string>("node0", node1);
            Solution<string>.Solve(node0);
        }
    }
}