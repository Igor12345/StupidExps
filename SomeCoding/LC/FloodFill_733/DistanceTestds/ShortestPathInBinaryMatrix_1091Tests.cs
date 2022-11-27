using Distance;

namespace DistanceTestds;

public class ShortestPathInBinaryMatrix_1091Tests
{
    [Fact]
    public void Test1()
    {
        int[][] grid = new[]
        {
            new[] { 0, 1 },
            new[] { 1, 0 }
        };
        var solution = new ShortestPathInBinaryMatrix_1091();
        int path = solution.ShortestPathBinaryMatrix(grid);

        var t = path;
    }
    [Fact]
    public void Test2()
    {
        int[][] grid = new[]
        {
            new[] { 0, 0, 0 },
            new[] { 1, 1, 0 },
            new[] { 1, 1, 0 }
        };
        var solution = new ShortestPathInBinaryMatrix_1091();
        int path = solution.ShortestPathBinaryMatrix(grid);

        var t = path;
    }
    [Fact]
    public void Test4()
    {
        int[][] grid = new[]
        {
            new[] { 0, 1, 1, 0, 0, 0 }, 
            new[] { 0, 1, 0, 1, 1, 0 }, 
            new[] { 0, 1, 1, 0, 1, 0 },
            new[] { 0, 0, 0, 1, 1, 0 }, 
            new[] { 1, 1, 1, 1, 1, 0 }, 
            new[] { 1, 1, 1, 1, 1, 0 }
        };
        var solution = new ShortestPathInBinaryMatrix_1091();
        int path = solution.ShortestPathBinaryMatrix(grid);

        var t = path;
    }
}