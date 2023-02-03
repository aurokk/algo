using NUnit.Framework;

namespace ReverseInteger.Tests;

public class Tests
{
    [TestCase(123, 321)]
    [TestCase(-123, -321)]
    [TestCase(120, 21)]
    [TestCase(0, 0)]
    [TestCase(-1, -1)]
    [TestCase(-10, -1)]
    [TestCase(10, 1)]
    [TestCase(-2147483648, 0)]
    [TestCase(1463847412, 2147483641)]
    public void Test000(int input, int expected)
    {
        var actual = new Solution().Reverse(input);
        Assert.AreEqual(expected, actual);
    }
}