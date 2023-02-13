namespace LFUCache;

// start: 18:10
// break: 19:40
// start: 19:50
// break: 20:10
// start: 18:26
// break: 19:40
// start: 19:48
// break: 21:15
// start: 16:38
// finish: 17:18 <- first accepted sumbission
// start: 20:14
// finish: 21:30
// start: 21:46
// finish: 22:14

public class DataNode
{
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

public class LFUCache
{
    private readonly Dictionary<int, DataNode> _data;
    private readonly Dictionary<int, FrequencyNode> _freq;
    private readonly int _capacity;

    public IReadOnlyDictionary<int, DataNode> Data => _data;
    public IReadOnlyDictionary<int, FrequencyNode> Freq => _freq;
    public int Size { get; private set; }
    public FrequencyNode? Head { get; private set; }

    public LFUCache(int capacity)
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
        var currData = _data[key];
        var currFreq = currData.Frequency;
        var oldCount = currFreq.Count;
        var newCount = currFreq.Count + 1;
        currFreq.Count = newCount;

        if (Head != null &&
            Head.Key == key &&
            Head.Next != null &&
            Head.Next.Count <= newCount)
        {
            Head = Head.Next;
            Head.Prev = null;
        }

        if (_freq[oldCount] == currFreq)
        {
            {
                // adjust _freq
                var prev = currFreq.Prev;
                if (prev != null && prev.Count == oldCount)
                    _freq[oldCount] = prev;
                else
                    _freq.Remove(oldCount);
            }

            if (_freq.ContainsKey(newCount))
            {
                {
                    // extract
                    var prev = currFreq.Prev;
                    var next = currFreq.Next;
                    if (prev != null)
                        prev.Next = next;
                    if (next != null)
                        next.Prev = prev;
                }
                
                {
                    // insert
                    var prev = _freq[newCount];
                    var next = _freq[newCount].Next;
                    Insert(prev, currFreq, next);
                }
            }
            else
            {
                _freq[newCount] = currFreq;
            }

            return;
        }

        {
            {
                // extract
                var next = currFreq.Next;
                var prev = currFreq.Prev;
                if (next != null)
                    next.Prev = prev;
                if (prev != null)
                    prev.Next = next;
            }

            {
                // insert
                if (_freq.ContainsKey(newCount))
                {
                    var prev = _freq[newCount];
                    var next = _freq[newCount].Next;
                    Insert(prev, currFreq, next);
                }
                else
                {
                    var prev = _freq[oldCount];
                    var next = _freq[oldCount].Next;
                    Insert(prev, currFreq, next);
                }
            }

            return;
        }
    }

    public void Put(int key, int value)
    {
        {
            // edge case
            if (_capacity == 0)
            {
                return;
            }
        }

        {
            // key exists
            if (_data.ContainsKey(key))
            {
                var d = _data[key];
                d.Value = value;
                UpdateCounts(key);
                return;
            }
        }

        {
            {
                // full
                if (Size == _capacity)
                {
                    RemoveLeastFrequent();
                }
            }

            var currFreq = new FrequencyNode { Key = key, Count = 1, };
            var currData = new DataNode { Value = value, Frequency = currFreq, };
            _data[key] = currData;
            Size++;

            {
                // contains count
                if (_freq.ContainsKey(currFreq.Count))
                {
                    var prev = _freq[currFreq.Count];
                    var next = _freq[currFreq.Count].Next;
                    Insert(prev, currFreq, next);
                    return;
                }
            }

            {
                var next = Head;
                Insert(null, currFreq, next);
                Head = currFreq;
                return;
            }
        }
    }

    private void Insert(FrequencyNode? prev, FrequencyNode curr, FrequencyNode? next)
    {
        curr.Prev = prev;
        if (prev != null)
            prev.Next = curr;

        curr.Next = next;
        if (next != null)
            next.Prev = curr;

        _freq[curr.Count] = curr;
    }

