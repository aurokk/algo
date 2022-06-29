namespace LinkedListCycle.Tests;

public class Tests
{
    [Test]
    public void Test1()
    {
        var node4 = new ListNode(-4);
        var node3 = new ListNode(0);
        var node2 = new ListNode(2);
        var node1 = new ListNode(3);

        node1.next = node2;
        node2.next = node3;
        node3.next = node4;
        node4.next = node2;

        var actual = new Solution().HasCycle(node1);

        Assert.That(actual, Is.True);
    }

    [Test]
    public void Test2()
    {
        var node1 = new ListNode(3);

        var actual = new Solution().HasCycle(node1);

        Assert.That(actual, Is.False);
    }
}