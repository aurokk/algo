namespace FindClosestNodeToGivenTwoNodes;

public class Solution 
{
    public int ClosestMeetingNode(int[] edges, int node1, int node2) 
    {
        var dict = new Dictionary<int, int>();

        var node = node1;
        for (var dist = 0; dist < edges.Length; dist++) 
        {
            dict[node] = dist;
            node = edges[node];
            
            if (node == -1 || dict.ContainsKey(node))
            {
                break;
            }
        }

        var min = int.MaxValue;
        var minNode = -1;

        node = node2;
        for (var dist = 0; dist < edges.Length; dist++) 
        {
            if (dict.ContainsKey(node)) 
            {
                var newMin = dict[node] + dist;
                if (newMin < min) 
                {
                    min = newMin;
                    minNode = node;
                }
                else if (newMin == min)
                {
                    minNode = Math.Min(minNode, node);
                }
            }

            node = edges[node];
            if (node == -1)
            {
                break;
            }
        }

        return minNode;
    }
}

public class Tests
{
    [Test]
    public void Test_000()
    {
        var actual = new Solution().ClosestMeetingNode(new[] { 5, 3, 1, 0, 2, 4, 5 }, 3, 2);
        Assert.That(actual, Is.EqualTo(3));
    }

    [Test]
    public void Test_001()
    {
        var actual = new Solution().ClosestMeetingNode(new[] { 4, 4, 8, -1, 9, 8, 4, 4, 1, 1 }, 5, 6);
        Assert.That(actual, Is.EqualTo(1));
    }
}