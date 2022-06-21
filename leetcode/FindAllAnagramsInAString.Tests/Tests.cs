using System.Collections.Generic;
using NUnit.Framework;

namespace FindAllAnagramsInAString.Tests;

public class Tests
{
    [TestCase("abab", "ab", new[] { 0, 1, 2 })]
    [TestCase("cbaebabacd", "abc", new[] { 0, 6 })]
    public void Test_000(string s, string p, IEnumerable<int> expected)
    {
        var actual = new Solution().FindAnagrams(s, p);
        CollectionAssert.AreEqual(expected, actual);
    }
}