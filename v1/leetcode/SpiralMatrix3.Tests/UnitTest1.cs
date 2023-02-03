namespace SpiralMatrix3.Tests;

public class Solution
{
    public enum Direction
    {
        Left,
        Bottom,
        Right,
        Top,
    }

    public int[][] SpiralMatrixIII(int rows, int cols, int rStart, int cStart)
    {
        var n = rows * cols;

        var answer = new int[n][];
        answer[0] = new int[] { rStart, cStart };
        var allMoves = 1;

        var positionR = rStart;
        var positionC = cStart;

        var moves = 1;
        var direction = Direction.Right;

        bool IsInBounds(int r, int c)
        {
            return
                r >= 0 && r < rows &&
                c >= 0 && c < cols;
        }

        void TryNextMove(int r, int c)
        {
            if (IsInBounds(r, c))
            {
                answer[allMoves] = new int[] { r, c };
                allMoves++;
            }
        }

        while (allMoves < n)
        {
            switch (direction)
            {
                case Direction.Right:
                {
                    for (var m = moves; m > 0; m--)
                    {
                        positionC++;
                        TryNextMove(positionR, positionC);
                    }

                    direction = Direction.Bottom;
                    break;
                }

                case Direction.Bottom:
                {
                    for (var m = moves; m > 0; m--)
                    {
                        positionR++;
                        TryNextMove(positionR, positionC);
                    }

                    moves += 1;
                    direction = Direction.Left;
                    break;
                }

                case Direction.Left:
                {
                    for (var m = moves; m > 0; m--)
                    {
                        positionC--;
                        TryNextMove(positionR, positionC);
                    }

                    direction = Direction.Top;
                    break;
                }

                case Direction.Top:
                {
                    for (var m = moves; m > 0; m--)
                    {
                        positionR--;
                        TryNextMove(positionR, positionC);
                    }

                    moves += 1;
                    direction = Direction.Right;
                    break;
                }
            }
        }

        return answer;
    }
}

public class Tests
{
    [Test]
    public void Test1()
    {
    }
}