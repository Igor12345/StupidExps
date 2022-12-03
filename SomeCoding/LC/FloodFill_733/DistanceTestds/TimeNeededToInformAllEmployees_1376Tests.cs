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
        var time = solution.NumOfMinutes(8, -1, manager, informTime);
        
        var t = time;

    }
}