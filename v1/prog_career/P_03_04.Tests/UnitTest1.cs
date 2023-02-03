namespace P_03_04.Tests;

public class Tests
{
    [Test]
    public void Test_000()
    {
        var items = new[] { 0, 1, 2, 3, 4, };

        var myQueue = new MyQueue<int>();

        foreach (var item in items) 
            myQueue.Add(item);

        foreach (var item in items)
        {
            var peek =  myQueue.Peek();
            Assert.That(peek, Is.EqualTo(item));
            var remove = myQueue.Remove();
            Assert.That(remove, Is.EqualTo(item));
        }
    }
}