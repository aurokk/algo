namespace ReverseWordsInString.Tests;

public class Tests
{
    [TestCase("the sky is blue", "blue is sky the")]
    public void Test_000(string s, string expected)
    {
        var actual = new Solution().ReverseWords(s);
        Assert.That(actual, Is.EqualTo(expected));
    }
}