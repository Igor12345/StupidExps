namespace FloodFill_733;

public class MaxAreaOfIsland_695
{
    public int MaxAreaOfIsland(int[][] grid) {
        
        int result = 0;

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 1)
                {
                    int size = MarkIsland(grid, i, j);
                    if (size > result)
                    {
                        result = size;
                    }
                }
            }
        }

        return result;
    }
    private Queue<(int, int)> _queue = new Queue<(int, int)>();

    private int MarkIsland(int[][] grid, int i, int j)
    {
        int size = 0;
        _queue = new Queue<(int, int)>();
        _queue.Enqueue((i, j));
        grid[i][j] = -1;
        
        while (_queue.Count > 0)
        {
            var point = _queue.Dequeue();
            size++;
            StepUp(grid, point);
            StepDown(grid, point);
            StepRight(grid, point);
            StepLeft(grid, point);
        }

        return size;
    }
    
    private void StepRight(int[][] image, (int, int) point)
    {
        if (point.Item2 < image[point.Item1].Length-1 && image[point.Item1][point.Item2 + 1] == 1)
        {
            _queue.Enqueue((point.Item1, point.Item2 + 1));
            image[point.Item1][point.Item2 + 1] = -1;
        }
    }

    private void StepLeft(int[][] image, (int, int) point)
    {
        if (point.Item2 > 0 && image[point.Item1][point.Item2 - 1] == 1)
        {
            _queue.Enqueue((point.Item1, point.Item2 - 1));
            image[point.Item1][point.Item2 - 1] = -1;
        }
    }

    private void StepDown(int[][] image, (int, int) point)
    {
        if (point.Item1 < image.Length-1 && image[point.Item1 + 1][point.Item2] == 1)
        {
            _queue.Enqueue((point.Item1 + 1, point.Item2));
            image[point.Item1 + 1][point.Item2] = -1;
        }
    }

    private void StepUp(int[][] image, (int, int) point)
    {
        if (point.Item1 > 0 && image[point.Item1 - 1][point.Item2] == 1)
        {
            _queue.Enqueue((point.Item1 - 1, point.Item2));
            image[point.Item1 - 1][point.Item2] = -1;
        }
    }
}
