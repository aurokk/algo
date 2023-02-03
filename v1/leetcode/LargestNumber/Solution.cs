namespace LargestNumber;

public class Solution
{
    private class Comparer : IComparer<string>
    {
        public int Compare(string? x, string? y)
            => string.Compare(y + x, x + y, StringComparison.Ordinal);
    }

    public string LargestNumber_000(int[] nums)
    {
        var ordered = nums
            .Select(x => x.ToString())
            .OrderBy(x => x, StringComparer);

        var result = string
            .Join(string.Empty, ordered)
            .TrimStart('0');

        return result.Length != 0
            ? result
            : "0";
    }

    private static readonly Random Random = new Random();
    private static readonly Comparer StringComparer = new Comparer();

    public static void QuickSort<T>(T[] input, int start, int end, IComparer<T> comparer)
    {
        if (end - start < 2)
        {
            return;
        }

        var pivotIndex = Random.Next(start, end);
        var pivot = input[pivotIndex];

        var leftIndex = start;
        var midIndex = start;
        var rightIndex = end - 1;

        while (midIndex <= rightIndex)
        {
            var mid = input[midIndex];
            if (comparer.Compare(mid, pivot) < 0)
            {
                (input[leftIndex], input[midIndex]) = (input[midIndex], input[leftIndex]);
                leftIndex++;
                midIndex++;
            }
            else if (comparer.Compare(pivot, mid) < 0)
            {
                (input[rightIndex], input[midIndex]) = (input[midIndex], input[rightIndex]);
                rightIndex--;
            }
            else
            {
                midIndex++;
            }
        }

        QuickSort(input, start, leftIndex, comparer);
        QuickSort(input, rightIndex, end, comparer);
    }

    public string LargestNumber_001(int[] nums)
    {
        var strings = nums
            .Select(x => x.ToString())
            .ToArray();

        QuickSort(strings, 0, strings.Length, StringComparer);

        var result = string
            .Join(string.Empty, strings)
            .TrimStart('0');

        return result.Length != 0
            ? result
            : "0";
    }
}