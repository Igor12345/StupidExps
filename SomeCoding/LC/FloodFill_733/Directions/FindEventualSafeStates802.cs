namespace Directions;

public class FindEventualSafeStates802
{
    private HashSet<int> _firstlyVisited = new ();
    private HashSet<int> _secondlyVisited = new();
    private HashSet<int> _cycles = new();
    private HashSet<int> _safeNodes = new ();
    public IList<int> EventualSafeNodes(int[][] graph) {

        for (int i = 0; i < graph.Length; i++)
        {
            if (!_secondlyVisited.Contains(i))
            {
                _firstlyVisited.Clear();
                DfsCycle(graph, i);
            }
        }

        for (int i = 0; i < graph.Length; i++)
        {
            if (!_cycles.Contains(i))
                _safeNodes.Add(i);
        }

        return _safeNodes.ToList();
    }

    private bool DfsCycle(int[][]graph, int start)
    {
        bool cycleFound = false;
        _firstlyVisited.Add(start);
        foreach (int i in graph[start])
        {
            if (_cycles.Contains(i))
            {
                _cycles.Add(start);
                cycleFound = true;
            }
            if (!_firstlyVisited.Contains(i) && !_secondlyVisited.Contains(i))
            {
                var cycle = DfsCycle(graph, i) ;
                cycleFound = cycle || cycleFound;
                if (cycle)
                {
                    _cycles.Add(start);
                }
            }
            else if (_firstlyVisited.Contains(i) && !_secondlyVisited.Contains(i))
            {
                cycleFound = true;
                _cycles.Add(i);
                _cycles.Add(start);
            }
        }

        _secondlyVisited.Add(start);
        return cycleFound;
    }
}