namespace FloodFill_733;

public class NumberOfClosedIslands_1254
{
    public int ClosedIsland(int[][] grid)
    {
        int result = 0;
        if (grid.Length < 2)
            return 0;
        if (grid[0].Length < 2)
            return 0;

        for (int i = 0; i < grid.Length; i++)
        {
            if (grid[i][0] == 0)
            {
                MarkIsland(grid, i, 0);
            }

            int lastI = grid[i].Length - 1;
            if (grid[i][lastI] == 0)
            {
                MarkIsland(grid, i, lastI);
            }
        }

        for (int j = 0; j < grid[0].Length; j++)
        {
            if (grid[0][j] == 0)
            {
                MarkIsland(grid, 0, j);
            }
        }

        int last = grid.Length - 1;
        for (int j = 0; j < grid[last].Length; j++)
        {
            if (grid[last][j] == 0)
            {
                MarkIsland(grid, last, j);
            }
        }

        for (int i = 1; i < grid.Length - 1; i++)
        {
            for (int j = 1; j < grid[i].Length - 1; j++)
            {
                if (grid[i][j] == 0)
                {
                    MarkIsland(grid, i, j);
                    result++;
                }
            }
        }

        return result;
    }

    private Queue<(int, int)> _queue = new Queue<(int, int)>();

    private void MarkIsland(int[][] grid, int i, int j)
    {
        _queue = new Queue<(int, int)>();
        _queue.Enqueue((i, j));
        grid[i][j] = -1;

        while (_queue.Count > 0)
        {
            var point = _queue.Dequeue();
            StepUp(grid, point);
            StepDown(grid, point);
            StepRight(grid, point);
            StepLeft(grid, point);
        }
    }

    private void StepRight(int[][] image, (int, int) point)
    {
        if (point.Item2 < image[point.Item1].Length - 1 && image[point.Item1][point.Item2 + 1] == 0)
        {
            _queue.Enqueue((point.Item1, point.Item2 + 1));
            image[point.Item1][point.Item2 + 1] = -1;
        }
    }

    private void StepLeft(int[][] image, (int, int) point)
    {
        if (point.Item2 > 0 && image[point.Item1][point.Item2 - 1] == 0)
        {
            _queue.Enqueue((point.Item1, point.Item2 - 1));
            image[point.Item1][point.Item2 - 1] = -1;
        }
    }

    private void StepDown(int[][] image, (int, int) point)
    {
        if (point.Item1 < image.Length - 1 && image[point.Item1 + 1][point.Item2] == 0)
        {
            _queue.Enqueue((point.Item1 + 1, point.Item2));
            image[point.Item1 + 1][point.Item2] = -1;
        }
    }

    private void StepUp(int[][] image, (int, int) point)
    {
        if (point.Item1 > 0 && image[point.Item1 - 1][point.Item2] == 0)
        {
            _queue.Enqueue((point.Item1 - 1, point.Item2));
            image[point.Item1 - 1][point.Item2] = -1;
        }
    }
}