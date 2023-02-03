using System.Collections.Generic;

public class Solution
{
    public static int SiftUp(List<int> array, int idx)
    {
        if (idx <= 1)
        {
            return 1;
        }

        var parentIdx = idx / 2;
        if (array[parentIdx] < array[idx])
        {
            // ReSharper disable once SwapViaDeconstruction
            var tmp = array[parentIdx];
            array[parentIdx] = array[idx];
            array[idx] = tmp;
            return SiftUp(array, parentIdx);
        }

        return idx;
    }

    public static void Test()
    {
        var sample = new List<int> {-1, 12, 6, 8, 3, 15, 7};
        var result = SiftUp(sample, 5);
        System.Console.WriteLine(result == 1);
    }
}