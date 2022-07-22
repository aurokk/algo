namespace OpenTheLock;

public class Solution
{
    public int OpenLock(string[] deadends, string target)
    {
        var visited = new HashSet<string>(deadends);

        var queue = new Queue<string>();
        queue.Enqueue("0000");

        var depth = -1;

        while (queue.Any())
        {
            depth++;
            var size = queue.Count;
            for (var j = 0; j < size; j++)
            {
                var code = queue.Dequeue();
                if (visited.Contains(code))
                {
                    continue;
                }

                if (code == target)
                {
                    return depth;
                }

                for (var i = 0; i < target.Length; i++)
                {
                    var upCode = code.Substring(0, i) + (char)(code[i] + 1 > '9' ? '0' : code[i] + 1) +
                                 code.Substring(i + 1);
                    var downCode = code.Substring(0, i) + (char)(code[i] - 1 < '0' ? '9' : code[i] - 1) +
                                   code.Substring(i + 1);
                    queue.Enqueue(upCode);
                    queue.Enqueue(downCode);
                }

                visited.Add(code);
            }
        }

        return -1;
    }
}