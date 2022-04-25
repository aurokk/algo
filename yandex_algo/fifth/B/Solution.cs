using System;

// закомментируйте перед отправкой
public class Node
{
    public int Value { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public Node(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

public struct Result
{
    public int Level;
    public bool Balanced;
}

public class Solution
{
    public static bool Solve(Node root)
    {
        var result = InternalSolve(root);
        return result.Balanced;
    }

    private static Result InternalSolve(Node root)
    {
        var left = 0;
        var leftBalanced = true;
        if (root.Left != null)
        {
            var result = InternalSolve(root.Left);
            left = result.Level;
            leftBalanced = result.Balanced;
        }

        var right = 0;
        var rightBalanced = true;
        if (root.Right != null)
        {
            var result = InternalSolve(root.Right);
            right = result.Level;
            rightBalanced = result.Balanced;
        }

        var diff = Math.Abs(left - right);
        var max = Math.Max(left, right);
        var newMax = max + 1;
        if (!leftBalanced || !rightBalanced || diff > 1)
        {
            return new Result
            {
                Level = newMax,
                Balanced = false,
            };
        }

        return new Result
        {
            Level = newMax,
            Balanced = true,
        };
    }

    public static void Test()
    {
        var node1 = new Node(1);
        var node2 = new Node(-5);
        var node3 = new Node(3)
        {
            Left = node1,
            Right = node2
        };
        var node4 = new Node(10);
        var node5 = new Node(2)
        {
            Left = node3,
            Right = node4
        };
        Console.WriteLine(Solve(node5));
    }
}