using System.Text;
using Newtonsoft.Json;

namespace CountArrayPairsDivisibleByK.Tests;

public class Tests
{
    [TestCase(new[] { 1, 2 }, 2, 1)]
    [TestCase(new[] { 1, 2, 3 }, 2, 2)]
    [TestCase(new[] { 1, 2, 3, 4, 5 }, 2, 7)]
    public void Test_000(int[] input, int k, int expected)
    {
        var actual = new Solution().CountPairs_000(input, k);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(new[] { 1, 2 }, 2, 1)]
    [TestCase(new[] { 1, 2, 3 }, 2, 2)]
    [TestCase(new[] { 1, 2, 3, 4, 5 }, 2, 7)]
    public void Test_001(int[] input, int k, int expected)
    {
        var actual = new Solution().CountPairs_001(input, k);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Test_002()
    {
        var input = Get_Input000();
        var actual = new Solution().CountPairs_000(input, 95517);
        Assert.That(actual, Is.EqualTo(112655));
    }

    [Test]
    public void Test_003()
    {
        var input = Get_Input000();
        var actual = new Solution().CountPairs_001(input, 95517);
        Assert.That(actual, Is.EqualTo(112655));
    }

    [TestCase(new[] { 1, 2 }, 2, 1)]
    [TestCase(new[] { 1, 2, 3 }, 2, 2)]
    [TestCase(new[] { 1, 2, 3, 4, 5 }, 2, 7)]
    public void Test_004(int[] input, int k, int expected)
    {
        var actual = new Solution().CountPairs_002(input, k);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Test_005()
    {
        var input = Get_Input000();
        var actual = new Solution().CountPairs_002(input, 95517);
        Assert.That(actual, Is.EqualTo(112655));
    }

    private int[] Get_Input000()
    {
        var resourceStream = GetType().Assembly
            .GetManifestResourceStream("CountArrayPairsDivisibleByK.Tests.input_000.json");
        if (resourceStream == null)
            throw new ApplicationException();
        using var reader = new StreamReader(resourceStream, Encoding.UTF8);
        var data = reader.ReadToEnd();
        return JsonConvert.DeserializeObject<int[]>(data) ?? throw new ApplicationException();
    }
}