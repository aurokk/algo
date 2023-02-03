namespace OrientationOfThreePoints;

public enum Orientation
{
    Clockwise = 1,
    CounterClockwise = 2,
    Collinear = 3,
}

public class Solution
{
    // Классная статья по теме http://e-maxx.ru/algo/oriented_area
    //      | x2 - x1, y2 - y1 | 
    // 2S = | x3 - x1, y3 - y1 | = (x2 - x1) * (y3 - y1) - (x3 - x1) * (y2 - y1)
    public Orientation GetOrientation(int[] p1, int[] p2, int[] p3)
    {
        var product = (p2[0] - p1[0]) * (p3[1] - p1[1]) - (p3[0] - p1[0]) * (p2[1] - p1[1]);
        if (product == 0) return Orientation.Collinear;
        else return product > 0 ? Orientation.CounterClockwise : Orientation.Clockwise;
    }
}

public class Tests
{
    [TestCase(new[] { 0, 0 }, new[] { 4, 4 }, new[] { 1, 2 }, Orientation.CounterClockwise)]
    [TestCase(new[] { 0, 0 }, new[] { 4, 4 }, new[] { 1, 1 }, Orientation.Collinear)]
    public void Test_000(int[] p1, int[] p2, int[] p3, Orientation expected)
    {
        var actual = new Solution().GetOrientation(p1, p2, p3);
        Assert.AreEqual(expected, actual);
    }
}