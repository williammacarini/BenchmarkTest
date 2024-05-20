using BenchmarkDotNet.Attributes;

namespace BenchmarkTest
{
    [MemoryDiagnoser]
    [ShortRunJob]
    public class StringTest
    {
        public string FirstProperty { get; } = "Test";
        public string SecondProperty { get; } = "Test";

        [Benchmark]
        public bool StringEquals()
            => FirstProperty.ToLower() == SecondProperty.ToLower();

        [Benchmark]
        public bool StringEqualsComparison()
            => FirstProperty.Equals(SecondProperty, StringComparison.OrdinalIgnoreCase);
    }
}
