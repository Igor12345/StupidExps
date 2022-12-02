namespace Connections;

public class NumberOfOperationsToMakeNetworkConnected_1319
{
    private HashSet<int> _belongsToComponents = new();
    private readonly Dictionary<int, List<int>> _adjacency = new();
    private int _components;
    private HashSet<(int,int)> _backEdges = new();

    public int MakeConnected(int n, int[][] connections)
    {

        foreach (int[] edge in connections)
        {
            if (!_adjacency.ContainsKey(edge[0]))
                _adjacency.Add(edge[0], new List<int>());
            if (!_adjacency.ContainsKey(edge[1]))
                _adjacency.Add(edge[1], new List<int>());

            if (!_adjacency[edge[0]].Contains(edge[1]))
                _adjacency[edge[0]].Add(edge[1]);
            if (!_adjacency[edge[1]].Contains(edge[0]))
                _adjacency[edge[1]].Add(edge[0]);
        }

        for (int i = 0; i < n; i++)
        {
            if (!_adjacency.ContainsKey(i))
            {
                _belongsToComponents.Add(i);
                _components++;
                continue;
            }
            if(_belongsToComponents.Contains(i))
                continue;
            DFS(i);
        }

        if (_components == 1)
            return 0;

        int backEdges = _backEdges.Count;
        if (_components - 1 > backEdges)
            return -1;

        return _components - 1;
    }

    private void DFS(int start)
    {
        _components++;
        Stack<(int, int)> stack = new();
        HashSet<int> visited = new();
        stack.Push((-1, start));

        while (stack.Any())
        {
            var (last, vertex) = stack.Pop();
            if (visited.Contains(vertex))
            {
                if (!_backEdges.Contains((last, vertex)))
                    _backEdges.Add((vertex, last));
                continue;
            }

            visited.Add(vertex);
            _belongsToComponents.Add(vertex);
            foreach (int next in _adjacency[vertex])
            {
                if (next == last)
                    continue;

                stack.Push((vertex, next));
            }
        }
    }

}