namespace ExpressionAddOperators.Tests;

public class Tests
{
    [TestCase("1", 1, new[] { "1" })]
    [TestCase("2", 2, new[] { "2" })]
    [TestCase("12", 12, new[] { "12" })]
    [TestCase("11", 2, new[] { "1+1" })]
    [TestCase("111", 3, new[] { "1+1+1" })]
    [TestCase("111", 12, new[] { "1+11", "11+1" })]
    [TestCase("11", 0, new[] { "1-1" })]
    [TestCase("111", 10, new[] { "11-1" })]
    [TestCase("1011", 110, new[] { "10*11" })]
    [TestCase("1111", 11, new[] { "11+1-1", "11-1+1", "1-1+11", "1+11-1", "1*1*11", "1*11*1", "11*1*1" })]
    [TestCase("11", 1, new[] { "1*1" })]
    [TestCase("123", 6, new[] { "1*2*3", "1+2+3" })]
    [TestCase("232", 8, new[] { "2*3+2", "2+3*2" })]
    [TestCase("3456237490", 9191, new string[0])]
    [TestCase("105", 5, new[] { "1*0+5", "10-5" })]
    [TestCase("105", 6, new[] { "1-0+5", "1+0+5" })]
    [TestCase("2147483648", -2147483648, new string[0])]
    [TestCase("00", 0, new[] { "0*0", "0+0", "0-0" })]
    public void Test_000(string input, int target, string[] expected)
    {
        var actual = new Solution().AddOperators_000(input, target);
        CollectionAssert.AreEquivalent(expected, actual);
    }

    [TestCase("1", 1, new[] { "1" })]
    [TestCase("2", 2, new[] { "2" })]
    [TestCase("12", 12, new[] { "12" })]
    [TestCase("11", 2, new[] { "1+1" })]
    [TestCase("111", 3, new[] { "1+1+1" })]
    [TestCase("111", 12, new[] { "1+11", "11+1" })]
    [TestCase("11", 0, new[] { "1-1" })]
    [TestCase("111", 10, new[] { "11-1" })]
    [TestCase("1011", 110, new[] { "10*11" })]
    [TestCase("1111", 11, new[] { "11+1-1", "11-1+1", "1-1+11", "1+11-1", "1*1*11", "1*11*1", "11*1*1" })]
    [TestCase("11", 1, new[] { "1*1" })]
    [TestCase("123", 6, new[] { "1*2*3", "1+2+3" })]
    [TestCase("232", 8, new[] { "2*3+2", "2+3*2" })]
    [TestCase("3456237490", 9191, new string[0])]
    [TestCase("105", 5, new[] { "1*0+5", "10-5" })]
    [TestCase("105", 6, new[] { "1-0+5", "1+0+5" })]
    [TestCase("2147483648", -2147483648, new string[0])]
    [TestCase("00", 0, new[] { "0*0", "0+0", "0-0" })]
    public void Test_001(string input, int target, string[] expected)
    {
        var actual = new Solution().AddOperators_001(input, target);
        CollectionAssert.AreEquivalent(expected, actual);
    }
}