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
            Console.WriteLine($"Start node {i}, cleaning firstly visited");
            _firstlyVisited.Clear();
            if (!_secondlyVisited.Contains(i))
            {
                Console.WriteLine($"Node {i} was not visited twice");
                DfsCycle(graph, i, 2);
            }
        }

        for (int i = 0; i < graph.Length; i++)
        {
            if (!_cycles.Contains(i))
                _safeNodes.Add(i);
        }

        return _safeNodes.ToList();
    }

    private bool DfsCycle(int[][]graph, int start, int shift)
    {
        bool cycleFound = false;
        Console.WriteLine($"{new string(' ', shift)} Entering DFS {start}, added to Firstly visited");
        _firstlyVisited.Add(start);
        foreach (int i in graph[start])
        {
            Console.WriteLine($"{new string(' ', shift)} Processing {i} from {start}");
            if (!_firstlyVisited.Contains(i) && !_secondlyVisited.Contains(i))
            {
                cycleFound = DfsCycle(graph, i, shift + 2);
                if (cycleFound)
                {
                    Console.WriteLine($"{new string(' ', shift)} Adding {start} to cycles, because of {i}");
                    _cycles.Add(start);
                }
            }
            else if (_firstlyVisited.Contains(i) && !_secondlyVisited.Contains(i))
            {
                Console.WriteLine($"{new string(' ', shift)} Tne node {i} belong to cycle, so do {start}");
                cycleFound = true;
                _cycles.Add(i);
                _cycles.Add(start);
            }

            // if (_cycles.Contains(i) && !_secondlyVisited.Contains(i))
            // {
            //     Console.WriteLine($"Adding {start} to cycles, because of {i}");
            //     _cycles.Add(start);
            // }
        }

        Console.WriteLine($"{new string(' ', shift)} The node {start} added to visited Twice");
        _secondlyVisited.Add(start);
        return cycleFound;
    }
}