namespace AddBinary.Tests;

public class Tests
{
    [TestCase("0", "0", "0")]
    [TestCase("11", "1", "100")]
    public void Test_000(string a, string b, string expected)
    {
        var actual = new Solution().AddBinary(a, b);
        Assert.That(actual, Is.EqualTo(expected));
    }
}