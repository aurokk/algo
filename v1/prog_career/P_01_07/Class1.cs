namespace P_01_07;

public class Class1
{
    // 0 0 0
    // 1 1 1
    // 2 2 2
    // =>
    // 2 1 0
    // 2 1 0
    // 2 1 0

    // 0 0 0 0
    // 1 1 1 1
    // 2 2 2 2
    // 3 3 3 3
    // =>
    // 3 2 1 0
    // 3 2 1 0
    // 3 2 1 0
    // 3 2 1 0

    public int[][] Rotate_000(int[][] input)
    {
        for (var layer = 0; layer < input.Length / 2; layer++)
        {
            var last = input.Length - 1 - layer;
            for (var i = layer; i < last; i++)
            {
                var offset = i - layer;
                var ni = last - offset;

                var top = input[layer][i];

                // top = left
                input[layer][i] = input[ni][layer];

                // left = bottom
                input[ni][layer] = input[last][ni];

                // bottom = right
                input[last][ni] = input[i][last];

                // right = top
                input[i][last] = top;
            }
        }

        return input;
    }

    // Тоже самое просто написал ещё раз, чтобы потренероваться
    public int[][] Rotate_001(int[][] input)
    {
        for (var layer = 0; layer < input.Length / 2; layer++)
        {
            var last = input.Length - 1 - layer;
            for (var i = layer; i < last; i++)
            {
                var ni = last - (i - layer);

                var top = input[layer][i];

                // top = left
                input[layer][i] = input[ni][layer];

                // left = bottom
                input[ni][layer] = input[last][ni];

                // bottom = right
                input[last][ni] = input[i][last];

                // right = top
                input[i][last] = top;
            }
        }

        return input;
    }
}