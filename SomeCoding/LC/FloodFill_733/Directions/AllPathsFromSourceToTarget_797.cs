using System.Collections.Immutable;

namespace Directions;

public class AllPathsFromSourceToTarget_797
{
    private readonly Stack<(int, ImmutableList<int>)> _path = new();
    private HashSet<(int, int)> _visitedEdges = new();
    private Dictionary<int, ImmutableList<int>> _candidates = new();
    private IList<IList<int>> _result = new List<IList<int>>();
    
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
    {
        if (!graph.Any() || !graph[0].Any())
            return _result;
        
        var start = ImmutableList<int>.Empty;
        _path.Push((0, start.Add(0)));

        while (_path.Any())
        {
            var ( vertex, candidate) = _path.Pop();
            Console.WriteLine($"Processing {vertex}, candidate [{string.Join(", ", candidate.ToList())}]");

            foreach (int next in graph[vertex])
            {
                // if (_visitedEdges.Contains((vertex, next)))
                //     continue;
                // _visitedEdges.Add((vertex, next));
                var newCandidate = candidate.Add(next);
                _path.Push((next, newCandidate));

                Console.WriteLine($"Next for {vertex} is {next}, path: [{string.Join(", ", newCandidate.ToList())}]");
                // if (!_candidates.ContainsKey(next))
                // {
                //     Console.WriteLine($"Adding path {next}: candidate: {string.Join(", ", newCandidate.ToList())}");
                //     _candidates.Add(next, newCandidate);
                // }
                // else
                // {
                //     Console.WriteLine($"Updating path {next}: candidate: {string.Join(", ", newCandidate.ToList())}");
                //     _candidates[next] = newCandidate;
                // }
            }

            if (vertex == graph.Length - 1)
            {
                _result.Add(candidate.ToList());
                Console.WriteLine($"New Path: {string.Join(", ", candidate.ToList())}");
                continue;
            }
            // if (!_candidates.ContainsKey(vertex))
            // {
            //     Console.WriteLine($"Adding path {vertex}: candidate: {string.Join(", ", candidate.ToList())}");
            //     _candidates.Add(vertex, candidate);
            // }
            // else
            // {
            //     Console.WriteLine($"Updating path {vertex}: candidate: {string.Join(", ", candidate.ToList())}");
            //     _candidates[vertex] = candidate;
            // }

            Console.WriteLine($"number candidates - {_candidates.Count}");
        }

        return _result;
    }
}