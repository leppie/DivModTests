using System;
using System.Diagnostics;

namespace Benchmarks
{
  class Program
  {
    static void Main(string[] args)
    {
      var sw = new Stopwatch();

      var r = SchemeImpl.DivMod(123, 10);
      r = SchemeImpl.DivModSlow(123, 10);

      const int MAX = 1000000000;

      sw.Start();

      for (int i = 1; i < MAX; i++)
      {
        r = SchemeImpl.DivMod(i, MAX - i);
      }

      sw.Stop();

      Console.WriteLine("DivMod: {0:f3}s", sw.Elapsed.TotalSeconds);

      sw.Start();

      for (int i = 1; i < MAX; i++)
      {
        r = SchemeImpl.DivModSlow(i, MAX - i);
      }

      sw.Stop();

      Console.WriteLine("DivModSlow: {0:f3}s", sw.Elapsed.TotalSeconds);
    }
  }
}
