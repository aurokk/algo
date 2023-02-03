namespace P_03_04;

public class MyQueue<T>
{
    private readonly Stack<T> _stack1;
    private readonly Stack<T> _stack2;

    public MyQueue()
    {
        _stack1 = new Stack<T>();
        _stack2 = new Stack<T>();
    }

    public int Size() =>
        _stack1.Count + _stack2.Count;

    public void Add(T value) => 
        _stack1.Push(value);

    public T Peek()
    {
        Swap();
        return _stack2.Peek();
    }

    public T Remove()
    {
        Swap();
        return _stack2.Pop();
    }

    private void Swap()
    {
        if (_stack2.Any()) return;
        while (_stack1.TryPop(out var value))
            _stack2.Push(value);
    }
}