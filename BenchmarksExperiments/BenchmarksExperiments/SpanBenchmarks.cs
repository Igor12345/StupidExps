using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class SpanBenchmarks
{
    private int[] _array;
    
    [Params(100, 1000, 10000)]
    public int Size { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        _array = new int[Size];

        for (int i = 0; i < Size; i++)
        {
            _array[i] = i;
        }
    }

    [Benchmark(Baseline = true)]
    public int[] Original() => _array.Skip(Size / 2).Take(Size / 4).ToArray();

    [Benchmark]
    public int[] CopyArray()
    {
        var newArray = new int[Size / 4];
        Array.Copy(_array, Size/2, newArray, 0, Size/4);
        return newArray;
    }

    [Benchmark]
    public Span<int> Span() => _array.AsSpan().Slice(Size / 2, Size / 4);

    public void AboutStrings()
    {
        MemoryExtensions.ToLower()
    }
}