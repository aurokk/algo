namespace PalindromeLinkedList;

public class Solution
{
    //     1 -> 2 -> 2 -> 1 ->
    // r  fs
    //
    //  <- 1    2 -> 2 -> 1 ->
    //     r    s    f
    //
    //  <- 1 <- 2    2 -> 1 ->
    //          r    s         f
    public bool IsPalindrome(ListNode head)
    {
        ListNode slow = head;
        ListNode fast = head;
        ListNode reverse = null;

        while (fast != null && fast.next != null)
        {
            fast = fast.next.next;
            var prevSlow = slow;
            slow = slow.next;
            prevSlow.next = reverse;
            reverse = prevSlow;
        }

        if (fast != null)
        {
            slow = slow.next;
        }

        while (slow != null && reverse != null)
        {
            if (reverse.val != slow.val)
            {
                return false;
            }

            reverse = reverse.next;
            slow = slow.next;
        }

        return true;
    }
}