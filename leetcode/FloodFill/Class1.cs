namespace FloodFill;

public class Solution
{
    public int[][] FloodFill(int[][] image, int sr, int sc, int color)
    {
        var prevColor = image[sr][sc];

        if (prevColor == color)
        {
            return image;
        }

        var queue = new Queue<(int, int)>();
        queue.Enqueue((sr, sc));
        while (queue.Any())
        {
            var (er, ec) = queue.Dequeue();

            if (image[er][ec] != prevColor)
            {
                continue;
            }

            image[er][ec] = color;

            if (er > 0)
            {
                queue.Enqueue((er - 1, ec));
            } // top

            if (ec > 0)
            {
                queue.Enqueue((er, ec - 1));
            } // left

            if (er < image.Length - 1)
            {
                queue.Enqueue((er + 1, ec));
            } // bottom

            if (ec < image[0].Length - 1)
            {
                queue.Enqueue((er, ec + 1));
            } // right
        }

        return image;
    }
}