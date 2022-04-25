using System.Linq;

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
        return InternalSolve(root);
    }

    private static int InternalSolve(Node root)
    {
        var curr = root.Value;

        var left = root.Value;
        if (root.Left != null)
        {
            left = InternalSolve(root.Left);
        }

        var right = root.Value;
        if (root.Right != null)
        {
            right = InternalSolve(root.Right);
        }

        return new[] {curr, left, right}
            .Max();
    }
}