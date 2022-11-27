using System.Collections;

namespace Distance;

public class ShortestPathInBinaryMatrix_1091
{
    private bool _canContinue = true;
    private readonly Queue<((int, int), int)> _nextSteps = new();
    private int[][] _grid;
    private int[][] _paths;

    public int ShortestPathBinaryMatrix(int[][] grid)
    {
        _grid = grid;
        if (grid[0][0] != 0 || grid[^1][^1] != 0)
            return -1;
        
        _paths = new int[grid.Length][];
        for (int i = 0; i < grid.Length; i++)
        {
            _paths[i] = Enumerable.Repeat(-1, grid[0].Length).ToArray();
        }
        
        _nextSteps.Enqueue(((0, 0), 1));
        _paths[0][0] = 1;
        while (_nextSteps.Any())
        {
            DoStep();
        }

        return _paths[^1][^1];
    }

    private void DoStep()
    {
        var point = _nextSteps.Dequeue();
        _grid[point.Item1.Item1][point.Item1.Item2] = -1;
        if (point.Item1.Item1 == _grid.Length - 1 && point.Item1.Item2 == _grid.Length - 1)
        {
            _nextSteps.Clear();
            return;
        }

        foreach ((int, (int, int)) zero in SeeAround(point.Item1).Where(r => r.Item1 == 0))
        {
            if (_paths[zero.Item2.Item1][zero.Item2.Item2] != -1)
            {
                if (_paths[zero.Item2.Item1][zero.Item2.Item2] > point.Item2 + 1)
                    _paths[zero.Item2.Item1][zero.Item2.Item2] = point.Item2 + 1;
            }
            else
            {
                _paths[zero.Item2.Item1][zero.Item2.Item2] = point.Item2 + 1;
            }

            _grid[zero.Item2.Item1][zero.Item2.Item2] = -1;
            _nextSteps.Enqueue((zero.Item2, point.Item2 + 1));
        }
    }

    private IEnumerable<(int, (int, int))> SeeAround((int, int) point)
    {
        if (point.Item1 > 0)
        {
            if (point.Item2 > 0)
            {
                yield return (_grid[point.Item1 - 1][point.Item2 - 1], (point.Item1 - 1, point.Item2 - 1));
            }

            yield return (_grid[point.Item1 - 1][point.Item2], (point.Item1 - 1, point.Item2));

            if (point.Item2 < _grid.Length - 1)
            {
                yield return (_grid[point.Item1 - 1][point.Item2 + 1], (point.Item1 - 1, point.Item2 + 1));
            }
        }

        if (point.Item2 > 0)
        {
            yield return (_grid[point.Item1][point.Item2 - 1], (point.Item1, point.Item2 - 1));
        }

        if (point.Item2 < _grid.Length - 1)
        {
            yield return (_grid[point.Item1][point.Item2 + 1], (point.Item1, point.Item2 + 1));
        }

        if (point.Item1 < _grid.Length - 1)
        {
            if (point.Item2 > 0)
            {
                yield return (_grid[point.Item1 + 1][point.Item2 - 1], (point.Item1 + 1, point.Item2 - 1));
            }

            yield return (_grid[point.Item1 + 1][point.Item2], (point.Item1 + 1, point.Item2));

            if (point.Item2 < _grid.Length - 1)
            {
                yield return (_grid[point.Item1 + 1][point.Item2 + 1], (point.Item1 + 1, point.Item2 + 1));
            }
        }
    }
}