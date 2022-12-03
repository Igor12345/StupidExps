using Distance;

namespace DistanceTestds;

public class TimeNeededToInformAllEmployees_1376Tests
{
    [Fact]
    public void BuildTree()
    {
        int[] manager = new[] { 6, 6, 1, 5, 3, -1, 5, 1 };
        int[] informTime = new[] { 0, 4, 0, 1, 0, 3, 2, 0 };

        var solution = new TimeNeededToInformAllEmployees_1376();
        var time = solution.NumOfMinutes(8, 5, manager, informTime);
        
        var t = time;

    }

    [Fact]
    public void Test1()
    {
        int[] manager = new[] { -1 };
        int[] informTime = new[] { 0 };

        var solution = new TimeNeededToInformAllEmployees_1376();
        var time = solution.NumOfMinutes(1, 0, manager, informTime);
        
        var t = time;
    }[Fact]
    public void Test2()
    {
        int[] manager = new[] { 2,2,-1,2,2,2 };
        int[] informTime = new[] { 0,0,1,0,0,0 };

        var solution = new TimeNeededToInformAllEmployees_1376();
        var time = solution.NumOfMinutes(6, 2, manager, informTime);
        
        var t = time;
    }
}