namespace LRUCache.Tests;

public class Node {
    public Node Prev;
    public Node Next;
    public int Key;
}

public class LRUCache 
{
    private readonly int _capacity;
    private readonly Dictionary<int, int> _data;
    private readonly Dictionary<int, Node> _order;
    private Node _head;
    private Node _tail;
    private int _count;
    
    public LRUCache(int capacity) 
    {
        _capacity = capacity;
        _data = new Dictionary<int, int>();
        _order = new Dictionary<int, Node>();
        _count = 0;
        
        _head = new Node();
        _tail = new Node();
        _head.Next = _tail;
        _tail.Prev = _head;
    }
    
    public int Get(int key) 
    {
        if (!_data.ContainsKey(key)) { return -1; }
        UpdateTail(key);
        return _data[key];
    }
    
    public void Put(int key, int value) 
    {
        if (_data.ContainsKey(key)) 
        {
            // update
            _data[key] = value;
            UpdateTail(key);
        }
        else if (_count == _capacity) 
        {
            // evict && add
            _data.Remove(_tail.Next.Key);
            _order.Remove(_tail.Next.Key);
            _data[key] = value;
            var node = new Node { Next = _tail, Prev = _tail.Prev, Key = key, };
            _tail.Prev.Next = node;
            _tail.Prev = node;
            _order[key] = node;
        }
        else 
        {
            // add
            _data[key] = value;
            var node = new Node { Next = _tail, Prev = _tail.Prev, Key = key, };
            _tail.Prev.Next = node;
            _tail.Prev = node;
            _order[key] = node;
            _count++;
        }
    }
    
    private void UpdateTail(int key) 
    {
        if (_head.Key == key) { return; }
        var node = _order[key];
        node.Next.Prev = node.Prev;
        node.Prev.Next = node.Next;
        node.Next = _tail;
        node.Prev = _tail.Prev;
        _tail.Prev.Next = node;
        _tail.Prev = node;
    }
}

public class Tests
{
    [Test]
    public void Test1()
    {
        var sut = new LRUCache(2);
        sut.Put(1, 1);
        sut.Put(2, 2);
        sut.Get(1);
        sut.Put(3, 3);
        sut.Get(2);
    }
}