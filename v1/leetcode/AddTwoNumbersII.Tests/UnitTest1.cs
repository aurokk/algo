namespace AddTwoNumbersII.Tests;

public class Tests
{
    [Test]
    public void Test1()
    {
        var a = new ListNode(7, new ListNode(2, new ListNode(4, new ListNode(3))));
        var b = new ListNode(5, new ListNode(6, new ListNode(4)));
        var expected = new ListNode(7, new ListNode(8, new ListNode(0, new ListNode(7))));
        var actual = new Solution().AddTwoNumbers(a, b);

        var n1 = expected;
        var n2 = actual;
        while (n1.next != null)
        {
            if (n2 == null)
            {
                Assert.Fail();
            }

            Assert.That(n2.val, Is.EqualTo(n1.val));

            n1 = n1.next;
            n2 = n2.next;
        }
    }
}