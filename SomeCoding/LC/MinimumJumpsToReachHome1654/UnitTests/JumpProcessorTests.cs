using Task;

namespace UnitTests;

public class JumpProcessorTests
{
    [Fact]
    public void Test2()
    {
        int[] forbidden = new []{8,3,16,6,12,20};
        Processor processor = new Processor(15, 13, 11, forbidden);
        Jump? final = processor.Run();
        string? path = final?.Path();
        int result = processor.Execute();
    }
    [Fact]
    public void Test3()
    {
        int[] forbidden = new []{1,6,2,14,5,17,4};
        Processor processor = new Processor(16, 9, 7, forbidden);
        Jump? final = processor.Run(); 
        string? path = final?.Path();
        int result = processor.Execute();
    }
}