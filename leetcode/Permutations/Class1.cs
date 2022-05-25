namespace Permutations;

public class Solution
{
    public IList<IList<int>> Permute_000(int[] nums)
    {
        var result = new List<IList<int>>();

        var data = new Stack<(List<int>, List<int>)>();
        data.Push((nums.ToList(), new List<int>()));

        while (data.Any())
        {
            var (rem, path) = data.Pop();
            if (!rem.Any())
            {
                result.Add(path.ToList());
                continue;
            }

            for (var i = 0; i < rem.Count; i++)
            {
                var remCopy = new List<int>(rem);
                var num = remCopy[i];
                remCopy.RemoveAt(i);
                var pathCopy = new List<int>(path) { num };
                data.Push((remCopy, pathCopy));
            }
        }

        return result;
    }

    public IList<IList<int>> Permute_001(int[] nums)
    {
        var result = new List<IList<int>>();

        var queue = new Queue<(List<int>, List<int>)>();
        queue.Enqueue((nums.ToList(), new List<int>()));

        while (queue.Any())
        {
            var (rem, path) = queue.Dequeue();
            if (!rem.Any())
            {
                result.Add(path);
                continue;
            }

            for (var i = 0; i < rem.Count; i++)
            {
                var num = rem[i];
                var remCopy = new List<int>(rem);
                remCopy.RemoveAt(i);
                var pathCopy = new List<int>(path) { num };
                queue.Enqueue((remCopy, pathCopy));
            }
        }

        return result;
    }

    public IList<IList<int>> Permute_002(int[] nums)
    {
        var result = new List<IList<int>>();

        var queue = new Queue<(List<int>, List<int>)>();
        queue.Enqueue((nums.ToList(), new List<int>(nums.Length)));

        while (queue.Any())
        {
            var (rem, path) = queue.Dequeue();
            if (!rem.Any())
            {
                result.Add(path);
                continue;
            }

            for (var i = 0; i < rem.Count; i++)
            {
                var num = rem[i];

                List<int> remCopy;
                List<int> pathCopy;
                if (i == rem.Count - 1)
                {
                    remCopy = rem;
                    pathCopy = path;
                    path.Add(num);
                }
                else
                {
                    remCopy = new List<int>(rem);
                    pathCopy = new List<int>(nums.Length);
                    pathCopy.AddRange(path);
                    pathCopy.Add(num);
                }

                remCopy.RemoveAt(i);
                queue.Enqueue((remCopy, pathCopy));
            }
        }

        return result;
    }
}