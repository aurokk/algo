using System;

// закомментируйте перед отправкой

public class Node
{
    public int Value;
    public Node Left;
    public Node Right;

    public Node(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

public class Solution
{
    public static bool Solve(Node root)
    {
        return InternalSolve(root, null, null);
    }

    public static bool InternalSolve(Node node, int? minCap, int? maxCap)
    {
        var currValue = node.Value;

        if (node.Left != null)
        {
            if (!InternalSolve(node.Left, minCap, currValue))
            {
                return false;
            }

            var leftValue = node.Left.Value;
            if (currValue <= leftValue)
            {
                return false;
            }
        }

        if (node.Right != null)
        {
            if (!InternalSolve(node.Right, currValue, maxCap))
            {
                return false;
            }

            var rightValue = node.Right.Value;
            if (currValue >= rightValue)
            {
                return false;
            }
        }

        if (currValue <= minCap)
        {
            return false;
        }

        if (currValue >= maxCap)
        {
            return false;
        }

        return true;
    }

    public static void Test()
    {
        var node1 = new Node(1);
        var node2 = new Node(4);
        var node3 = new Node(3)
        {
            Left = node1,
            Right = node2
        };
        var node4 = new Node(8);
        var node5 = new Node(5)
        {
            Left = node3,
            Right = node4
        };
        Console.WriteLine(Solve(node5));
        node2.Value = 5;
        Console.WriteLine(Solve(node5));
    }
}