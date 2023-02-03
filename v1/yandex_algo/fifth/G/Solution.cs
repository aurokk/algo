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

public class Result
{
    public int Final;
    public int Partial;
}

public class Solution
{
    public static int Solve(Node root)
    {
        var result = InternalSolve(root);
        return result.Final;
    }

    private static Result InternalSolve(Node root)
    {
        Result left = null;
        if (root.Left != null)
        {
            left = InternalSolve(root.Left);
        }

        Result right = null;
        if (root.Right != null)
        {
            right = InternalSolve(root.Right);
        }

        var current = root.Value;
        var partial = new List<int> {current,};
        var final = new List<int> {current,};

        if (left != null)
        {
            partial.Add(left.Partial + current);
            final.Add(left.Final);
            final.Add(left.Partial + current);
        }

        if (right != null)
        {
            partial.Add(right.Partial + current);
            final.Add(right.Final);
            final.Add(right.Partial + current);
        }

        if (left != null && right != null)
        {
            final.Add(left.Partial + current + right.Partial);
        }

        return new Result
        {
            Partial = partial.Max(),
            Final = final.Max(),
        };
    }
}