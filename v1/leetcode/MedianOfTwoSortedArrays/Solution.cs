// ReSharper disable VariableHidesOuterVariable
// ReSharper disable CompareOfFloatsByEqualityOperator

namespace MedianOfTwoSortedArrays;

public class Solution
{
    // time O(N+M)
    // memory O(N+M)
    public double FindMedianSortedArrays_000(int[] nums1, int[] nums2)
    {
        var nums12 = nums1
            .Concat(nums2)
            .OrderBy(x => x)
            .ToArray();

        return nums12.Length % 2 == 0
            ? (nums12[nums12.Length / 2 - 1] + nums12[nums12.Length / 2]) / 2d
            : nums12[nums12.Length / 2];
    }

    // time O(log(min(N,M)))
    // memory O(N+M)
    public double FindMedianSortedArrays_001(int[] nums1, int[] nums2)
    {
        return nums1.Length <= nums2.Length
            ? FindMedianSortedArrays_001_Internal(nums1, nums1.Length, nums2, nums2.Length)
            : FindMedianSortedArrays_001_Internal(nums2, nums2.Length, nums1, nums1.Length);
    }

    // a less than b
    private double FindMedianSortedArrays_001_Internal(int[] a, int n, int[] b, int m)
    {
        if (n == 0)
        {
            return GetMedianOfOneArray(b);
        }

        if (n == 1)
        {
            if (m == 1)
            {
                return GetMedianOfTwo(
                    a[0],
                    b[0]);
            }
            else if (m % 2 == 1)
            {
                return GetMedianOfTwo(
                    b[m / 2],
                    GetMedianOfThree(
                        a[0],
                        b[m / 2 + 1],
                        b[m / 2 - 1]));
            }
            else
            {
                return GetMedianOfThree(
                    a[0],
                    b[m / 2],
                    b[m / 2 - 1]);
            }
        }

        if (n == 2)
        {
            if (m == 2)
            {
                return GetMedianOfFour(
                    a[0],
                    a[1],
                    b[0],
                    b[1]);
            }
            else if (m % 2 == 1)
            {
                return GetMedianOfThree(
                    b[m / 2],
                    Math.Max(b[m / 2 - 1], a[0]),
                    Math.Min(b[m / 2 + 1], a[1]));
            }
            else
            {
                return GetMedianOfFour(
                    b[m / 2],
                    b[m / 2 - 1],
                    Math.Max(b[m / 2 - 2], a[0]),
                    Math.Min(b[m / 2 + 1], a[1]));
            }
        }

        var idxA = (n - 1) / 2;
        var idxB = (m - 1) / 2;

        if (a[idxA] <= b[idxB])
        {
            return FindMedianSortedArrays_001_Internal(
                // Copy(a, idxA, Math.Min(a.Length, idxA + n / 2 + 1)),
                // Copy(a, idxA, a.Length),
                Copy(a, idxA, a.Length),
                n / 2 + 1,
                // n - idxA,
                // a.Length - idxA,
                b,
                m - idxA);
        }
        else
        {
            return FindMedianSortedArrays_001_Internal(
                a,
                n / 2 + 1,
                // n - idxA,
                // a.Length - idxA,
                // Copy(b, idxA, Math.Min(b.Length, idxA + n / 2 + 1)),
                // Copy(b, idxA, b.Length),
                Copy(b, idxA, b.Length),
                m - idxA);
        }

        int[] Copy(int[] a, int s, int e)
        {
            var l = e - s;
            var b = new int[l];
            Array.Copy(a, s, b, 0, l);
            return b;
        }

        double GetMedianOfTwo(int a, int b)
            => (a + b) / 2.0;

        int GetMedianOfThree(int a, int b, int c)
        {
            var arr = new[] { a, b, c };
            Array.Sort(arr);
            return arr[1];
        }

        double GetMedianOfFour(int a, int b, int c, int d)
        {
            var arr = new[] { a, b, c, d };
            Array.Sort(arr);
            return GetMedianOfTwo(arr[01], arr[2]);
        }

        double GetMedianOfOneArray(int[] a)
            => a.Length switch
            {
                0 => 0,
                1 => a[0],
                _ => a.Length % 2 == 0
                    ? (a[a.Length / 2] + a[a.Length / 2 - 1]) / 2.0
                    : a[a.Length / 2],
            };
    }

    // time O(log(min(N,M)))
    // memory O(N+M)
    public double FindMedianSortedArrays_002(int[] nums1, int[] nums2)
    {
        return nums1.Length <= nums2.Length
            ? FindMedianSortedArrays_002_Internal(nums1, nums1.Length, nums2, nums2.Length)
            : FindMedianSortedArrays_002_Internal(nums2, nums2.Length, nums1, nums1.Length);
    }

    private double FindMedianSortedArrays_002_Internal(int[] a, int n, int[] b, int m)
    {
        // 1 2 3 4 5
        // 5 6 7 8 9
        //
        // i  0 2 4
        // j  0 3 1
        // mi 0 3 x
        // ma 5 5 x
        // -> 5.0

        var median = 0;
        var i = 0;
        var j = 0;
        var minIndex = 0;
        var maxIndex = n;
        while (minIndex <= maxIndex)
        {
            i = (minIndex + maxIndex) / 2;
            j = (n + m + 1) / 2 - i;

            if (i < n && j > 0 && b[j - 1] > a[i])
            {
                minIndex = i + 1;
            }
            else if (i > 0 && j < m && b[j] < a[i - 1])
            {
                maxIndex = i - 1;
            }
            else
            {
                if (i == 0)
                {
                    median = b[j - 1];
                }
                else if (j == 0)
                {
                    median = a[i - 1];
                }
                else
                {
                    median = Math.Max(a[i - 1], b[j - 1]);
                }

                break;
            }
        }

        if ((n + m) % 2 == 1)
            return median;

        if (i == n)
            return (median + b[j]) / 2.0;

        if (j == m)
            return (median + a[i]) / 2.0;

        return (median + Math.Min(a[i], b[j])) / 2.0;
    }
}