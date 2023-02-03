using System.Collections.Generic;

// закомментируйте перед отправкой
public class Node
{
    public int Value { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }
    public int Size { get; set; }

    public Node(int value, int size)
    {
        Value = value;
        Size = size;
        Left = null;
        Right = null;
    }
}

public class Solution
{
    public static List<Node> Split(Node root, int k)
    {
        if (root == null)
        {
            return new List<Node> {null, null};
        }

        var leftSize = root.Left != null ? root.Left.Size : 0;
        if (leftSize + 1 <= k)
        {
            // right
            var kFixed = k - (leftSize + 1);
            var result = Split(root.Right, kFixed);
            root.Size = k;
            root.Right = result[0];
            var rightRoot = result[1];
            return new List<Node> {root, rightRoot};
        }
        else
        {
            // left and root
            var result = Split(root.Left, k);
            var leftRoot = result[0];
            root.Size -= k;
            root.Left = result[1];
            return new List<Node> {leftRoot, root};
        }
    }
}