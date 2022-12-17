namespace Connections;

public class MaximalNetworkRank1615
{
    public int MaximalNetworkRank(int n, int[][] roads)
    {
        for (int i = 0; i < roads.Length; i++)
        {
            int first = roads[i][0];
            int second = roads[i][1];
            (int, int) key = (Math.Min(first, second), Math.Max(first, second));
            if (!_pairs.Contains(key))
            {
                _pairs.Add(key);
                AddOrIncreaseAdjacency(first);
                AddOrIncreaseAdjacency(second);
            }
        }
        
        int max = 0;
        for (int i = 0; i < n; i++)
        {
            if (!_adjacency.ContainsKey(i)) continue;
            for (int j = i + 1; j < n; j++)
            {
                if (!_adjacency.ContainsKey(j)) continue;
                bool decrease = _pairs.Contains((i, j));
                int pairRank = _adjacency[i] + _adjacency[j] - (decrease ? 1 : 0);
                if (pairRank > max)
                    max = pairRank;
            }
        }
        return max;
    }

    private void AddOrIncreaseAdjacency(int vertex)
    {
        if (!_adjacency.ContainsKey(vertex))
        {
            _adjacency.Add(vertex, 1);
        }
        else
        {
            _adjacency[vertex] += 1;
        }
    }

    private readonly HashSet<(int, int)> _pairs = new HashSet<(int, int)>();
    private Dictionary<int, int> _adjacency = new Dictionary<int, int>();

}