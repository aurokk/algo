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
    public static int Solve(Node root)
    {
        var acc = 0;
        InternalSolve(root, "", ref acc);
        return acc;
    }

    private static void InternalSolve(Node root, string prefix, ref int acc)
    {
        if (root.Left == null && root.Right == null)
        {
            var valueString = prefix + root.Value;
            var value = int.Parse(valueString);
            acc += value;
            return;
        }

        if (root.Left != null)
        {
            InternalSolve(root.Left, prefix + root.Value, ref acc);
        }

        if (root.Right != null)
        {
            InternalSolve(root.Right, prefix + root.Value, ref acc);
        }
    }
}