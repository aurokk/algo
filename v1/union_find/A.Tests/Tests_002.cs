namespace A.Tests;

public class UnionFind_002
{
    private readonly int[] _roots;
    private readonly int[] _rank;

    public UnionFind_002(int size)
    {
        _roots = new int[size];
        _rank = new int[size];
        for (var i = 0; i < size; i++)
        {
            _roots[i] = i;
            _rank[i] = 1;
        }
    }

    public void Union(int a, int b)
    {
        var rootA = Find(a);
        var rootB = Find(b);
        if (rootA != rootB)
        {
            var rankA = _rank[rootA];
            var rankB = _rank[rootB];

            if (rankA >= rankB)
            {
                _roots[rootB] = rootA;
                _rank[rootB]++;
            }
            else
            {
                _roots[rootA] = rootB;
                _rank[rootA]++;
            }
        }
    }

    public int Find(int a)
    {
        if (a == _roots[a])
        {
            return a;
        }

        return _roots[a] = Find(_roots[a]);
    }
}

public class Tests_002
{
    [Test]
    public void Test_000()
    {
        var uf = new UnionFind_002(10);

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