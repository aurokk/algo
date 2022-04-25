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
    public static bool Solve(Node left, Node right)
    {
        var lAcc = new List<int?>();
        Lmr(left, lAcc);

        var rAcc = new List<int?>();
        Lmr(right, rAcc);

        return lAcc.SequenceEqual(rAcc);
    }

    private static void Lmr(Node root, ICollection<int?> acc)
    {
        if (root == null)
        {
            acc.Add(null);
            return;
        }

        acc.Add(root.Value);
        Lmr(root.Left, acc);
        Lmr(root.Right, acc);
    }
}