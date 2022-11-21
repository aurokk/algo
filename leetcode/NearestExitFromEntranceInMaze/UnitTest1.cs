namespace NearestExitFromEntranceInMaze;

public class Solution
{
    public int NearestExit(char[][] maze, int[] entrance)
    {
        bool CanMoveTop(int[] pos)
        {
            return pos[0] > 0 && maze[pos[0] - 1][pos[1]] == '.';
        }

        bool CanMoveRight(int[] pos)
        {
            return pos[1] < maze[0].Length - 1 && maze[pos[0]][pos[1] + 1] == '.';
        }

        bool CanMoveBottom(int[] pos)
        {
            return pos[0] < maze.Length - 1 && maze[pos[0] + 1][pos[1]] == '.';
        }

        bool CanMoveLeft(int[] pos)
        {
            return pos[1] > 0 && maze[pos[0]][pos[1] - 1] == '.';
        }

        bool IsExitFound(int[] pos)
        {
            var isEntrancePoint = pos[0] == entrance[0] && pos[1] == entrance[1];
            var isExit = pos[0] == 0 || pos[1] == 0 || pos[0] == maze.Length - 1 || pos[1] == maze[0].Length - 1;
            return !isEntrancePoint && isExit;
        }

        var queue = new Queue<int[]>();
        queue.Enqueue(entrance);

        var distance = 0;

        while (queue.Any())
        {
            var count = queue.Count();
            for (var i = 0; i < count; i++)
            {
                var pos = queue.Dequeue();

                if (IsExitFound(pos))
                    return distance;

                if (CanMoveTop(pos))
                    queue.Enqueue(new[] { pos[0] - 1, pos[1] });

                if (CanMoveRight(pos))
                    queue.Enqueue(new[] { pos[0], pos[1] + 1 });

                if (CanMoveBottom(pos))
                    queue.Enqueue(new[] { pos[0] + 1, pos[1] });

                if (CanMoveLeft(pos))
                    queue.Enqueue(new[] { pos[0], pos[1] - 1 });

                maze[pos[0]][pos[1]] = '+';
            }

            distance++;
        }

        return -1;
    }
}

public class Tests
{
    [Test]
    public void Test1()
    {
        var maze = new[]
        {
            new[] { '+', '+', '+', '+', '+' },
            new[] { '.', '.', '.', '.', '.' },
            new[] { '+', '+', '+', '.', '.' },
        };
        var entrance = new[] { 1, 2 };
        var expected = 2;
        var actual = new Solution().NearestExit(maze, entrance);
        Assert.AreEqual(expected, actual);
    }
}