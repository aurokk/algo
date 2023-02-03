namespace LFUCache;

// start: 18:10
// break: 19:40
// start: 19:50

public class DataNode
{
    public int Key { get; set; }
    public int Value { get; set; }
    public FrequencyNode Frequency { get; set; } = null!;
}

public class FrequencyNode
{
    public int Key { get; set; }
    public int Count { get; set; }
    public FrequencyNode? Prev { get; set; }
    public FrequencyNode? Next { get; set; }
}

public class Cache
{
    private readonly Dictionary<int, DataNode> _data;
    private readonly Dictionary<int, FrequencyNode> _freq;
    private readonly int _capacity;

    public IReadOnlyDictionary<int, DataNode> Data => _data;
    public IReadOnlyDictionary<int, FrequencyNode> Freq => _freq;
    public int Size { get; private set; }

    public Cache(int capacity)
    {
        _data = new Dictionary<int, DataNode>();
        _freq = new Dictionary<int, FrequencyNode>();
        _capacity = capacity;
        Size = 0;
    }

    public int Get(int key)
    {
        if (_data.ContainsKey(key))
        {
            var d = _data[key];
            UpdateCounts(key);
            return d.Value;
        }

        return -1;
    }

    private void UpdateCounts(int key)
    {
        var d = _data[key];
        var f = d.Frequency;
        var oldCount = f.Count;
        var newCount = f.Count + 1;
        f.Count = newCount;

        if (_freq[oldCount] == f)
        {
            // extract
            var p = f.Prev;
            var n = f.Next;

            if (p != null && p.Count == oldCount)
            {
                _freq[oldCount] = p;
            }
            else
            {
                _freq.Remove(oldCount);
            }

            // put
            if (_freq.ContainsKey(newCount))
            {
                var pf = _freq[newCount];

                if (p != null)
                {
                    p.Next = n;
                }

                if (n != null)
                {
                    n.Prev = p;
                }

                f.Next = pf.Next;
                f.Prev = pf;
                pf.Next = f;
                _freq[newCount] = f;
            }
            else
            {
                _freq[newCount] = f;
            }

            return;
        }
        else
        {
            // extract
            var n = f.Next;
            var p = f.Prev;
            if (n != null)
            {
                n.Prev = p;
            }

            if (p != null)
            {
                p.Next = n;
            }

            // insert
            if (_freq.ContainsKey(newCount))
            {
                var x = _freq[newCount];
                f.Next = x.Next;
                f.Prev = x;
                x.Next = f;
                _freq[newCount] = f;
            }
            else
            {
                var x = _freq[oldCount];
                f.Next = x.Next;
                f.Prev = x;
                x.Next = f;
                _freq[newCount] = f;
            }

            return;
        }
    }

    public void Put(int key, int value)
    {
        if (_data.ContainsKey(key))
        {
            var d = _data[key];
            d.Value = value;
            UpdateCounts(key);
            return;
        }

        {
            var f = new FrequencyNode { Key = key, Count = 1, };
            var d = new DataNode { Key = key, Value = value, Frequency = f, };
            _data[key] = d;
            if (_freq.ContainsKey(f.Count))
            {
                var pf = _freq[f.Count];
                f.Prev = pf;
                pf.Next = f;
                _freq[f.Count] = f;
            }
            else
            {
                _freq[f.Count] = f;
            }

            Size++;
        }
    }
}

public class Tests
{
    [Test]
    public void Test_000()
    {
        var sut = new Cache(1);
        Assert.That(sut.Get(1), Is.EqualTo(-1));
    }

    [Test]
    public void Test_001()
    {
        var sut = new Cache(1);
        sut.Put(1, 1);
        Assert.That(sut.Get(1), Is.EqualTo(1));
    }

    [Test]
    public void Test_002()
    {
        var sut = new Cache(1);
        sut.Put(1, 1);
        sut.Put(1, 2);
        Assert.That(sut.Get(1), Is.EqualTo(2));
    }

    [Test]
    public void Test_003()
    {
        var sut = new Cache(1);
        Assert.That(sut.Size, Is.EqualTo(0));
    }

    [Test]
    public void Test_004()
    {
        var sut = new Cache(1);
        sut.Put(1, 1);
        Assert.That(sut.Size, Is.EqualTo(1));
    }