    private void MoveHeadToNext()
    {
        if (Head == null)
            throw new Exception();

        Head = Head.Next;
        if (Head != null)
            Head.Prev = null;
    }

    private void RemoveLeastFrequent()
    {
        if (Head == null)
            throw new Exception();

        _data.Remove(Head.Key);
        if (_freq[Head.Count] == Head)
            _freq.Remove(Head.Count);

        MoveHeadToNext();

        Size--;
    }
}

public class Tests
{
    [Test]
    public void Test_000()
    {
        var sut = new LFUCache(1);
        Assert.That(sut.Get(1), Is.EqualTo(-1));
    }

    [Test]
    public void Test_001()
    {
        var sut = new LFUCache(1);
        sut.Put(1, 1);
        Assert.That(sut.Get(1), Is.EqualTo(1));
    }

    [Test]
    public void Test_002()
    {
        var sut = new LFUCache(1);
        sut.Put(1, 1);
        sut.Put(1, 2);
        Assert.That(sut.Get(1), Is.EqualTo(2));
    }

    [Test]
    public void Test_003()
    {
        var sut = new LFUCache(1);
        Assert.That(sut.Size, Is.EqualTo(0));
    }

    [Test]
    public void Test_004()
    {
        var sut = new LFUCache(1);
        sut.Put(1, 1);
        Assert.That(sut.Size, Is.EqualTo(1));
    }

    [Test]
    public void Test_005()
    {
        var sut = new LFUCache(1);
        sut.Put(1, 1);
        sut.Put(1, 2);
        Assert.That(sut.Size, Is.EqualTo(1));
    }

    [Test]
    public void Test_006()
    {
        var sut = new LFUCache(1);
        sut.Put(1, 1);
        Assert.That(sut.Freq.ContainsKey(1), Is.True);
        Assert.That(sut.Freq[1], Has.Count.EqualTo(1));
    }

    [Test]
    public void Test_007()
    {
        var sut = new LFUCache(1);
        sut.Put(1, 1);
        sut.Put(1, 2);
        Assert.That(sut.Freq.ContainsKey(1), Is.False);
    }

    [Test]
    public void Test_008()
    {
        var sut = new LFUCache(1);
        sut.Put(1, 1);
        sut.Put(1, 2);
        Assert.That(sut.Freq.ContainsKey(2), Is.True);
        Assert.That(sut.Freq[2], Has.Count.EqualTo(2));
    }

    [Test]
    public void Test_009()
    {
        var sut = new LFUCache(1);
        sut.Put(1, 1);
        sut.Put(1, 2);
        sut.Get(1);
        Assert.That(sut.Freq.ContainsKey(2), Is.False);
    }

    [Test]
    public void Test_010()
    {
        var sut = new LFUCache(1);
        sut.Put(1, 1);
        sut.Put(1, 2);
        sut.Get(1);
        Assert.That(sut.Freq.ContainsKey(3), Is.True);
        Assert.That(sut.Freq[3], Has.Count.EqualTo(3));
    }

    [Test]
    public void Test_011()
    {
        var sut = new LFUCache(2);
        sut.Put(1, 1);
        sut.Put(2, 2);
        Assert.That(sut.Size, Is.EqualTo(2));
    }

    [Test]
    public void Test_012()
    {
        var sut = new LFUCache(2);
        sut.Put(1, 1);
        sut.Put(2, 2);
        Assert.That(sut.Get(2), Is.EqualTo(2));
    }

    [Test]
    public void Test_013()
    {
        var sut = new LFUCache(2);
        sut.Put(1, 1);
        sut.Put(2, 2);
        sut.Put(2, 3);
        Assert.That(sut.Get(2), Is.EqualTo(3));
    }

