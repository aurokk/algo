using NUnit.Framework;

namespace AddTwoNumbers.Tests;

public class Tests
{
    [Test]
    public void Test_0()
    {
        var l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
        var l2 = new ListNode(5, new ListNode(6, new ListNode(4)));

        var expected = new ListNode(7, new ListNode(0, new ListNode(8)));
        var actual = new Solution().AddTwoNumbers_0(l1, l2);

        var n1 = expected;
        var n2 = actual;
        while (n1.next != null)
        {
            if (n2 == null)
            {
                Assert.Fail();
            }

            Assert.AreEqual(n1.val, n2.val);

            n1 = n1.next;
            n2 = n2.next;
        }
    }

    [Test]
    public void Test_1()
    {
        var l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
        var l2 = new ListNode(5, new ListNode(6, new ListNode(4)));

        var expected = new ListNode(7, new ListNode(0, new ListNode(8)));
        var actual = new Solution().AddTwoNumbers_1(l1, l2);

        var n1 = expected;
        var n2 = actual;
        while (n1.next != null)
        {
            if (n2 == null)
            {
                Assert.Fail();
            }

            Assert.AreEqual(n1.val, n2.val);

            n1 = n1.next;
            n2 = n2.next;
        }
    }
}