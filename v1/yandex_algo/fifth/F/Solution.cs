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

public class Solution
{
    public static int Solve(Node root, int depth = 0)
    {
        var left = 0;
        if (root.Left != null)
        {
            left = Solve(root.Left);
        }

        var right = 0;
        if (root.Right != null)
        {
            right = Solve(root.Right);
        }

        return Math.Max(left, right) + 1;
    }
}