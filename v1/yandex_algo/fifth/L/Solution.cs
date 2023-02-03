using System.Collections.Generic;

public class Solution
{
    public static int SiftDown(List<int> array, int idx)
    {
        var lcIdx = idx * 2;
        var rcIdx = idx * 2 + 1;
        if (lcIdx >= array.Count)
        {
            return idx;
        }

        if (rcIdx >= array.Count)
        {
            // Only left child
            var curr = array[idx];
            var leftChild = array[lcIdx];
            if (curr < leftChild)
            {
                // ReSharper disable once SwapViaDeconstruction
                var tmp = array[lcIdx];
                array[lcIdx] = array[idx];
                array[idx] = tmp;
                return SiftDown(array, lcIdx);
            }
        }
        else
        {
            // Right and left children
            var curr = array[idx];
            var leftChild = array[lcIdx];
            var rightChild = array[rcIdx];
            if (curr < leftChild || curr < rightChild)
            {
                if (leftChild > rightChild)
                {
                    // ReSharper disable once SwapViaDeconstruction
                    var tmp = array[lcIdx];
                    array[lcIdx] = array[idx];
                    array[idx] = tmp;
                    return SiftDown(array, lcIdx);
                }
                else
                {
                    // ReSharper disable once SwapViaDeconstruction
                    var tmp = array[rcIdx];
                    array[rcIdx] = array[idx];
                    array[idx] = tmp;
                    return SiftDown(array, rcIdx);
                }
            }
        }


        return idx;
    }

    public static void Test()
    {
        var sample = new List<int> {-1, 12, 1, 8, 3, 4, 7};
        System.Console.WriteLine(SiftDown(sample, 2) == 5);
    }
}