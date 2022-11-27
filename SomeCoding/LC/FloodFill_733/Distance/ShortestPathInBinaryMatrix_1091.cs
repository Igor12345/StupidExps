using System.Collections;

namespace Distance;

public class ShortestPathInBinaryMatrix_1091
{
    private bool _canContinue = true;
    private Queue<(int, int)> _nextSteps = new Queue<(int, int)>();
    private Dictionary<(int, int), List<(int, int)>> _paths = new Dictionary<(int, int), List<(int, int)>>();
    private int[][] _grid;

    public int ShortestPathBinaryMatrix(int[][] grid)
    {
        _grid = grid;
        if (grid[0][0] != 0 || grid[^1][^1] != 0)
            return -1;
        
        _nextSteps.Enqueue((0, 0));
        _paths.Add((0, 0), new List<(int, int)> { (0, 0) });
        while (_nextSteps.Any())
        {
            DoStep();
        }

        int pathLength = _paths.ContainsKey((_grid.Length - 1, _grid.Length - 1))
            ? _paths[(_grid.Length - 1, _grid.Length - 1)].Count()
            : -1;
        return pathLength;
    }

    private void DoStep()
    {
        var point = _nextSteps.Dequeue();
        _grid[point.Item1][point.Item2] = -1;
        if (point.Item1 == _grid.Length - 1 && point.Item2 == _grid.Length - 1)
        {
            _nextSteps.Clear();
            return;
        }
        
        foreach ((int, (int, int)) zero in SeeAround(point).Where(r =>r.Item1==0))
        {
            List<(int, int)> path = new List<(int, int)>(_paths[point]) { zero.Item2 };
            if (_paths.ContainsKey(zero.Item2))
            {
                if (_paths[zero.Item2].Count > path.Count)
                    _paths[zero.Item2] = path;
            }
            else
            {
                _paths.Add(zero.Item2, path);
            }
            _grid[zero.Item2.Item1][zero.Item2.Item2] = -1;
            _nextSteps.Enqueue(zero.Item2);
        }

        _paths.Remove(point);
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