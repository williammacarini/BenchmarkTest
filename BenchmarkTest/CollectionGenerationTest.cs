using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System.Collections.ObjectModel;

namespace BenchmarkTest
{
    [MemoryDiagnoser]
    [ShortRunJob]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class CollectionGenerationTest
    {
        [Benchmark]
        public void NumbersList()
        {
            var numbersList = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                numbersList.Add(i);
            }
        }

        [Benchmark]
        public void NumbersCollection()
        {
            var numbersCollection = new Collection<int>();
            for (int i = 0; i < 100; i++)
            {
                numbersCollection.Add(i);
            }
        }

        [Benchmark]
        public void NumbersArray()
        {
            var numbersArray = new int[100];
            for (int i = 0; i < 99; i++)
            {
                numbersArray[i] = i;
            }
        }

        [Benchmark]
        public void NumbersSpan()
        {
            var numbersSpan = new Span<int>([99]);
            for (int i = 0; i < numbersSpan.Length; i++)
            {
                numbersSpan[i] = i;
            }
        }

        [Benchmark]
        public void NumbersStackAlloc()
        {
            Span<int> number = stackalloc int[99];
            for (int i = 0; i < number.Length; i++)
            {
                number[i] = i;
            }
        }

        [Benchmark]
        public void NumbersStruct()
        {
            var number = new IntTest[100];
            for (int i = 0; i < number.Length; i++)
            {
                number[i] = new IntTest(i);
            }
        }

        internal struct IntTest(int number)
        {
            public int Number { get; set; } = number;
        }
    }
}