    [Test]
    public void Test_005()
    {
        var sut = new Cache(1);
        sut.Put(1, 1);
        sut.Put(1, 2);
        Assert.That(sut.Size, Is.EqualTo(1));
    }

    [Test]
    public void Test_006()
    {
        var sut = new Cache(1);
        sut.Put(1, 1);
        Assert.That(sut.Freq.ContainsKey(1), Is.True);
        Assert.That(sut.Freq[1], Has.Count.EqualTo(1));
    }

    [Test]
    public void Test_007()
    {
        var sut = new Cache(1);
        sut.Put(1, 1);
        sut.Put(1, 2);
        Assert.That(sut.Freq.ContainsKey(1), Is.False);
    }

    [Test]
    public void Test_008()
    {
        var sut = new Cache(1);
        sut.Put(1, 1);
        sut.Put(1, 2);
        Assert.That(sut.Freq.ContainsKey(2), Is.True);
        Assert.That(sut.Freq[2], Has.Count.EqualTo(2));
    }

    [Test]
    public void Test_009()
    {
        var sut = new Cache(1);
        sut.Put(1, 1);
        sut.Put(1, 2);
        sut.Get(1);
        Assert.That(sut.Freq.ContainsKey(2), Is.False);
    }

    [Test]
    public void Test_010()
    {
        var sut = new Cache(1);
        sut.Put(1, 1);
        sut.Put(1, 2);
        sut.Get(1);
        Assert.That(sut.Freq.ContainsKey(3), Is.True);
        Assert.That(sut.Freq[3], Has.Count.EqualTo(3));
    }

    [Test]
    public void Test_011()
    {
        var sut = new Cache(2);
        sut.Put(1, 1);
        sut.Put(2, 2);
        Assert.That(sut.Size, Is.EqualTo(2));
    }

    [Test]
    public void Test_012()
    {
        var sut = new Cache(2);
        sut.Put(1, 1);
        sut.Put(2, 2);
        Assert.That(sut.Get(2), Is.EqualTo(2));
    }

    [Test]
    public void Test_013()
    {
        var sut = new Cache(2);
        sut.Put(1, 1);
        sut.Put(2, 2);
        sut.Put(2, 3);
        Assert.That(sut.Get(2), Is.EqualTo(3));
    }

    [Test]
    public void Test_014()
    {
        var sut = new Cache(2);
        sut.Put(1, 1);
        sut.Put(2, 2);
        Assert.That(sut.Freq.ContainsKey(1), Is.True);
        Assert.That(sut.Freq[1], Is.EqualTo(sut.Data[2].Frequency));
        Assert.That(sut.Freq[1].Next, Is.Null);
        Assert.That(sut.Freq[1].Prev, Is.EqualTo(sut.Data[1].Frequency));
    }

    [Test]
    public void Test_015()
    {
        var sut = new Cache(2);
        sut.Put(1, 1);
        sut.Put(2, 2);
        sut.Put(2, 3);
        //
        Assert.That(sut.Freq.ContainsKey(1), Is.True);
        Assert.That(sut.Freq[1], Is.EqualTo(sut.Data[1].Frequency));
        Assert.That(sut.Freq[1].Prev, Is.Null);
        Assert.That(sut.Freq[1].Next, Is.EqualTo(sut.Freq[2]));
        //
        Assert.That(sut.Freq.ContainsKey(2), Is.True);
        Assert.That(sut.Freq[2], Is.EqualTo(sut.Data[2].Frequency));
        Assert.That(sut.Freq[2].Prev, Is.EqualTo(sut.Freq[1]));
        Assert.That(sut.Freq[2].Next, Is.Null);
    }

    [Test]
    public void Test_016()
    {
        var sut = new Cache(2);
        sut.Put(1, 1);
        sut.Put(2, 2);
        sut.Put(2, 3);
        sut.Put(1, 4);
        Assert.That(sut.Freq.ContainsKey(1), Is.False);
        Assert.That(sut.Freq.ContainsKey(2), Is.True);
        Assert.That(sut.Freq[2], Is.EqualTo(sut.Data[1].Frequency));
        Assert.That(sut.Freq[2].Next, Is.Null);
        Assert.That(sut.Freq[2].Prev, Is.EqualTo(sut.Data[2].Frequency));
        Assert.That(sut.Data[2].Frequency.Prev, Is.Null);
    }

