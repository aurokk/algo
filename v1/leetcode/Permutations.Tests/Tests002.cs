using System;
using NUnit.Framework;

namespace Permutations.Tests;

public class Tests002
{
    [Test]
    public void Test_000()
    {
        var input = Array.Empty<int>();
        var expected = Array.Empty<int[]>();
        var actual = new Solution().Permute_002(input);
        Assert.Multiple(() =>
        {
            for (var i = 0; i < expected.Length; i++)
            for (var j = 0; j < expected[0].Length; j++)
            {
                Assert.AreEqual(expected[i][j], actual[i][j]);
            }
        });
    }

    [Test]
    public void Test_001()
    {
        var input = new[] { 1 };
        var expected = new[]
        {
            new[] { 1 },
        };
        var actual = new Solution().Permute_002(input);
        Assert.Multiple(() =>
        {
            for (var i = 0; i < expected.Length; i++)
            for (var j = 0; j < expected[0].Length; j++)
            {
                Assert.AreEqual(expected[i][j], actual[i][j]);
            }
        });
    }

    [Test]
    public void Test_002()
    {
        var input = new[] { 0, 1 };
        var expected = new[]
        {
            new[] { 0, 1 },
            new[] { 1, 0 },
        };
        var actual = new Solution().Permute_002(input);
        Assert.Multiple(() =>
        {
            for (var i = 0; i < expected.Length; i++)
            for (var j = 0; j < expected[0].Length; j++)
            {
                Assert.AreEqual(expected[i][j], actual[i][j]);
            }
        });
    }

    [Test]
    public void Test_003()
    {
        var input = new[] { 1, 2, 3 };
        var expected = new[]
        {
            new[] { 1, 2, 3 },
            new[] { 1, 3, 2 },
            new[] { 2, 1, 3 },
            new[] { 2, 3, 1 },
            new[] { 3, 1, 2 },
            new[] { 3, 2, 1 },
        };
        var actual = new Solution().Permute_002(input);
        Assert.Multiple(() =>
        {
            for (var i = 0; i < expected.Length; i++)
            for (var j = 0; j < expected[0].Length; j++)
            {
                Assert.AreEqual(expected[i][j], actual[i][j]);
            }
        });
    }
}