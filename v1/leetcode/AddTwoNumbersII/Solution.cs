using System.Collections;

namespace AddTwoNumbersII;

public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        if (l1 == null)
            return l2;
        if (l2 == null)
            return l1;

        // lengths
        var len1 = 0;
        var p1 = l1;
        while (p1 != null)
        {
            len1++;
            p1 = p1.next;
        }

        var len2 = 0;
        var p2 = l2;
        while (p2 != null)
        {
            len2++;
            p2 = p2.next;
        }

        var maxLen = len1 > len2 ? len1 : len2;

        // pairs
        var stack = new Stack<(int, int)>();
        var offset1 = maxLen - len1;
        var offset2 = maxLen - len2;
        p1 = l1;
        p2 = l2;
        for (var i = 0; i < maxLen; i++)
        {
            var n1 = 0;
            if (offset1 <= i)
            {
                n1 = p1.val;
                p1 = p1.next;
            }

            var n2 = 0;
            if (offset2 <= i)
            {
                n2 = p2.val;
                p2 = p2.next;
            }

            stack.Push((n1, n2));
        }


        // sum
        var result = new Stack<int>();
        var add = 0;
        foreach (var pair in stack)
        {
            var sum = pair.Item1 + pair.Item2 + add;
            add = 0;

            result.Push(sum % 10);
            if (sum > 9)
            {
                add = 1;
            }
        }

        if (add != 0)
        {
            result.Push(1);
        }

        // output
        var head = (ListNode)null;
        var curr = (ListNode)null;
        foreach (var el in result)
        {
            if (curr == null)
            {
                head = curr = new ListNode(el);
            }
            else
            {
                curr.next = new ListNode(el);
                curr = curr.next;
            }
        }

        return head;
    }
}