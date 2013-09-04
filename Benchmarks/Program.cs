using System;
using System.Diagnostics;

namespace Benchmarks
{
  class Program
  {
    static void Main(string[] args)
    {
      var sw = new Stopwatch();

      var r = SchemeImpl.Div(123, 10);

      for (int i = 0; i < 500000; i++)
      {
        r = SchemeImpl.Div(123, 10);
        //r = SchemeImpl.DivSlow(123, 10);
        r = SchemeImpl.Div0(123, 10);
        //r = SchemeImpl.Div0Slow(123, 10);
      }

      const int MAX = 500000000;

      sw.Start();

      for (int i = 1; i < MAX; i++)
      {
        r = SchemeImpl.Div(i, MAX - i);
        r = SchemeImpl.Div(i, 0 - i);
        r = SchemeImpl.Div(MAX - i, i);
        r = SchemeImpl.Div(0 - i, i);
      }

      sw.Stop();

      Console.WriteLine("Div: {0:f3}s", sw.Elapsed.TotalSeconds);

      /*
      sw.Restart();

      for (int i = 1; i < MAX; i++)
      {
        r = SchemeImpl.DivSlow(i, 0 - i);
      }

      sw.Stop();

      Console.WriteLine("DivSlow: {0:f3}s", sw.Elapsed.TotalSeconds);
      */
      sw.Restart();

      for (int i = 1; i < MAX; i++)
      {
        r = SchemeImpl.Div0(i, MAX- i);
        r = SchemeImpl.Div0(i, 0 - i);
        r = SchemeImpl.Div0(MAX - i, i);
        r = SchemeImpl.Div0(0 - i, i);
      }

      sw.Stop();

      Console.WriteLine("Div0: {0:f3}s", sw.Elapsed.TotalSeconds);
      /*
      sw.Restart();

      for (int i = 1; i < MAX; i++)
      {
        r = SchemeImpl.Div0Slow(i, 0 - i);
      }

      sw.Stop();

      Console.WriteLine("Div0Slow: {0:f3}s", sw.Elapsed.TotalSeconds);
      */
      Console.WriteLine(r);
    }
  }
}
