using Distance;

namespace DistanceTestds;

public class NearestExitFromEntranceInMaze_1926Tests
{
    [Fact]
    public void Test1()
    {
        char[][] maze = new[]
        {
            new[] { '+','+','.','+' },
            new[] { '.','.','.','+' },
            new[] { '+','+','+','.' }
        };
        var solution = new NearestExitFromEntranceInMaze_1926();
        int steps = solution.NearestExit(maze, new[]{1,2});
        var t = steps;
    }
    
    [Fact]
    public void Test2()
    {
        char[][] maze = new[]
        {
            new[] { '+','+','+' },
            new[] { '.','.','.' },
            new[] { '+','+','+' }
        };
        var solution = new NearestExitFromEntranceInMaze_1926();
        int steps = solution.NearestExit(maze, new[]{1,0});
        Assert.True(steps == 2);
    }
    
    [Fact]
    public void Test3()
    {
        char[][] maze = new[]
        {
            new[] { '.','+','+','+','+' },
            new[] { '.','+','.','.','.' },
            new[] { '.','+','.','+','.' },
            new[] { '.','.','.','+','.' },
            new[] { '+','+','+','+','.' },
        };
        var solution = new NearestExitFromEntranceInMaze_1926();
        int steps = solution.NearestExit(maze, new[] { 0, 0 });
        Assert.True(steps == 1);
    }
}