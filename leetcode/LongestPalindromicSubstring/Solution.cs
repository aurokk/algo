namespace LongestPalindromicSubstring;

public class Solution
{
    public string LongestPalindrome_000(string s)
    {
        if (s.Length < 2)
            return s;

        var dp = new bool[s.Length][];
        for (var i = 0; i < s.Length; i++)
            dp[i] = new bool[s.Length];

        // Решаю через динамику, двумерный массив, end — конец строки, start — начало строки,
        // в ячейке таблицы храним true, если строка dp[end][start] — палиндром, иначе false
        // Это позволит сократить время вычисления от решения в лоб с O(N^3) -> O(N^2)
        // 
        // Какие проверки нужно сделать на каждом шаге:
        // - Если s[end] == s[start]
        // - - Если end == start, ставим dp[end][start] = true, это как раз диагональ матрицы,
        //     строки длины 1 все палиндромы по-умолчанию
        //   - Вычисляем длину строки end - start + 1, end и start у нас индексы включительные, поэтому надо сделать +1
        //   - Если длина == 2, то это палиндром, пример случая abbc, start=1, end=2
        //   - Если dp[end - 1][start + 1], то это палиндром, например, start=1, end=3 k[a[c]a]a, dp[2][2] = true,
        //     значит, если к строке dp[2][2] добавить одинавковый символ слева и справа, получим палиндром длинее на 2
        //
        // Ниже несколько примеров заполнения матрицы

        // kacaa
        //   0 1 2 3 4
        // 0 + . . . .
        // 1 - + . . .
        // 2 - - + . .
        // 3 - + - + .
        // 4 - - - + +

        // aa
        //   0 1
        // 0 + .
        // 1 + +

        // aaa
        //   0 1 2
        // 0 + . .
        // 1 + + .
        // 2 + + +

        // aba
        //   0 1 2
        // 0 + . .
        // 1 - + .
        // 2 + - +

        // abba
        //   0 1 2 3
        // 0 + . . .
        // 1 - + . .
        // 2 - + + .
        // 3 + . . +

        // acbb
        //   0 1 2 3
        // 0 + . . .
        // 1 - + . .
        // 2 - - + .
        // 3 - - + +

        var maxStart = 0;
        var maxLength = 1;
        for (var end = 0; end < s.Length; end++)
        for (var start = 0; start < end + 1; start++)
        {
            if (s[start] == s[end])
            {
                if (start == end)
                {
                    dp[end][start] = true;
                    break;
                }

                var length = end - start + 1;
                if (length == 2 || dp[end - 1][start + 1])
                {
                    dp[end][start] = true;
                    if (length > maxLength)
                    {
                        maxLength = length;
                        maxStart = start;
                    }

                    continue;
                }
            }
        }

        // DEBUG
        // for (var end = 0; end < s.Length; end++)
        // {
        //     for (var start = 0; start < s.Length; start++)
        //     {
        //         Console.Write(dp[end][start] ? "+" : "-");
        //     }
        //
        //     Console.WriteLine();
        // }

        return s.Substring(maxStart, maxLength);
    }
}