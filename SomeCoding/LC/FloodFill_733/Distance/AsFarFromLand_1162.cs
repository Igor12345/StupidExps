namespace Distance;

public class AsFarFromLand_1162
{
    private readonly int _land = 1;
    private readonly int _water = 0;
    private int[][] _gridUp;
    private int[][] _gridDown;
    private int[][] _gridLeft;
    private int[][] _gridRight;
    private int[][][] _allGrids;
    private Func<int, int, bool>[] _boundaryConditions;
    private Func<int, int, bool>[] _landConditions;
    private Func<int, int, (int, int)>[] _movements;
    private int[][] _grid;

    public int MaxDistance(int[][] grid)
    {
        int result = -1;
        _grid = grid;
        _gridUp = new int[grid.Length][];
        _gridDown = new int[grid.Length][];
        _gridLeft = new int[grid.Length][];
        _gridRight = new int[grid.Length][];
        _allGrids = new[] { _gridUp, _gridDown, _gridLeft, _gridRight };
        List<List<List<int>>> directions = new()
        {
            new() { new() { 0, 2 }, new() { 0, 3 } },
            new() { new() { 1, 2 }, new() { 1, 3 } },
            new() { new() { 2, 0 }, new() { 2, 1 } },
            new() { new() { 3, 0 }, new() { 3, 1 } }
        };

        _boundaryConditions = new Func<int, int, bool>[]
        {
            (i, j) => i == 0,
            (i, j) => i == _grid.Length - 1,
            (i, j) => j == 0,
            (i, j) => j == _grid[0].Length - 1
        };

        _landConditions = new Func<int, int, bool>[]
        {
            (i, j) => _grid[i - 1][j] == _land,
            (i, j) => _grid[i + 1][j] == _land,
            (i, j) => _grid[i][j - 1] == _land,
            (i, j) => _grid[i][j + 1] == _land
        };
        _movements = new Func<int, int, (int, int)>[]
        {
            (i, j) => (i - 1, j),
            (i, j) => (i + 1, j),
            (i, j) => (i, j - 1),
            (i, j) => (i, j + 1)
        };
        for (int i = 0; i < grid.Length; i++)
        {
            _gridUp[i] = new int[grid[i].Length];
            _gridDown[i] = new int[grid[i].Length];
            _gridLeft[i] = new int[grid[i].Length];
            _gridRight[i] = new int[grid[i].Length];
        }

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == _water)
                {
                    List<int> distance = new List<int>();
                    foreach (List<List<int>> directionPair in directions)
                    {
                        distance.Add(Walk(i, j, directionPair));
                    }

                    var dists = distance.Where(d => d > 0).ToList();
                    int min = dists.Any() ? dists.Min() : -1;
                    if (min > result)
                        result = min;
                }
            }
        }

        return result;
    }


    private int Walk(int i, int j, List<List<int>> directionPair)
    {
        List<int> distance = new List<int>();
        int k = -1;
        foreach (List<int> directions in directionPair)
        {
            k = directions[0];
            int result = Walk(i, j, directions, 0);
            if (result == -1)
            {
                continue;
            }

            distance.Add(result);
        }

        int fullResult = distance.Any() ? distance.Min() : -1;
        _allGrids[k][i][j] = fullResult == -1 ? -1 : fullResult;

        return fullResult;
    }

    private int Walk(int i, int j, List<int> directions, int step)
    {
        List<int> distance = new List<int>();
        for (int l = 0; l < directions.Count; l++)
        {
            int k = directions[l];
            if (_allGrids[k][i][j] < 0)
            {
                continue;
            }

            if (_allGrids[k][i][j] > 0)
            {
                distance.Add(_allGrids[k][i][j]);
                continue;
            }

            if (_boundaryConditions[k](i, j))
            {
                _allGrids[k][i][j] = -1;
                continue;
            }

            if (_landConditions[k](i, j))
            {
                _allGrids[k][i][j] = 1;
                distance.Add(1);
                continue;
            }

            if (step == 0 && l != 0)
                continue;
            
            (int i1, int j1) = _movements[k](i, j);
            int result = Walk(i1, j1, directions, step + 1);
            if (result == -1)
            {
                continue;
            }

            distance.Add(1 + result);
        }

        return distance.Any() ? distance.Min() : -1;
    }
}