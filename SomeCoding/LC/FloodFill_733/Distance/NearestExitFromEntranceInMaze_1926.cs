namespace Distance;

public class NearestExitFromEntranceInMaze_1926
{
    private Queue<((int, int), int)> _queue = new();
    public int NearestExit(char[][] maze, int[] entrance) {
        int step = 1;
        _queue.Enqueue(((entrance[0], entrance[1]), step));
        maze[entrance[0]][entrance[1]] = '*';
        while (_queue.Any())
        {
            var position = _queue.Dequeue();
            foreach (var next in NextLocations(maze, position))
            {
                if (Exit(next.Item1, maze.Length, maze[0].Length))
                {
                    return next.Item2;
                }

                _queue.Enqueue(((next.Item1), next.Item2 + 1));
            }
        }

        return -1;
    }

    private bool Exit((int, int) location, int lengthX, int lengthY)
    {
        return location.Item1 == 0 || location.Item1 == lengthX - 1 || location.Item2 == 0 || location.Item2 == lengthY - 1;
    }

    private IEnumerable<((int, int), int)> NextLocations(char[][] maze, ((int, int), int) position)
    {
        if (position.Item1.Item1 > 0 && maze[position.Item1.Item1 - 1][position.Item1.Item2] == '.')
        {
            maze[position.Item1.Item1 - 1][position.Item1.Item2] = '*';
            yield return ((position.Item1.Item1 - 1, position.Item1.Item2), position.Item2);
        }

        if (position.Item1.Item1 < maze.Length - 1 && maze[position.Item1.Item1 + 1][position.Item1.Item2] == '.')
        {
            maze[position.Item1.Item1 + 1][position.Item1.Item2] = '*';
            yield return ((position.Item1.Item1 + 1, position.Item1.Item2), position.Item2);
        }

        if (position.Item1.Item2 > 0 && maze[position.Item1.Item1][position.Item1.Item2 - 1] == '.')
        {
            maze[position.Item1.Item1][position.Item1.Item2 - 1] = '*';
            yield return ((position.Item1.Item1, position.Item1.Item2 - 1), position.Item2);
        }

        if (position.Item1.Item2 < maze[0].Length - 1 && maze[position.Item1.Item1][position.Item1.Item2 + 1] == '.')
        {
            maze[position.Item1.Item1][position.Item1.Item2 + 1] = '*';
            yield return ((position.Item1.Item1, position.Item1.Item2 + 1), position.Item2);
        }
    }

}