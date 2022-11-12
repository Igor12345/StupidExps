namespace Task;

public class Task
{
    public int MinimumJumps(int[] forbidden, int a, int b, int x)
    {
        return -1;
    }

    private void Run(Jumps history)
    {
        
    }
}

public class Jump
{
    public int Location;
    public int Step;

    public Jump Right;
    public bool? RightAllowed;
    
    public Jump Left;
    public bool? LeftAllowed;
}

public class Jumps
{
    public Dictionary<int, Jump> Visited = new Dictionary<int, Jump>();
}