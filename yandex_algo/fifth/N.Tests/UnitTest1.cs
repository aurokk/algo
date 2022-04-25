using NUnit.Framework;

namespace N.Tests
{
    public class Tests
    {
        [Test]
        public static void Test()
        {
            var node1 = new Node(3, 1);
            var node2 = new Node(2, 2)
            {
                Right = node1
            };

            var node3 = new Node(8, 1);
            var node4 = new Node(11, 1);
            var node5 = new Node(10, 3)
            {
                Left = node3,
                Right = node4
            };

            var node6 = new Node(5, 6)
            {
                Left = node2,
                Right = node5
            };

            var result = Solution.Split(node6, 4);

            Assert.AreEqual(4, result[0].Size);
            Assert.AreEqual(2, result[1].Size);
        }

        [Test]
        public static void Test1()
        {
            var node1 = (Node) null;

            var result = Solution.Split(node1, 4);

            Assert.AreEqual(null, result[0]);
            Assert.AreEqual(null, result[1]);
        }

        [Test]
        public static void Test3()
        {
            var node1 = new Node(1, 1);

            var result = Solution.Split(node1, 1);

            Assert.AreEqual(node1.Value, result[0].Value);
            Assert.AreEqual(node1.Size, result[0].Size);
            Assert.AreEqual(null, result[1]);
        }

    [Test]
    public static void Test4()
    {
        var node1 = new Node(2, 1);
        var node2 = new Node(1, 2)
        {
            Right = node1,
        };
    
        var result = Solution.Split(node2, 1);
    
        Assert.AreEqual(node2.Value, result[0].Value);
        Assert.AreEqual(1, result[0].Size);
        Assert.AreEqual(node1.Value, result[1].Value);
        Assert.AreEqual(1, result[1].Size);
    }
    
    [Test]
    public static void Test5()
    {
        var node1 = new Node(1, 1);
        var node2 = new Node(3, 1);
        var node3 = new Node(2, 3)
        {
            Left = node1,
            Right = node2,
        };
    
        var result = Solution.Split(node3, 1);
    
        Assert.AreEqual(node1.Value, result[0].Value);
        Assert.AreEqual(1, result[0].Size);
        Assert.AreEqual(node3.Value, result[1].Value);
        Assert.AreEqual(2, result[1].Size);
    }
    
    //     [Test]
    //     public static void Test6()
    //     {
    //         var node1 = new Node(1, 1);
    //         var node2 = new Node(3, 1);
    //         var node3 = new Node(2, 3)
    //         {
    //             Left = node1,
    //             Right = node2,
    //         };
    //
    //         var result = Solution.Split(node3, 2);
    //
    //         Assert.AreEqual(node3.Value, result[0].Value);
    //         Assert.AreEqual(2, result[0].Size);
    //         Assert.AreEqual(node2.Value, result[1].Value);
    //         Assert.AreEqual(1, result[1].Size);
    //     }
    //
    //     [Test]
    //     public static void Test7()
    //     {
    //         var node1 = new Node(1, 1);
    //         var node2 = new Node(3, 1);
    //         var node3 = new Node(2, 3)
    //         {
    //             Left = node1,
    //             Right = node2,
    //         };
    //
    //         var result = Solution.Split(node3, 3);
    //
    //         Assert.AreEqual(node3.Value, result[0].Value);
    //         Assert.AreEqual(3, result[0].Size);
    //         Assert.AreEqual(null, result[1]);
    //     }
    //
    //     [Test]
    //     public static void Test8()
    //     {
    //         var node1 = new Node(1, 1);
    //         var node2 = new Node(4, 1);
    //         var node3 = new Node(3, 2)
    //         {
    //             Right = node2,
    //         };
    //         var node4 = new Node(2, 4)
    //         {
    //             Left = node1,
    //             Right = node3,
    //         };
    //
    //         var result = Solution.Split(node4, 1);
    //
    //         Assert.AreEqual(node1.Value, result[0].Value);
    //         Assert.AreEqual(1, result[0].Size);
    //         Assert.AreEqual(node4.Value, result[1].Value);
    //         Assert.AreEqual(3, result[1].Size);
    //     }
    //
    //     [Test]
    //     public static void Test9()
    //     {
    //         var node1 = new Node(1, 1);
    //         var node2 = new Node(4, 1);
    //         var node3 = new Node(3, 2)
    //         {
    //             Right = node2,
    //         };
    //         var node4 = new Node(2, 4)
    //         {
    //             Left = node1,
    //             Right = node3,
    //         };
    //
    //         var result = Solution.Split(node4, 2);
    //
    //         Assert.AreEqual(node4.Value, result[0].Value);
    //         Assert.AreEqual(2, result[0].Size);
    //         Assert.AreEqual(node3.Value, result[1].Value);
    //         Assert.AreEqual(2, result[1].Size);
    //     }
    //
    //     [Test]
    //     public static void Test10()
    //     {
    //         var node1 = new Node(1, 1);
    //         var node2 = new Node(4, 1);
    //         var node3 = new Node(3, 2)
    //         {
    //             Right = node2,
    //         };
    //         var node4 = new Node(2, 4)
    //         {
    //             Left = node1,
    //             Right = node3,
    //         };
    //
    //         var result = Solution.Split(node4, 3);
    //
    //         Assert.AreEqual(node4.Value, result[0].Value);
    //         Assert.AreEqual(3, result[0].Size);
    //         Assert.AreEqual(node2.Value, result[1].Value);
    //         Assert.AreEqual(1, result[1].Size);
    //     }
    //
    //     [Test]
    //     public static void Test11()
    //     {
    //         var node4 = new Node(266, 1);
    //         var node3 = new Node(191, 2)
    //         {
    //             Right = node4,
    //         };
    //         var node2 = new Node(298, 3)
    //         {
    //             Left = node3,
    //         };
    //         var node6 = new Node(701, 1);
    //         var node8 = new Node(822, 1);
    //         var node10 = new Node(932, 1);
    //         var node9 = new Node(912, 2)
    //         {
    //             Right = node10,
    //         };
    //         var node7 = new Node(870, 4)
    //         {
    //             Left = node8,
    //             Right = node9,
    //         };
    //         var node5 = new Node(702, 6)
    //         {
    //             Left = node6,
    //             Right = node7,
    //         };
    //         var node1 = new Node(668, 10)
    //         {
    //             Left = node2,
    //             Right = node5,
    //         };
    //
    //         var result = Solution.Split(node1, 1);
    //
    //         Assert.AreEqual(node3.Value, result[0].Value);
    //         Assert.AreEqual(1, result[0].Size);
    //         Assert.AreEqual(node1.Value, result[1].Value);
    //         Assert.AreEqual(9, result[1].Size);
    //     }
    }
}