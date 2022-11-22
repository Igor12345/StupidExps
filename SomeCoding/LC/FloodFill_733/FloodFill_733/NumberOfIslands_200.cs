namespace FloodFill_733;

public class NumberOfIslands_200
{
    public int NumIslands(char[][] grid)
    {
        int result = 0;
        
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == '1')
                {
                    MarkIsland(grid, i, j);
                    result++;
                }
            }
        }

        return result;
    }
    
    private Queue<(int, int)> _queue = new Queue<(int, int)>();

    private void MarkIsland(char[][] grid, int i, int j)
    {
        _queue = new Queue<(int, int)>();
        _queue.Enqueue((i, j));
        grid[i][j] = '*';
        
        while (_queue.Count > 0)
        {
            var point = _queue.Dequeue();
            StepUp(grid, point);
            StepDown(grid, point);
            StepRight(grid, point);
            StepLeft(grid, point);
        }
    }
    
    private void StepRight(char[][] image, (int, int) point)
    {
        if (point.Item2 < image[point.Item1].Length-1 && image[point.Item1][point.Item2 + 1] == '1')
        {
            _queue.Enqueue((point.Item1, point.Item2 + 1));
            image[point.Item1][point.Item2 + 1] = '*';
        }
    }

    private void StepLeft(char[][] image, (int, int) point)
    {
        if (point.Item2 > 0 && image[point.Item1][point.Item2 - 1] == '1')
        {
            _queue.Enqueue((point.Item1, point.Item2 - 1));
            image[point.Item1][point.Item2 - 1] = '*';
        }
    }

    private void StepDown(char[][] image, (int, int) point)
    {
        if (point.Item1 < image.Length-1 && image[point.Item1 + 1][point.Item2] == '1')
        {
            _queue.Enqueue((point.Item1 + 1, point.Item2));
            image[point.Item1 + 1][point.Item2] = '*';
        }
    }

    private void StepUp(char[][] image, (int, int) point)
    {
        if (point.Item1 > 0 && image[point.Item1 - 1][point.Item2] == '1')
        {
            _queue.Enqueue((point.Item1 - 1, point.Item2));
            image[point.Item1 - 1][point.Item2] = '*';
        }
    }
}