using Distance;

namespace DistanceTestds;

public class AsFarFromLand1162Tests
{
    [Fact]
    public void Test1()
    {
        int[][] grid = new[]
        {
            new[] { 1, 0, 1 },
            new[] { 0, 0, 0 },
            new[] { 1, 0, 1 }
        };
        AsFarFromLand_1162_2 task = new AsFarFromLand_1162_2();
        int result = task.MaxDistance(grid);

        var t = result;
    }
    [Fact]
    public void Test2()
    {
        int[][] grid = new[]
        {
            new[] { 1, 0, 0 },
            new[] { 0, 0, 0 },
            new[] { 0, 0, 0 }
        };
        AsFarFromLand_1162_2 task = new AsFarFromLand_1162_2();
        int result = task.MaxDistance(grid);

        var t = result;
    }
}