    [Test]
    public void Test_017()
    {
        var sut = new Cache(2);
        sut.Put(1, 1);
        sut.Put(2, 2);
        sut.Put(2, 3);
        sut.Put(1, 4);
        sut.Put(2, 5);
        Assert.That(sut.Freq.ContainsKey(1), Is.False);
        Assert.That(sut.Freq.ContainsKey(2), Is.True);
        Assert.That(sut.Freq[2], Is.EqualTo(sut.Data[1].Frequency));
        Assert.That(sut.Freq[2].Next, Is.EqualTo(sut.Freq[3]));
        Assert.That(sut.Freq[2].Prev, Is.Null);
        Assert.That(sut.Freq.ContainsKey(3), Is.True);
        Assert.That(sut.Freq[3], Is.EqualTo(sut.Data[2].Frequency));
        Assert.That(sut.Freq[3].Next, Is.Null);
        Assert.That(sut.Freq[3].Prev, Is.EqualTo(sut.Freq[2]));
    }

    [Test]
    public void Test_018()
    {
        var sut = new Cache(2);
        sut.Put(1, 1);
        sut.Put(2, 2);
        sut.Put(2, 3);
        sut.Put(1, 4);
        sut.Put(2, 5);
        sut.Put(2, 6);
        Assert.That(sut.Freq.ContainsKey(1), Is.False);
        Assert.That(sut.Freq.ContainsKey(2), Is.True);
        Assert.That(sut.Freq[2], Is.EqualTo(sut.Data[1].Frequency));
        Assert.That(sut.Freq[2].Next, Is.EqualTo(sut.Freq[4]));
        Assert.That(sut.Freq[2].Prev, Is.Null);
        Assert.That(sut.Freq.ContainsKey(3), Is.False);
        Assert.That(sut.Freq.ContainsKey(4), Is.True);
        Assert.That(sut.Freq[4], Is.EqualTo(sut.Data[2].Frequency));
        Assert.That(sut.Freq[4].Next, Is.Null);
        Assert.That(sut.Freq[4].Prev, Is.EqualTo(sut.Freq[2]));
    }

    [Test]
    public void Test_019()
    {
        var sut = new Cache(2);
        sut.Put(1, 1);
        sut.Put(2, 2);
        sut.Put(2, 3);
        sut.Put(1, 4);
        sut.Put(2, 5);
        sut.Put(2, 6);
        sut.Get(2);
        Assert.That(sut.Freq.ContainsKey(1), Is.False);
        Assert.That(sut.Freq.ContainsKey(2), Is.True);
        Assert.That(sut.Freq[2], Is.EqualTo(sut.Data[1].Frequency));
        Assert.That(sut.Freq[2].Next, Is.EqualTo(sut.Freq[5]));
        Assert.That(sut.Freq[2].Prev, Is.Null);
        Assert.That(sut.Freq.ContainsKey(4), Is.False);
        Assert.That(sut.Freq.ContainsKey(5), Is.True);
        Assert.That(sut.Freq[5], Is.EqualTo(sut.Data[2].Frequency));
        Assert.That(sut.Freq[5].Next, Is.Null);
        Assert.That(sut.Freq[5].Prev, Is.EqualTo(sut.Freq[2]));
    }

    [Test]
    public void Test_020()
    {
        var sut = new Cache(2);
        sut.Put(1, 1);
        sut.Put(2, 2);
        sut.Get(1);
        Assert.That(sut.Freq.ContainsKey(1), Is.True);
        Assert.That(sut.Freq.ContainsKey(2), Is.True);
        Assert.That(sut.Freq[1], Is.EqualTo(sut.Data[2].Frequency));
        Assert.That(sut.Freq[1].Next, Is.EqualTo(sut.Freq[2]));
        Assert.That(sut.Freq[1].Prev, Is.Null);
        Assert.That(sut.Freq[2], Is.EqualTo(sut.Data[1].Frequency));
        Assert.That(sut.Freq[2].Next, Is.Null);
        Assert.That(sut.Freq[2].Prev, Is.EqualTo(sut.Freq[1]));
    }
}