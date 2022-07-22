namespace OpenTheLock.Tests;

public class Tests
{
    [TestCase(new[] { "0201", "0101", "0102", "1212", "2002" }, "0202", 6)]
    public void Test_000(string[] input, string target, int expected)
    {
        var actual = new Solution().OpenLock(input, target);
        Assert.That(actual, Is.EqualTo(expected));
    }
}