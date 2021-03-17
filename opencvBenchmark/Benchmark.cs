using BenchmarkDotNet.Attributes;
using System;
using System.Runtime.InteropServices;

namespace opencvBenchmark
{

    public class Benchmark
    {
        [DllImport("opencvcpp", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern int match(String a, String b);

        [Benchmark]
        public int CSharp()
        {
            return CSharpMatcher.Match(Program.ImageFile, Program.TemplateFile).Item3.X;
        }

        [Benchmark]
        public int Cpp()
        {
            return match(Program.ImageFile, Program.TemplateFile);
        }
    }
}
