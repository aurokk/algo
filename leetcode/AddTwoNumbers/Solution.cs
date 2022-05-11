namespace AddTwoNumbers;

public class Solution
{
    // time O(max(l1, l2))
    // memory O(max(l1, l2))
    public ListNode AddTwoNumbers_0(ListNode l1, ListNode l2)
    {
        var result = new ListNode();

        var shouldAddOne = false;
        var lp1 = l1;
        var lp2 = l2;
        var r = result;

        while (true)
        {
            var v1 = lp1 != null ? lp1.val : 0;
            var v2 = lp2 != null ? lp2.val : 0;
            var v3 = shouldAddOne ? 1 : 0;
            var digit = v1 + v2 + v3;
            if (digit > 9)
            {
                digit %= 10;
                shouldAddOne = true;
            }
            else
            {
                shouldAddOne = false;
            }

            r.val = digit;

            lp1 = lp1 != null ? lp1.next : null;
            lp2 = lp2 != null ? lp2.next : null;

            if (lp1 == null && lp2 == null && !shouldAddOne)
            {
                break;
            }
            else
            {
                r.next = new ListNode();
                r = r.next;
            }
        }

        return result;
    }

    // time O(max(l1, l2))
    // memory O(max(l1, l2))
    public ListNode AddTwoNumbers_1(ListNode l1, ListNode l2)
    {
        var result = new ListNode();

        var shouldAddOne = false;
        var lp1 = l1;
        var lp2 = l2;
        var curr = result;

        while (lp1 != null || lp2 != null)
        {
            var v1 = lp1 != null ? lp1.val : 0;
            var v2 = lp2 != null ? lp2.val : 0;
            var v3 = shouldAddOne ? 1 : 0;
            var sum = v1 + v2 + v3;

            curr.next = new ListNode(sum % 10);
            curr = curr.next;

            shouldAddOne = sum > 9;
            lp1 = lp1 != null ? lp1.next : null;
            lp2 = lp2 != null ? lp2.next : null;
        }

        if (shouldAddOne)
        {
            curr.next = new ListNode(1);
        }

        return result.next;
    }
}