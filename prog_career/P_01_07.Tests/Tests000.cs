using NUnit.Framework;

namespace P_01_07.Tests;

public class Tests000
{
    [Test]
    public void Test_000()
    {
        // 0 0
        // 1 1
        // =>
        // 1 0
        // 1 0

        var input = new[]
        {
            new[] { 0, 0 },
            new[] { 1, 1 },
        };
        var expected = new[]
        {
            new[] { 1, 0 },
            new[] { 1, 0 },
        };
        var actual = new Class1().Rotate_000(input);
        Assert.Multiple(() =>
        {
            for (var i = 0; i < expected.Length; i++)
            for (var j = 0; j < expected.Length; j++)
            {
                Assert.AreEqual(expected[i][j], actual[i][j]);
            }
        });
    }

    [Test]
    public void Test_001()
    {
        // 0 0 0
        // 1 1 1
        // 2 2 2
        // =>
        // 2 1 0
        // 2 1 0
        // 2 1 0

        var input = new[]
        {
            new[] { 0, 0, 0 },
            new[] { 1, 1, 1 },
            new[] { 2, 2, 2 },
        };
        var expected = new[]
        {
            new[] { 2, 1, 0 },
            new[] { 2, 1, 0 },
            new[] { 2, 1, 0 },
        };
        var actual = new Class1().Rotate_000(input);
        Assert.Multiple(() =>
        {
            for (var i = 0; i < expected.Length; i++)
            for (var j = 0; j < expected.Length; j++)
            {
                Assert.AreEqual(expected[i][j], actual[i][j]);
            }
        });
    }

    [Test]
    public void Test_002()
    {
        // 0 0 0 0
        // 1 1 1 1
        // 2 2 2 2
        // 3 3 3 3
        // =>
        // 3 2 1 0
        // 3 2 1 0
        // 3 2 1 0
        // 3 2 1 0

        var input = new[]
        {
            new[] { 0, 0, 0, 0 },
            new[] { 1, 1, 1, 1 },
            new[] { 2, 2, 2, 2 },
            new[] { 3, 3, 3, 3 },
        };
        var expected = new[]
        {
            new[] { 3, 2, 1, 0 },
            new[] { 3, 2, 1, 0 },
            new[] { 3, 2, 1, 0 },
            new[] { 3, 2, 1, 0 },
        };
        var actual = new Class1().Rotate_000(input);
        Assert.Multiple(() =>
        {
            for (var i = 0; i < expected.Length; i++)
            for (var j = 0; j < expected.Length; j++)
            {
                Assert.AreEqual(expected[i][j], actual[i][j]);
            }
        });
    }
}