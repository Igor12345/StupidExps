using Connections;

namespace ConnectionsTests;

public class MaximalNetworkRank1615Tests
{
    [Fact]
    public void Test1()
    {
        int n = 4;
        int[][] roads = new[]
        {
            new[] { 0, 1 },
            new[] { 0, 3 },
            new[] { 1, 2 },
            new[] { 1, 3 }
        };
        MaximalNetworkRank1615 solution = new MaximalNetworkRank1615();
        int result = solution.MaximalNetworkRank(n, roads);

        var t = result;
    }
    
    [Fact]
    public void Test2()
    {
        int n = 5;
        int[][] roads = new[]
        {
            new[] { 0, 1 },
            new[] { 0, 3 },
            new[] { 1, 2 },
            new[] { 1, 3 },
            new[] { 2, 3 },
            new[] { 2, 4 }
        };
        MaximalNetworkRank1615 solution = new MaximalNetworkRank1615();
        int result = solution.MaximalNetworkRank(n, roads);

        var t = result;
    }
    
    [Fact]
    public void Test3()
    {
        int n = 8;
        int[][] roads = new[]
        {
            new[] { 0, 1 },
            new[] { 1, 2 },
            new[] { 2, 3 },
            new[] { 2, 4 },
            new[] { 5, 6 },
            new[] { 5, 7 }
        };
        MaximalNetworkRank1615 solution = new MaximalNetworkRank1615();
        int result = solution.MaximalNetworkRank(n, roads);

        var t = result;
    }
    
    [Fact]
    public void Test4()
    {
        int n = 2;
        int[][] roads = Array.Empty<int[]>();
        MaximalNetworkRank1615 solution = new MaximalNetworkRank1615();
        int result = solution.MaximalNetworkRank(n, roads);

        var t = result;
    }
}