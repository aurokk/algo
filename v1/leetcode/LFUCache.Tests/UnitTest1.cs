namespace LFUCache.Tests;

#nullable disable

public class ValueNode
{
    public int Key { get; set; }
    public int Value { get; set; }
    public MetaNode Meta { get; set; }
}

public class MetaNode
{
    public int Count { get; set; }
    public MetaNode Prev { get; set; }
    public MetaNode Next { get; set; }

    public ValueNode Value { get; set; }
}

public class LFUCache
{
    private readonly Dictionary<int, ValueNode> _values;
    private readonly Dictionary<int, MetaNode> _metas;
    private ValueNode _head;

    private readonly int _capacity;
    private int _size;

    public LFUCache(int capacity)
    {
        _capacity = capacity;
        _values = new();
        _metas = new();
    }

    public int Get(int key)
    {
        if (_values.ContainsKey(key))
        {
            UpdateCount(key);
            return _values[key].Value;
        }

        return -1;
    }

    private void UpdateCount(int key)
    {
        var valueNode = _values[key];
        var metaNode = valueNode.Meta;

        var countMetaNode = _metas[metaNode.Count];

        metaNode.Count += 1;

        if (countMetaNode != metaNode && countMetaNode.Next == null)
        {
            metaNode.Prev = countMetaNode;
            metaNode.Next = null;
            countMetaNode.Next = metaNode;
            _metas[metaNode.Count] = metaNode;
            return;
        }

        if (_metas.ContainsKey(metaNode.Count))
        {
            var newCountMetaNode = _metas[metaNode.Count];
            metaNode.Next = newCountMetaNode.Next;
            metaNode.Prev = newCountMetaNode;
            newCountMetaNode.Next = metaNode;
            _metas[metaNode.Count] = metaNode;
            return;
        }

        _metas[metaNode.Count] = metaNode;
        return;
    }

    public void Put(int key, int value)
    {
        if (_capacity == 0)
        {
            return;
        }

        if (_values.ContainsKey(key))
        {
            UpdateCount(key);
            _values[key].Value = value;
            return;
        }

        if (_size == _capacity)
        {
            var headValueNode = _head;
            var headMetaNode = _metas[_head.Meta.Count];

            var metaNode = new MetaNode { Count = 1, Prev = null, Next = headMetaNode.Next, };
            var valueNode = new ValueNode { Key = key, Value = value, Meta = metaNode, };
            metaNode.Value = valueNode;

            _values.Remove(headValueNode.Key);

            _values[key] = valueNode;
            if (metaNode.Next != null)
            {
                metaNode.Next.Prev = metaNode;
            }

            _head = valueNode;
            _metas[metaNode.Count] = metaNode;

            return;
        }

        {
            var metaNode = new MetaNode { Count = 1, Prev = null, Next = null, };
            var valueNode = new ValueNode { Key = key, Value = value, Meta = metaNode, };
            metaNode.Value = valueNode;
            _values[key] = valueNode;
            _size++;

            if (_metas.ContainsKey(metaNode.Count))
            {
                var oldMetaNode = _metas[metaNode.Count];
                _metas[metaNode.Count] = metaNode;
                metaNode.Next = oldMetaNode.Next;
                metaNode.Prev = oldMetaNode;
                oldMetaNode.Next = metaNode;
                return;
            }

            if (_head != null)
            {
                var headMetaNode = _metas[_head.Meta.Count];
                _metas[metaNode.Count] = metaNode;
                metaNode.Next = headMetaNode;
                metaNode.Prev = null;
                headMetaNode.Prev = metaNode;
                _head = valueNode;
                return;
            }

            _metas[metaNode.Count] = metaNode;
            _head = valueNode;
            return;
        }
    }
}

public class Tests
{
    // ["LFUCache","put","put","get","put","get"]
    // [[2],[1,1],[2,2],[1],[3,3],[2]]
    [Test]
    public void Test1()
    {
        var lfu = new LFUCache(2);
        lfu.Put(1, 1);
        lfu.Put(2, 2);
        Assert.That(lfu.Get(1), Is.EqualTo(1));
        lfu.Put(3, 3);
        Assert.That(lfu.Get(2), Is.EqualTo(-1));
    }
}