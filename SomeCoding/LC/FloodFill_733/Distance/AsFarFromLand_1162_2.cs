using System.Diagnostics;

namespace Distance;

public class AsFarFromLand_1162_2
{
    private readonly int _land = 1;
    private readonly int _water = 0;
    private int _step = 0;
    private bool _canContinue;

    public int MaxDistance(int[][] grid)
    {
        int sum = grid.Sum(t => t.Sum());

        if (sum == 0 || sum == grid.Length * grid[0].Length)
            return -1;

        do
        {
            _step++;
            _canContinue = false;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == _step)
                    {
                        MarkAround(grid, i, j);
                    }
                }
            }
        } while (_canContinue);

        return _step - 1;
    }

    private void MarkAround(int[][] grid, int i, int j)
    {
        if (i > 0 && grid[i - 1][j] == _water)
        {
            grid[i - 1][j] = _step + 1;
            _canContinue = true;
        }

        if (i < grid.Length - 1 && grid[i + 1][j] == _water)
        {
            grid[i + 1][j] = _step + 1;
            _canContinue = true;
        }

        if (j > 0 && grid[i][j - 1] == _water)
        {
            grid[i][j - 1] = _step + 1;
            _canContinue = true;
        }

        if (j < grid[0].Length - 1 && grid[i][j + 1] == _water)
        {
            grid[i][j + 1] = _step + 1;
            _canContinue = true;
        }
    }
}