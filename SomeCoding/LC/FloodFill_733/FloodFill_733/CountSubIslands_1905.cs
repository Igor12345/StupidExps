namespace FloodFill_733;

public class CountSubIslands_1905
{
    private readonly int _land = 1;
    private Queue<(int, int)> _queue = null!;
    private int[][] _grid1 = null!;
    
    public int CountSubIslands(int[][] grid1, int[][] grid2)
    {
        _grid1 = grid1;
        int result = 0;

        for (int i = 0; i < grid2.Length; i++)
        {
            for (int j = 0; j < grid2[i].Length; j++)
            {
                if (grid2[i][j] == _land)
                {
                    if (MarkIsland(grid2, i, j))
                        result++;
                }
            }
        }

        return result;
    }

    private bool MarkIsland(int[][] grid, int i, int j)
    {
        bool isSubIsland = true;
        _queue = new();
        _queue.Enqueue((i, j));
        isSubIsland = isSubIsland && _grid1[i][j] == _land;
        grid[i][j] = -1;

        while (_queue.Count > 0)
        {
            var point = _queue.Dequeue();
            isSubIsland = isSubIsland && _grid1[point.Item1][point.Item2] == _land;
            StepUp(grid, point);
            StepDown(grid, point);
            StepRight(grid, point);
            StepLeft(grid, point);
        }

        return isSubIsland;
    }

    private void StepRight(int[][] image, (int, int) point)
    {
        if (point.Item2 < image[point.Item1].Length - 1 && image[point.Item1][point.Item2 + 1] == _land)
        {
            _queue.Enqueue((point.Item1, point.Item2 + 1));
            image[point.Item1][point.Item2 + 1] = -1;
        }
    }

    private void StepLeft(int[][] image, (int, int) point)
    {
        if (point.Item2 > 0 && image[point.Item1][point.Item2 - 1] == _land)
        {
            _queue.Enqueue((point.Item1, point.Item2 - 1));
            image[point.Item1][point.Item2 - 1] = -1;
        }
    }

    private void StepDown(int[][] image, (int, int) point)
    {
        if (point.Item1 < image.Length - 1 && image[point.Item1 + 1][point.Item2] == _land)
        {
            _queue.Enqueue((point.Item1 + 1, point.Item2));
            image[point.Item1 + 1][point.Item2] = -1;
        }
    }

    private void StepUp(int[][] image, (int, int) point)
    {
        if (point.Item1 > 0 && image[point.Item1 - 1][point.Item2] == _land)
        {
            _queue.Enqueue((point.Item1 - 1, point.Item2));
            image[point.Item1 - 1][point.Item2] = -1;
        }
    }
}