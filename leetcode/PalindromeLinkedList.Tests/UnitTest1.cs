namespace PalindromeLinkedList.Tests;

public class Tests
{
    [Test]
    public void Test1()
    {
        var l1 = new ListNode(1, new ListNode(2, new ListNode(2, new ListNode(1))));
        var actual = new Solution().IsPalindrome(l1);
        Assert.That(actual, Is.True);
    }

    [Test]
    public void Test2()
    {
        var l1 = new ListNode(1, new ListNode(2, new ListNode(2, new ListNode(2, new ListNode(1)))));
        var actual = new Solution().IsPalindrome(l1);
        Assert.That(actual, Is.True);
    }

    [Test]
    public void Test3()
    {
        var l1 = new ListNode(3, new ListNode(2, new ListNode(2, new ListNode(2, new ListNode(1)))));
        var actual = new Solution().IsPalindrome(l1);
        Assert.That(actual, Is.False);
    }
}