    [Test]
    public void Test_014()
    {
        var sut = new LFUCache(2);
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
        var sut = new LFUCache(2);
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
        var sut = new LFUCache(2);
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
        var sut = new LFUCache(2);
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
        var sut = new LFUCache(2);
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
        var sut = new LFUCache(2);
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
        var sut = new LFUCache(2);
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

    [Test]
    public void Test_021()
    {
        var sut = new LFUCache(2);
        sut.Put(1, 1);
        sut.Put(2, 2);
        sut.Put(3, 3);
        Assert.That(sut.Size, Is.EqualTo(2));
    }

    [Test]
    public void Test_022()
    {
        var sut = new LFUCache(2);
        sut.Put(1, 1);
        Assert.That(sut.Head, Is.EqualTo(sut.Data[1].Frequency));
    }

    [Test]
    public void Test_023()
    {
        var sut = new LFUCache(2);
        sut.Put(1, 1);
        sut.Put(2, 2);
        Assert.That(sut.Head, Is.EqualTo(sut.Data[1].Frequency));
    }

    [Test]
    public void Test_024()
    {
        var sut = new LFUCache(2);
        sut.Put(1, 1);
        sut.Put(2, 2);
        sut.Put(3, 3);
        Assert.That(sut.Head, Is.EqualTo(sut.Data[2].Frequency));
    }

    [Test]
    public void Test_025()
    {
        var sut = new LFUCache(2);
        sut.Put(1, 1);
        sut.Put(2, 2);
        sut.Put(3, 3);
        sut.Put(2, 4);
        Assert.That(sut.Head, Is.EqualTo(sut.Data[3].Frequency));
    }

    [Test]
    public void Test_026()
    {
        var sut = new LFUCache(2);
        sut.Put(1, 1);
        sut.Put(2, 2);
        sut.Put(3, 3);
        sut.Get(2);
        Assert.That(sut.Head, Is.EqualTo(sut.Data[3].Frequency));
    }

    [Test]
    public void Test_027()
    {
        var sut = new LFUCache(2);
        sut.Put(1, 1);
        sut.Put(2, 2);
        sut.Put(3, 3);
        sut.Get(2);
        sut.Get(3);
        Assert.That(sut.Head, Is.EqualTo(sut.Data[2].Frequency));
    }

    [Test]
    public void Test_028()
    {
        var sut = new LFUCache(2);
        sut.Put(1, 1);
        sut.Put(2, 2);
        sut.Put(3, 3);
        sut.Get(2);
        sut.Get(3);
        sut.Get(3);
        Assert.That(sut.Head, Is.EqualTo(sut.Data[2].Frequency));
    }

    [Test]
    public void Test_029()
    {
        var sut = new LFUCache(2);
        sut.Put(1, 1);
        sut.Put(2, 2);
        sut.Put(3, 3);
        sut.Get(2);
        sut.Get(3);
        sut.Get(2);
        Assert.That(sut.Head, Is.EqualTo(sut.Data[3].Frequency));
    }

    [Test]
    public void Test_030()
    {
        var sut = new LFUCache(3);
        sut.Put(1, 1);
        sut.Put(2, 2);
        sut.Put(3, 3);
        sut.Get(1);
        sut.Get(1);
        Assert.That(sut.Head, Is.EqualTo(sut.Data[2].Frequency));
    }

    [Test]
    public void Test_031()
    {
        var sut = new LFUCache(3);
        sut.Put(1, 1);
        sut.Put(2, 2);
        sut.Put(3, 3);
        sut.Get(1);
        sut.Get(2);
        sut.Get(3);
        sut.Put(4, 4);
        Assert.That(sut.Head, Is.EqualTo(sut.Data[4].Frequency));
        Assert.That(sut.Head!.Next, Is.EqualTo(sut.Data[2].Frequency));
    }

    [Test]
    public void Test_032()
    {
        var sut = new LFUCache(10);
        sut.Put(10, 13);
        sut.Put(3, 17);
        sut.Put(6, 11);
        sut.Put(10, 5);
        sut.Put(9, 10);
        Assert.That(sut.Data[9].Frequency.Next, Is.EqualTo(sut.Data[10].Frequency));
    }

    [Test]
    public void Test_033()
    {
        var sut = new LFUCache(10);
        sut.Put(10, 13);
        sut.Put(3, 17);
        sut.Put(6, 11);
        sut.Put(10, 5);
        sut.Put(9, 10);
        Assert.That(sut.Freq[2].Prev, Is.EqualTo(sut.Freq[1]));
    }

    [Test]
    public void Test_34()
    {
        var sut = new LFUCache(10);
        sut.Put(10, 13);
        sut.Put(3, 17);
        sut.Put(6, 11);
        sut.Put(10, 5);
        sut.Put(9, 10);
        sut.Get(13);
        sut.Put(2, 19);
        sut.Get(2);
        sut.Get(3);
        sut.Put(5, 25);
        sut.Get(8);
        sut.Put(9, 22);
        sut.Put(5, 5);
        sut.Put(1, 30);
        sut.Get(11);
        sut.Put(9, 12);
        sut.Get(7);
        sut.Get(5);
        sut.Get(8);
        sut.Get(9);
        sut.Put(4, 30);
        sut.Put(9, 3);
        sut.Get(9);
        sut.Get(10);
        sut.Get(10);
        sut.Put(6, 14);
        sut.Put(3, 1);
        sut.Get(3);
        sut.Put(10, 11);
        sut.Get(8);
        sut.Put(2, 14);
        sut.Get(1);
        sut.Get(5);
        sut.Get(4);
        Assert.That(sut.Data[2].Frequency.Prev, Is.EqualTo(sut.Data[4].Frequency));
    }

    [Test]
    public void Test_35()
    {
        var sut = new LFUCache(10);
        sut.Put(10, 13);
        sut.Put(3, 17);
        sut.Put(6, 11);
        sut.Put(10, 5);
        sut.Put(9, 10);
        sut.Get(13);
        sut.Put(2, 19);
        sut.Get(2);
        sut.Get(3);
        sut.Put(5, 25);
        sut.Get(8);
        sut.Put(9, 22);
        sut.Put(5, 5);
        sut.Put(1, 30);
        sut.Get(11);
        sut.Put(9, 12);
        sut.Get(7);
        sut.Get(5);
        sut.Get(8);
        sut.Get(9);
        sut.Put(4, 30);
        sut.Put(9, 3);
        sut.Get(9);
        sut.Get(10);
        sut.Get(10);
        sut.Put(6, 14);
        sut.Put(3, 1);
        sut.Get(3);
        sut.Put(10, 11);
        sut.Get(8);
        sut.Put(2, 14);
        sut.Get(1);
        sut.Get(5);
        sut.Get(4);
        sut.Put(11, 4);
        sut.Put(12, 24);
        sut.Put(5, 18);
        sut.Get(13);
        sut.Put(7, 23);
        sut.Get(8);
        sut.Get(12);
        sut.Put(3, 27);
        sut.Put(2, 12);
        sut.Get(5);
        sut.Put(2, 9);
        sut.Put(13, 4);
        Assert.That(sut.Head, Is.EqualTo(sut.Data[13].Frequency));
    }

    [Test]
    public void Test_36()
    {
        var sut = new LFUCache(10);
        sut.Put(10, 13);
        sut.Put(3, 17);
        sut.Put(6, 11);
        sut.Put(10, 5);
        sut.Put(9, 10);
        sut.Get(13);
        sut.Put(2, 19);
        sut.Get(2);
        sut.Get(3);
        sut.Put(5, 25);
        sut.Get(8);
        sut.Put(9, 22);
        sut.Put(5, 5);
        sut.Put(1, 30);
        sut.Get(11);
        sut.Put(9, 12);
        sut.Get(7);
        sut.Get(5);
        sut.Get(8);
        sut.Get(9);
        sut.Put(4, 30);
        sut.Put(9, 3);
        sut.Get(9);
        sut.Get(10);
        sut.Get(10);
        sut.Put(6, 14);
        sut.Put(3, 1);
        sut.Get(3);
        sut.Put(10, 11);
        sut.Get(8);
        sut.Put(2, 14);
        sut.Get(1);
        sut.Get(5);
        sut.Get(4);
        sut.Put(11, 4);
        sut.Put(12, 24);
        sut.Put(5, 18);
        sut.Get(13);
        sut.Put(7, 23);
        sut.Get(8);
        sut.Get(12);
        sut.Put(3, 27);
        sut.Put(2, 12);
        sut.Get(5);
        sut.Put(2, 9);
        sut.Put(13, 4);
        sut.Put(8, 18);
        sut.Put(1, 7);
        Assert.That(sut.Get(6), Is.EqualTo(14));
    }

    [Test]
    public void Test_099()
    {
        var sut = new LFUCache(10);
        sut.Put(10, 13);
        sut.Put(3, 17);
        sut.Put(6, 11);
        sut.Put(10, 5);
        sut.Put(9, 10);
        sut.Get(13);
        sut.Put(2, 19);
        sut.Get(2);
        sut.Get(3);
        sut.Put(5, 25);
        sut.Get(8);
        sut.Put(9, 22);
        sut.Put(5, 5);
        sut.Put(1, 30);
        sut.Get(11);
        sut.Put(9, 12);
        sut.Get(7);
        sut.Get(5);
        sut.Get(8);
        sut.Get(9);
        sut.Put(4, 30);
        sut.Put(9, 3);
        sut.Get(9);
        sut.Get(10);
        Assert.That(sut.Head!.Next, Is.EqualTo(sut.Data[1].Frequency));
    }

    [Test]
    public void Test_100()
    {
        var sut = new LFUCache(10);
        sut.Put(10, 13);
        sut.Put(3, 17);
        sut.Put(6, 11);
        sut.Put(10, 5);
        sut.Put(9, 10);
        sut.Get(13);
        sut.Put(2, 19);
        sut.Get(2);
        sut.Get(3);
        sut.Put(5, 25);
        sut.Get(8);
        sut.Put(9, 22);
        sut.Put(5, 5);
        sut.Put(1, 30);
        sut.Get(11);
        sut.Put(9, 12);
        sut.Get(7);
        sut.Get(5);
        sut.Get(8);
        sut.Get(9);
        sut.Put(4, 30);
        sut.Put(9, 3);
        sut.Get(9);
        sut.Get(10);
        sut.Get(10);
        sut.Put(6, 14);
        sut.Put(3, 1);
        sut.Get(3);
        sut.Put(10, 11);
        sut.Get(8);
        sut.Put(2, 14);
        sut.Get(1);
        sut.Get(5);
        sut.Get(4);
        sut.Put(11, 4);
        sut.Put(12, 24);
        sut.Put(5, 18);
        sut.Get(13);
        sut.Put(7, 23);
        sut.Get(8);
        sut.Get(12);
        sut.Put(3, 27);
        sut.Put(2, 12);
        sut.Get(5);
        sut.Put(2, 9);
        sut.Put(13, 4);
        sut.Put(8, 18);
        sut.Put(1, 7);
        Assert.That(sut.Get(6), Is.EqualTo(14));
        sut.Put(9, 29);
        sut.Put(8, 21);
        sut.Get(5);
        sut.Put(6, 30);
        sut.Put(1, 12);
        sut.Get(10);
        sut.Put(4, 15);
        sut.Put(7, 22);
        sut.Put(11, 26);
        sut.Put(8, 17);
        sut.Put(9, 29);
        sut.Get(5);
        sut.Put(3, 4);
        sut.Put(11, 30);
        Assert.That(sut.Get(12), Is.EqualTo(-1));
    }
}