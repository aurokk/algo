namespace OddEvenJump.Tests;

public class Solution
{
    public int OddEvenJumps(int[] a)
    {
        var n = a.Length;

        var nextHigher = new int[n];
        var nextLower = new int[n];

        Array.Fill(nextHigher, -1);
        Array.Fill(nextLower, -1);

        var stack = new Stack<int>();

        var sortedIndex = a
            .Select((x, i) => new KeyValuePair<int, int>(x, i))
            .OrderBy(x => x.Key)
            .ThenBy(x => x.Value)
            .Select(x => x.Value)
            .ToList();
        
        //  0,  1,  2,  3,  4
        // 10, 13, 12, 14, 15
        // ->
        // 10, 12, 13, 14, 15
        //  0,  2,  1,  3,  4
        // ->
        // N[-1,-1,-1,-1,-1], S[0]
        // N[ 2,-1,-1,-1,-1], S[2]
        // N[ 2,-1,-1,-1,-1], S[2,1]
        // N[ 2, 3,-1,-1,-1], S[2]
        // N[ 2, 3, 3,-1,-1], S[3]
        // ...

        foreach (var i in sortedIndex)
        {
            while (stack.Count > 0 && i > stack.Peek())
            {
                nextHigher[stack.Pop()] = i;
            }

            stack.Push(i);
        }

        stack.Clear();

        sortedIndex = a
            .Select((x, i) => new KeyValuePair<int, int>(x, i))
            .OrderByDescending(x => x.Key)
            .ThenBy(x => x.Value)
            .Select(x => x.Value)
            .ToList();
        
        //  0,  1,  2,  3,  4
        // 10, 13, 12, 14, 15
        // ->
        // 15, 14, 13, 12, 10
        //  4,  3,  1,  2,  0
        // ->
        // N[-1,-1,-1,-1,-1], S[4]
        // N[-1,-1,-1,-1,-1], S[4,3]
        // N[-1,-1,-1,-1,-1], S[4,3,1]
        // N[-1, 2,-1,-1,-1], S[4,3,2]
        // N[-1, 2,-1,-1,-1], S[4,3,2,0]
        // ...

        foreach (var i in sortedIndex)
        {
            while (stack.Count > 0 && i > stack.Peek())
            {
                nextLower[stack.Pop()] = i;
            }

            stack.Push(i);
        }

        var higher = new bool[n];
        var lower = new bool[n];
        higher[n - 1] = lower[n - 1] = true;

        var sum = 1;
        for (var i = n - 2; i >= 0; i--)
        {
            higher[i] = nextHigher[i] != -1 && lower[nextHigher[i]];
            lower[i] = nextLower[i] != -1 && higher[nextLower[i]];

            if (higher[i])
            {
                sum++;
            }
        }

        return sum;
    }
}

public class Tests
{
    [TestCase(new[] { 10, 13, 12, 14, 15, }, 2)]
    [TestCase(new[] { 81, 54, 96, 60, 58, }, 2)]
    public void Test1(int[] data, int expected)
    {
        var actual = new Solution().OddEvenJumps(data);
        Assert.That(actual, Is.EqualTo(expected));
    }
}