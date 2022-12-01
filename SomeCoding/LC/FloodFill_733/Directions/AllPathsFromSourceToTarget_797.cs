using System.Collections.Immutable;

namespace Directions;

public class AllPathsFromSourceToTarget_797
{
    private readonly Stack<(int, ImmutableList<int>)> _path = new();
    private readonly IList<IList<int>> _result = new List<IList<int>>();
    
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
    {
        if (!graph.Any() || !graph[0].Any())
            return _result;
        
        var start = ImmutableList<int>.Empty;
        _path.Push((0, start.Add(0)));

        while (_path.Any())
        {
            var ( vertex, candidate) = _path.Pop();

            foreach (int next in graph[vertex])
            {
                var newCandidate = candidate.Add(next);
                _path.Push((next, newCandidate));
            }

            if (vertex == graph.Length - 1)
            {
                _result.Add(candidate.ToList());
            }
        }

        return _result;
    }
}