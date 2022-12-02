using Connections;

namespace ConnectionsTests;

public class NumberOfOperationsToMakeNetworkConnected_1319Tests
{
    [Fact]
    public void Test1()
    {
        int[][] connections = new[]
        {
            new[] { 0, 1 },
            new[] { 0, 2 },
            new[] { 1, 2 },
        };
        var solution = new NumberOfOperationsToMakeNetworkConnected_1319();
        var result = solution.MakeConnected(4,connections);
        var t = result;
    }
    [Fact]
    public void Test3()
    {
        int[][] connections = new[]
        {
            new[] { 0, 1 },
            new[] { 0, 2 },
            new[] { 0, 3 },
            new[] { 1, 2 }
        };
        var solution = new NumberOfOperationsToMakeNetworkConnected_1319();
        var result = solution.MakeConnected(6, connections);
        var t = result;
    }
    [Fact]
    public void Test4()
    {
        int[][] connections = new[]
        {
            new[] { 1, 4 }, new[] { 0, 3 }, new[] { 1, 3 }, new[] { 3, 7 }, new[] { 2, 7 }, new[] { 0, 1 },
            new[] { 2, 4 }, new[] { 3, 6 }, new[] { 5, 6 }, new[] { 6, 7 }, new[] { 4, 7 }, new[] { 0, 7 },
            new[] { 5, 7 }
        };
        var solution = new NumberOfOperationsToMakeNetworkConnected_1319();
        var result = solution.MakeConnected(11, connections);
        var t = result;
    }
}