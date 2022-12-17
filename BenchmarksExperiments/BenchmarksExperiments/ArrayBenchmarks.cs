using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class ArrayBenchmarks
{
    [Params(100, 1000, 10000)]
    public int Size { get; set; }

    [Benchmark(Baseline = true)]
    public int UseEmptyParams()
    {
        int k = 0;
        for (int i = 0; i < Size; i++)
        {
            k += DoSomething(i);
        }
        return k;
    }

    [Benchmark]
    public int UseEmptyArray()
    {
        int k = 0;
        for (int i = 0; i < Size; i++)
        {
            k += DoSomething(i, Array.Empty<int>());
        }
        return k;
    }

    [Benchmark]
    public int UseNonEmptyParam()
    {
        int k = 0;
        for (int i = 0; i < Size; i++)
        {
            k += DoSomething(i, k, i);
        }
        return k;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private int DoSomething(int value, params int[] values)
    {
        return value * 2;
    }
}