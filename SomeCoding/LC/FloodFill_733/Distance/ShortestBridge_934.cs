namespace Distance;

public class ShortestBridge_934
{
    private bool _continue = true;
    private Queue<(int, int)> _queue = new();

    public int ShortestBridge(int[][] grid)
    {
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 1)
                {
                    MarkFirstIsland(grid, i, j);
                    goto second;
                }
            }
        }
        second:

        int step = -1;
        while (_continue)
        {
            _continue = false;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    int res = BuildBridge(grid, i, j, step);
                    if (res < 0)
                    {
                        return res * -1;
                    }
                }
            }

            step -= 1;
        }
        return -1;
    }
    private int BuildBridge(int[][] grid, int i, int j, int step)
    {
        if (i > 0 && grid[i][j] == step )
        {
            if (grid[i - 1][j] == 1)
            {
                return step;
            }

            if (grid[i - 1][j] == 0)
            {
                grid[i - 1][j] = step - 1;
                _continue = true;
            }
        }

        if (i < grid.Length - 1 && grid[i][j] == step )
        {
            if (grid[i + 1][j] == 1)
                return step;
            if (grid[i + 1][j] == 0)
            {
                grid[i + 1][j] = step - 1;
                _continue = true;
            }
        }

        if (j > 0 && grid[i][j] == step)
        {
            if (grid[i][j - 1] == 1)
                return step;
            if ( grid[i][j - 1] == 0)
            {
                grid[i][j - 1] = step - 1;
                _continue = true;
            }
        }

        if (j < grid[i].Length - 1 && grid[i][j] == step )
        {
            if (grid[i][j + 1] == 1)
                return step;
            if (grid[i][j + 1] == 0)
            {
                grid[i][j + 1] = step - 1;
                _continue = true;
            }
        }

        return 1;
    }

    private void MarkFirstIsland(int[][] grid, int i1, int j1)
    {
        _queue.Enqueue((i1, j1));
        while (_queue.Any())
        {
            var (i, j) = _queue.Dequeue();
            grid[i][j] = -1;
            if (i > 0 && grid[i - 1][j] == 1)
            {
                grid[i - 1][j] = -1;
                _queue.Enqueue((i - 1, j));
            }

            if (i < grid.Length - 1 && grid[i + 1][j] == 1)
            {
                grid[i + 1][j] = -1;
                _queue.Enqueue((i + 1, j));
            }

            if (j > 0 && grid[i][j - 1] == 1)
            {
                grid[i][j - 1] = -1;
                _queue.Enqueue((i, j - 1));
            }

            if (j < grid[i].Length - 1 && grid[i][j + 1] == 1)
            {
                grid[i][j + 1] = -1;
                _queue.Enqueue((i, j + 1));
            }
        }
    }
}