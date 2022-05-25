using System;
using NUnit.Framework;

namespace P_01_08.Tests;

public class Tests
{
    [Test]
    public void Test_000()
    {
        var input = Array.Empty<int[]>();
        var expected = Array.Empty<int[]>();
        var actual = new Class1().NullifyRowsAndColumns(input);

        Assert.Multiple(() =>
        {
            for (var i = 0; i < input.Length; i++)
            for (var j = 0; j < input[i].Length; j++)
            {
                Assert.AreEqual(expected[i][j], actual[i][j]);
            }
        });
    }

    [Test]
    public void Test_001()
    {
        var input = new[]
        {
            new[] { 1 }
        };
        var expected = new[]
        {
            new[] { 1 }
        };
        var actual = new Class1().NullifyRowsAndColumns(input);

        Assert.Multiple(() =>
        {
            for (var i = 0; i < input.Length; i++)
            for (var j = 0; j < input[i].Length; j++)
            {
                Assert.AreEqual(expected[i][j], actual[i][j]);
            }
        });
    }

    [Test]
    public void Test_002()
    {
        var input = new[]
        {
            new[] { 0 }
        };
        var expected = new[]
        {
            new[] { 0 }
        };
        var actual = new Class1().NullifyRowsAndColumns(input);

        Assert.Multiple(() =>
        {
            for (var i = 0; i < input.Length; i++)
            for (var j = 0; j < input[i].Length; j++)
            {
                Assert.AreEqual(expected[i][j], actual[i][j]);
            }
        });
    }

    [Test]
    public void Test_003()
    {
        var input = new[]
        {
            new[] { 0, 1, },
        };
        var expected = new[]
        {
            new[] { 0, 0, },
        };
        var actual = new Class1().NullifyRowsAndColumns(input);

        Assert.Multiple(() =>
        {
            for (var i = 0; i < input.Length; i++)
            for (var j = 0; j < input[i].Length; j++)
            {
                Assert.AreEqual(expected[i][j], actual[i][j]);
            }
        });
    }

    [Test]
    public void Test_004()
    {
        var input = new[]
        {
            new[] { 0, 1, },
            new[] { 1, 1, },
        };
        var expected = new[]
        {
            new[] { 0, 0, },
            new[] { 0, 1, },
        };
        var actual = new Class1().NullifyRowsAndColumns(input);

        Assert.Multiple(() =>
        {
            for (var i = 0; i < input.Length; i++)
            for (var j = 0; j < input[i].Length; j++)
            {
                Assert.AreEqual(expected[i][j], actual[i][j]);
            }
        });
    }

    [Test]
    public void Test_005()
    {
        var input = new[]
        {
            new[] { 1, 1, 1, },
            new[] { 1, 0, 1, },
            new[] { 1, 1, 1, },
        };
        var expected = new[]
        {
            new[] { 1, 0, 1, },
            new[] { 0, 0, 0, },
            new[] { 1, 0, 1, },
        };
        var actual = new Class1().NullifyRowsAndColumns(input);

        Assert.Multiple(() =>
        {
            for (var i = 0; i < input.Length; i++)
            for (var j = 0; j < input[i].Length; j++)
            {
                Assert.AreEqual(expected[i][j], actual[i][j]);
            }
        });
    }
}