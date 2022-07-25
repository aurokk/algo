using System.Collections;

namespace P_03_05;

public class Solution
{
    public Stack<int> Sort(Stack<int> input)
    {
        var sorted = new Stack<int>();

        while (input.Any())
        {
            var temp = input.Pop();

            while (sorted.Any() && sorted.Peek() < temp)
            {
                input.Push(sorted.Pop());
            }
            
            sorted.Push(temp);
        }

        return sorted;
    }
}