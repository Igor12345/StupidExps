namespace Learning.LocalRef;

public struct Point
{
    public int X;
    public int Y;
    public readonly int Id;

    public Point(int x, int y)
    {
        (X, Y) = (x, y);
        Id = Player.NextId++;
    }

    public void Move(int dx, int dy)
    {
        X += dx;
        Y += dy;
    }
}

public class Player
{
    public static int NextId = 4;
    private Point _location;

    public Player(Point location)
    {
        _location = location;
    }

    public Point GetLocation()
    {
        return _location;
    }
    public ref readonly Point GetLocationRef()
    {
        return ref _location;
    }

    public ref readonly Point LocationRef => ref _location;
    public Point Location => _location;
}


