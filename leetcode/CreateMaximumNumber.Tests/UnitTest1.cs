namespace CreateMaximumNumber.Tests;

public class Solution
{
    public int[] MaxNumber(int[] nums1, int[] nums2, int k)
    {
        var answer = new int[k];

        var n1 = nums1.Length;
        var n2 = nums2.Length;

        var kRemain = k;
        var pa = 0;
        var p1 = 0;
        var p2 = 0;

        while (pa < k)
        {
            var isn1 = true;
            var p = -1;
            var m = -1;

            var e = FindRange(n1, p2, n2, kRemain);
            for (var i = p1; i < e; i++)
            {
                if (nums1[i] > m)
                {
                    m = nums1[i];
                    p = i;
                }
            }

            e = FindRange(n2, p1, n1, kRemain);
            for (var i = p2; i < e; i++)
            {
                if (nums2[i] > m)
                {
                    m = nums2[i];
                    p = i;
                    isn1 = false;
                }
            }

            if (isn1)
            {
                answer[pa] = nums1[p];
                p1 = p + 1;
            }
            else
            {
                answer[pa] = nums2[p];
                p2 = p + 1;
            }

            pa++;
            kRemain--;
        }

        return answer;
    }

    private static int FindRange(int n1, int p2, int n2, int kRemain)
    {
        var remain2 = n2 - p2;
        var mustUseFrom1 = kRemain - remain2;
        if (mustUseFrom1 <= 0)
            return n1;
        return n1 - mustUseFrom1 + 1;
    }
}

public class Tests
{
    [Test]
    public void Test_000()
    {
        var actual = new Solution().MaxNumber(new[] { 3, 4, 6, 5 }, new[] { 9, 1, 2, 5, 8, 3 }, 5);
        CollectionAssert.AreEqual(new[] { 9, 8, 6, 5, 3 }, actual);
    }

    [Test]
    public void Test_001()
    {
        var actual = new Solution().MaxNumber(new[] { 6, 7 }, new[] { 6, 0, 4 }, 5);
        CollectionAssert.AreEqual(new[] { 6, 7, 6, 0, 4 }, actual);
    }
}