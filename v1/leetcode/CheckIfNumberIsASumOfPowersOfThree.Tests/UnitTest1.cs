namespace CheckIfNumberIsASumOfPowersOfThree.Tests;

public class Tests
{
    [TestCase(1, true)]
    [TestCase(2, false)]
    [TestCase(3, true)]
    [TestCase(4, true)]
    [TestCase(5, false)]
    [TestCase(6, false)]
    [TestCase(7, false)]
    [TestCase(8, false)]
    [TestCase(9, true)]
    [TestCase(10, true)]
    [TestCase(11, false)]
    [TestCase(12, true)]
    public void Test_000(int number, bool expected)
    {
        var actual = new Solution().CheckPowersOfThree_000(number);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(1, true)]
    [TestCase(2, false)]
    [TestCase(3, false)]
    [TestCase(4, true)]
    [TestCase(5, true)]
    [TestCase(6, false)]
    [TestCase(7, false)]
    [TestCase(8, false)]
    [TestCase(9, false)]
    [TestCase(10, false)]
    [TestCase(11, false)]
    [TestCase(12, false)]
    [TestCase(16, true)]
    [TestCase(17, true)]
    [TestCase(21, true)]
    public void Test_001(int number, bool expected)
    {
        var actual = new Solution().CheckPowersOfFour(number);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(1, true)]
    [TestCase(2, false)]
    [TestCase(3, false)]
    [TestCase(4, false)]
    [TestCase(5, true)]
    [TestCase(6, true)]
    [TestCase(7, false)]
    [TestCase(8, false)]
    [TestCase(9, false)]
    [TestCase(10, false)]
    [TestCase(11, false)]
    [TestCase(12, false)]
    [TestCase(25, true)]
    [TestCase(26, true)]
    [TestCase(31, true)]
    public void Test_002(int number, bool expected)
    {
        var actual = new Solution().CheckPowersOfFive(number);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(1, true)]
    [TestCase(2, false)]
    [TestCase(3, true)]
    [TestCase(4, true)]
    [TestCase(5, false)]
    [TestCase(6, false)]
    [TestCase(7, false)]
    [TestCase(8, false)]
    [TestCase(9, true)]
    [TestCase(10, true)]
    [TestCase(11, false)]
    [TestCase(12, true)]
    public void Test_003(int number, bool expected)
    {
        var actual = new Solution().CheckPowersOfThree_001(number);
        Assert.That(actual, Is.EqualTo(expected));
    }
}