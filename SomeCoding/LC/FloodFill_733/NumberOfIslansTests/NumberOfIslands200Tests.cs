using FloodFill_733;

namespace NumberOfIslansTests;

public class NumberOfIslands200Tests
{
    [Fact]
    public void Test1()
    {
        NumberOfIslands_200 solution = new NumberOfIslands_200();
        char[][] grid = new[]
        {
            new[] { '1', '1', '1', '1', '0' },
            new[] { '1', '1', '0', '1', '0' },
            new[] { '1', '1', '0', '0', '0' },
            new[] { '0', '0', '0', '0', '0' }
        };
        var res = solution.NumIslands(grid);
        var t = res;
    }
    [Fact]
    public void Test2()
    {
        NumberOfIslands_200 solution = new NumberOfIslands_200();
        char[][] grid = new[]
        {
            new[] { '1','1','0','0','0' },
            new[] { '1','1','0','0','0' },
            new[] { '0','0','1','0','0' },
            new[] { '0','0','0','1','1' }
        };
        var res = solution.NumIslands(grid);
        var t = res;
    }
}