namespace MinimumHeightTrees;

public class GraphProcessor
{
    private readonly GraphStructure _graph;

    public GraphProcessor(GraphStructure graph)
    {
        _graph = graph;
    }

    public List<int> FindRoots()
    {
        List<int> roots = _graph.AdjacencyList.Keys.ToList();
        while (_graph.AdjacencyList.Any())
        {
            roots = _graph.AdjacencyList.Keys.ToList();
            List<ValueTuple<int, int>> toDelete = new List<ValueTuple<int, int>>();
            foreach (KeyValuePair<int, HashSet<int>> pair in _graph.AdjacencyList)
            {
                if (pair.Value.Count == 1)
                {
                    toDelete.Add((pair.Key, pair.Value.First()));
                }
            }

            foreach ((int, int) edge in toDelete)
            {
                _graph.AdjacencyList.Remove(edge.Item1);
                if (_graph.AdjacencyList.ContainsKey(edge.Item2))
                    _graph.AdjacencyList[edge.Item2].Remove(edge.Item1);
            }

            if (_graph.AdjacencyList.Count == 1 && !_graph.AdjacencyList[_graph.AdjacencyList.Keys.First()].Any())
            {
                roots = _graph.AdjacencyList.Keys.ToList();
                _graph.AdjacencyList.Clear();
            }
        }

        return roots;
    }
}