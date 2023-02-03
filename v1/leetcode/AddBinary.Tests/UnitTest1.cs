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

    [Test]
    public void Test_001()
    {
        var list = new List<int>();
        Assert.That(~list.BinarySearch(0), Is.EqualTo(0));
        list.Add(0);
        Assert.That(~list.BinarySearch(1), Is.EqualTo(1));
        list.Add(1);
        Assert.That(list.BinarySearch(0), Is.EqualTo(0));
    }
}