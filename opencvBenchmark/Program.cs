using BenchmarkDotNet.Running;
using System;

namespace opencvBenchmark
{
    public static class Program
    {
        public static string ImageFile = @"C:\\src\\opencv\\opencvBenchmark\\bin\\Release\\net472\\full.png";
        public static string TemplateFile = @"C:\\src\\opencv\\opencvBenchmark\\bin\\Release\\net472\\part.png";

        static void Main(string[] args)
        {
            if (args.Length == 1 && args[0].Equals("show"))
            {
                CSharpMatcher.ShowMatch(ImageFile, TemplateFile);
                return;
            } else
            {
                var benchmark = new Benchmark();
                if (benchmark.Cpp() != benchmark.CSharp())
                {
                    Console.WriteLine("Output of the method differs, are you benchmarking the same logic?");
                }

                BenchmarkRunner.Run<Benchmark>();
            }
        }
    }
}
