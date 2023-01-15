namespace A.Tests;

public class UnionFind_000
{
    private readonly int[] _roots;

    public UnionFind_000(int size)
    {
        _roots = new int[size];
        for (var i = 0; i < size; i++)
        {
            _roots[i] = i;
        }
    }

    public void Union(int a, int b)
    {
        var rootA = Find(a);
        var rootB = Find(b);
        if (rootA != rootB)
        {
            _roots[rootA] = rootB;
        }
    }

    public int Find(int a)
    {
        var root = a;
        while (root != _roots[root])
        {
            root = _roots[root];
        }

        return root;
    }
}

public class Tests_000
{
    [Test]
    public void Test_000()
    {
        var uf = new UnionFind_000(10);

        var connections = new[]
        {
            // 1
            (0, 1),
            (1, 2),
            (0, 3),

            // 2
            (4, 8),

            // 3
            (5, 6),
            (5, 7),
        };

        foreach (var (a, b) in connections)
            uf.Union(a, b);

        var groups = Enumerable
            .Range(0, 10)
            .Select(x => uf.Find(x))
            .Distinct()
            .ToArray();

        Assert.That(groups, Has.Length.EqualTo(4));
    }
}