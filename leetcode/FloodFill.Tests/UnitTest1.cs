namespace FloodFill.Tests;

public class Tests
{
    [Test]
    public void Test1()
    {
        var image = new[] { new[] { 0, 0, 0 } };
        var actual = new Solution().FloodFill(image, 0, 0, 0);
        Assert.Pass();
    }
}