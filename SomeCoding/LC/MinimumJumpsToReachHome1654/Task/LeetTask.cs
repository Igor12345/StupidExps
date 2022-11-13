namespace Task;

public class LeetTask
{
    public int MinimumJumps(int[] forbidden, int a, int b, int x)
    {
        Processor processor = new Processor(a, b, x, forbidden);
        return processor.Execute();
    }

    
}

public class Processor
{
    private readonly int _a;
    private readonly int _b;
    private readonly int _home;
    private readonly List<int> _forbidden;
    private readonly Dictionary<int, Jump> _visited = new Dictionary<int, Jump>();

    public Processor(int a, int b, int home, int[] forbidden)
    {
        _a = a;
        _b = b;
        _home = home;
        _forbidden = forbidden.ToList();
        _forbidden.Sort();
    }

    public int Execute()
    {
        Jump? final = Run();
        if (final == null)
            return -1;
        return final.Step;
    }

    public Jump? Run()
    {
        Jump root = new Jump()
        {
            Location = 0,
            Step = 0,
            LeftAllowed = false,
            RightAllowed = CanJumpRight(0)
        };

        Jump current = root;
        Queue<Jump> todo = new Queue<Jump>();
        if (current.LeftAllowed || current.RightAllowed)
            todo.Enqueue(current);

        while (todo.Count > 0)
        {
            current = todo.Dequeue();
            Jump? left = JumpLeft(current);
            current.Left = left;
            if (left != null)
            {
                if (left.Location == _home)
                {
                    return left;
                }

                todo.Enqueue(left);
            }

            Jump? right = JumpRight(current);
            current.Right = right;
            if (right != null)
            {
                if (right.Location == _home)
                {
                    return right;
                }

                todo.Enqueue(right);
            }
        }

        return null;
    }

    private Jump? JumpLeft(Jump current)
    {
        return PerformJump(current, current.LeftAllowed, current.Location - _b);
    }

    private Jump? JumpRight(Jump current)
    {
        return PerformJump(current, current.RightAllowed, current.Location + _a);
    }

    private Jump? PerformJump(Jump current, bool canJump, int newLocation)
    {
        if (canJump)
        {
            if (_visited.ContainsKey(newLocation))
            {
                if (_visited[newLocation].Step > current.Step + 1)
                {
                    UpdateTree(_visited[newLocation], current.Step + 1);
                    _visited[newLocation].Parent = current;
                    return null;
                }
            }
            else
            {
                Jump jump = new Jump()
                {
                    Parent = current,
                    Location = newLocation,
                    Step = current.Step + 1,
                    LeftAllowed = CanJumpLeft(newLocation),
                    RightAllowed = CanJumpRight(newLocation)
                };
                _visited.Add(jump.Location, jump);
                return jump;
            }
        }

        return null;
    }

    private void UpdateTree(Jump jump, int step)
    {
        jump.Step = step;
        WalkThroughTree(jump, (Jump j, Jump parent) => { j.Step = parent.Step + 1; });
    }

    private void WalkThroughTree(Jump jump, Action<Jump, Jump> update)
    {
        if (jump.Left != null)
        {
            update(jump.Left, jump);
            WalkThroughTree(jump.Left, update);
        }

        if (jump.Right != null)
        {
            update(jump.Right, jump);
            WalkThroughTree(jump.Right, update);
        }
    }

    private bool CanJumpLeft(int location)
    {
        return location >= _b && !_forbidden.Contains(location - _b);
    }

    private bool CanJumpRight(int location)
    {
        return !_forbidden.Contains(location + _a) && location <= _home + _a * _b;
    }
}

public class Jump
{
    public int Location;
    public int Step;

    public Jump? Parent;

    public Jump? Right;
    public bool RightAllowed;

    public Jump? Left;
    public bool LeftAllowed;

    public string Path()
    {
        List<int> path = new List<int> { Location };
        Jump jump = this;
        while (jump.Parent != null)
        {
            jump = jump.Parent;
            path.Add(jump.Location);
        }

        path.Reverse();
        return string.Join(", ", path);
    }

    public override string ToString() => $"This: {Location}, parent: {Parent?.Location}";
}