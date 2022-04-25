using System.Collections.Generic;
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
    public static bool Solve(Node root)
    {
        var lm = new List<int?>();
        Lm(root, lm);

        var rm = new List<int?>();
        Rm(root, rm);

        return lm.SequenceEqual(rm);
    }

    private static void Lm(Node root, ICollection<int?> acc)
    {
        if (root == null)
        {
            acc.Add(null);
            return;
        }

        acc.Add(root.Value);
        Lm(root.Left, acc);
        Lm(root.Right, acc);
    }

    private static void Rm(Node root, ICollection<int?> acc)
    {
        if (root == null)
        {
            acc.Add(null);
            return;
        }

        acc.Add(root.Value);
        Rm(root.Right, acc);
        Rm(root.Left, acc);
    }
}