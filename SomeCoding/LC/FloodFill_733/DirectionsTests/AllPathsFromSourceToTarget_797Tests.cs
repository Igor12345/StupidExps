using Directions;

namespace DirectionsTests;

public class AllPathsFromSourceToTarget_797Tests
{
    [Fact]
    public void Test1()
    {
        int[][] graph = new[]
        {
            new[] { 4, 3, 1 },
            new[] { 3, 2, 4 },
            new[] { 3 },
            new[] { 4 },
            Array.Empty<int>()
        };
        var solution = new AllPathsFromSourceToTarget_797();
        var result = solution.AllPathsSourceTarget(graph);

        var t = result;
    }
}