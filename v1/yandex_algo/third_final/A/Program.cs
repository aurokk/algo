using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using System.Collections.Generic;

public class Solution1
{
    private static int BinarySearch(List<int> array, int start, int end, int el)
    {
        var mid = (start + end) / 2;
        if (array[mid] == el)
        {
            return mid;
        }
        else if (end - start == 1)
        {
            return -1;
        }

        if (array[start] == el)
        {
            return start;
        }
        else if (array[start] < array[mid] && array[start] < el && el < array[mid])
        {
            // Если первая половина отсортирована
            // Элемент находится в [array[0]; array[mid])
            // Ищем в начале
            return BinarySearch(array, 0, mid, el);
        }
        else if (array[start] > array[mid] && (array[start] < el || el < array[mid]))
        {
            // Если первая половина не отсортирована
            // Значит максимальный и минимальный элементы будут тут
            // Элемент находится больше чем первого, либо меньше среднего
            // Ищем в начале
            return BinarySearch(array, 0, mid, el);
        }
        else
        {
            // В остальных случаях ищем в конце
            return BinarySearch(array, mid, end, el);
        }
    }

    public static int BrokenSearch(List<int> array, int el)
    {
        return BinarySearch(array, 0, array.Count, el);
    }

    private static void Main()
    {
        // 11
        // 1
        // 1 2 3 4 5 6 7 8 9 10 0
        var arr = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 0};
        Console.WriteLine(BrokenSearch(arr, 1) == 0);
    }
}