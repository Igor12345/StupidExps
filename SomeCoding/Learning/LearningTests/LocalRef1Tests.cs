using Learning.LocalRef;

namespace LearningTests;

public class LocalRef1Tests
{
    public LocalRef1Tests()
    {
        Player.NextId = 4;
    }
    
    [Fact]
    public void Test1()
    {
        Point point = new Point(4, 6);
        Player player = new Player(point);
        Point location = player.GetLocation();

        location.X = 34;
        
        Assert.Equal(34, location.X);
        Assert.Equal(4, player.GetLocation().X);
        Assert.Equal(4, location.Id);
        Assert.Equal(4, player.GetLocation().Id);
        
    }
    
    [Fact]
    public void Test2()
    {
        Point point = new Point(4, 6);
        Player player = new Player(point);
        Point location = player.GetLocationRef();

        location.X = 34;
        
        Assert.Equal(34, location.X);
        Assert.Equal(4, player.GetLocation().X);
        Assert.Equal(4, location.Id);
        Assert.Equal(4, player.GetLocation().Id);
    }
    
    [Fact]
    public void Test3()
    {
        Point point = new Point(4, 6);
        Player player = new Player(point);
        ref readonly Point location = ref  player.GetLocationRef();

        // location.X = 34;
        Point location1 = player.LocationRef;
        location1.X = 34;

        ref readonly Point location2 = ref player.LocationRef;
        
        Assert.Equal(34, location.X);
        Assert.Equal(34, player.GetLocation().X);
        Assert.Equal(4, location.Id);
        Assert.Equal(4, player.GetLocation().Id);
    }
    
    [Fact]
    public void Test4()
    {
        Point point = new Point(4, 6);
        Player player = new Player(point);
        // player.GetLocationRef() = new Point(13, 15);
        
        Assert.Equal(13, player.GetLocation().X);
        // Assert.Equal(4, location.Id);
        Assert.Equal(5, player.GetLocation().Id);
    }
    
    [Fact]
    public void Test5()
    {
        Point point = new Point(11, 16);
        // player.GetLocationRef() = new Point(13, 15);
        MovePointIn(point, 7, 8);
        Assert.Equal(11, point.X);
        Assert.Equal(4, point.Id);
        // Assert.Equal(4, location.Id);
    }
    
    [Fact]
    public void Test6()
    {
        Point point = new Point(11, 16);
        // player.GetLocationRef() = new Point(13, 15);
        MovePoint(point, 7, 8);
        Assert.Equal(11, point.X);
        Assert.Equal(4, point.Id);
        // Assert.Equal(4, location.Id);
    }

    private void MovePointIn(in Point point, int dx, int dy)
    {
        // point.X += dx;
        
        point.Move(dx, dy);
        Assert.Equal(11, point.X);
        Assert.Equal(4, point.Id);
    }

    private void MovePoint(Point point, int dx, int dy)
    {
        // point.X += dx;
        
        point.Move(dx, dy);
        Assert.Equal(18, point.X);
        Assert.Equal(4, point.Id);
    }
    
    [Fact]
    public void Test7()
    {
        Point point = new Point(11, 16);
        // player.GetLocationRef() = new Point(13, 15);
        MovePointRef(ref point, 7, 8);
        Assert.Equal(18, point.X);
        Assert.Equal(4, point.Id);
        // Assert.Equal(4, location.Id);
    }

    private void MovePointRef(ref Point point, int dx, int dy)
    {
        // point.X += dx;
        
        point.Move(dx, dy);
        Assert.Equal(18, point.X);
        Assert.Equal(4, point.Id);
    }
}