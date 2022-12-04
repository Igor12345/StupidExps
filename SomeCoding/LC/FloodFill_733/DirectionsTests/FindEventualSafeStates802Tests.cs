using Directions;

namespace DirectionsTests;

public class FindEventualSafeStates802Tests
{
    [Fact]
    public void Test1()
    {

        int[][] connections = new[]
        {
            new[] { 1, 2 },
            new[] { 2, 3 },
            new[] { 5 },
            new[] { 0 },
            new[] { 5 },
            Array.Empty<int>(),
            Array.Empty<int>()
        };
        var solution = new FindEventualSafeStates802();
        var safeNodes = solution.EventualSafeNodes(connections);
        var t = safeNodes;
    }
}