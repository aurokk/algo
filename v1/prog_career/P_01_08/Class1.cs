namespace P_01_08;

public class Class1
{
    public int[][] NullifyRowsAndColumns(int[][] input)
    {
        if (input.Length == 0 || input[0].Length == 0)
        {
            return input;
        }

        var rows = new bool[input.Length];
        var cols = new bool[input[0].Length];

        for (var i = 0; i < input.Length; i++)
        for (var j = 0; j < input[i].Length; j++)
        {
            if (input[i][j] == 0)
            {
                rows[i] = true;
                cols[j] = true;
            }
        }

        for (var i = 0; i < input.Length; i++)
        for (var j = 0; j < input[i].Length; j++)
        {
            if (rows[i] || cols[j])
            {
                input[i][j] = 0;
            }
        }

        return input;
    }
}