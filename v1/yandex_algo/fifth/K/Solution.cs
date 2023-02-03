using System.IO;

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
    public static void PrintRange(Node root, int left, int right, StreamWriter writer)
    {
        if (root.Left != null)
        {
            PrintRange(root.Left, left, right, writer);
        }

        if (left <= root.Value && root.Value <= right)
        {
            writer.WriteLine(root.Value);
        }

        if (root.Right != null)
        {
            PrintRange(root.Right, left, right, writer);
        }
    }
}