namespace Directions;

public class NumberOfProvinces_547
{
    private HashSet<int> _visited = new();
    private Queue<int> _queue = new();

    public int FindCircleNum(int[][] isConnected)
    {
        int result = 0;
        for (int i = 0; i < isConnected.Length; i++)
        {
            if (_visited.Contains(i))
                continue;
            Walk(i, isConnected);
            result++;
        }

        return result;
    }

    private void Walk(int i, int[][] isConnected)
    {
        _queue = new();
        for (int j = 0; j < isConnected.Length; j++)
        {
            if (i != j && isConnected[i][j] == 1)
                _queue.Enqueue(j);
        }

        while (_queue.Any())
        {
            int next = _queue.Dequeue();
            _visited.Add(next);
            for (int j = 0; j < isConnected.Length; j++)
            {
                if (next != j && isConnected[next][j] == 1 && !_visited.Contains(j))
                    _queue.Enqueue(j);
            }
        }
    }
}