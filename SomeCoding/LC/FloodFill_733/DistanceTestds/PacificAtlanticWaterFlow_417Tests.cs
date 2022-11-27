using Distance;

namespace DistanceTestds;

public class PacificAtlanticWaterFlow_417Tests
{
    [Fact]
    public void Test1()
    {
        int[][] grid = new[]
        {
            new[] { 1,2,2,3,5 },
            new[] { 3,2,3,4,4 },
            new[] { 2,4,5,3,1 },
            new[] { 6,7,1,4,5 },
            new[] { 5,1,1,2,4 }
        };
        var solution = new PacificAtlanticWaterFlow_417();
        var result = solution.PacificAtlantic(grid);
        var t = result;
    } 
    
    [Fact]
    public void Test2()
    {
        int[][] grid = new[]
        {
            new[] { 1 }
        };
        var solution = new PacificAtlanticWaterFlow_417();
        var result = solution.PacificAtlantic(grid);
        var t = result;
    }
    [Fact]
    public void Test3()
    {
        int[][] grid = new[]
        {
            new[] { 3,3,3,3,3,3 },
            new[] { 3,0,3,3,0,3 },
            new[] { 3,3,3,3,3,3 }
        };
        var solution = new PacificAtlanticWaterFlow_417();
        var result = solution.PacificAtlantic(grid);
        var t = result;
    } 
}