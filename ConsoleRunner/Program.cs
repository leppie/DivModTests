using System;
using System.Diagnostics;
using System.Threading;

namespace ConsoleRunner
{
  class Program
  {
    static void AssertDivMod(int x1, int x2, int nd, int xm)
    {
      Assert_AreEqual(x1, (long)nd * x2 + xm);
      Assert_IsTrue(xm >= 0);
      Assert_IsTrue(xm < Math.Abs((long)x2));
    }

    static void Assert_IsTrue(bool p)
    {
      if (!p)
      {
        Debugger.Launch();
        Debugger.Break();
      }
    }

    static void Assert_AreEqual(int x1, long x2)
    {
      if (x1 != x2)
      {
        Debugger.Launch();
        Debugger.Break();
      }
    }

    static void AssertDivMod(int x1, int x2)
    {
      var nd = SchemeImpl.Div(x1, x2);
      var xm = SchemeImpl.Mod(x1, x2);
      AssertDivMod(x1, x2, nd, xm);
    }

    static void AssertDivModTuple(int x1, int x2)
    {
      var dm = SchemeImpl.DivMod(x1, x2);
      AssertDivMod(x1, x2, dm.Item1, dm.Item2);
    }

    static void AssertDiv0Mod0(int x1, int x2, int nd, int xm)
    {
      Assert_AreEqual(x1, (long)nd * x2 + xm);
      var halfx2 = Math.Abs((long)x2 >> 1);
      Assert_IsTrue(xm >= -halfx2);
      Assert_IsTrue(xm < halfx2);
    }

    static void AssertDiv0Mod0(int x1, int x2)
    {
      var nd = SchemeImpl.Div0(x1, x2);
      var xm = SchemeImpl.Mod0(x1, x2);
      AssertDiv0Mod0(x1, x2, nd, xm);
    }

    static void TestDivModExhaustive(object minutes)
    {
      var r = new Random();
      var till = DateTime.Now.AddMinutes((int)minutes);
      long c = 0;

      while (till > DateTime.Now)
      {
        var i = r.Next(int.MinValue, int.MaxValue);
        var j = r.Next(int.MinValue, int.MaxValue);

        if (j != 0 && !(i == int.MinValue && j == -1))
        {
          AssertDivMod(i, j);
          c++;
        }
      }

      lock (LOCK)
      {
        total += c;
      }

      evt.Signal();
    }

    static void TestDivModExhaustiveTuple(object minutes)
    {
      var r = new Random();
      var till = DateTime.Now.AddMinutes((int)minutes);
      long c = 0;

      while (till > DateTime.Now)
      {
        var i = r.Next(int.MinValue, int.MaxValue);
        var j = r.Next(int.MinValue, int.MaxValue);

        if (j != 0 && !(i == int.MinValue && j == -1))
        {
          AssertDivModTuple(i, j);
          c++;
        }
      }

      lock (LOCK)
      {
        total += c;
      }

      evt.Signal();
    }

    static void TestDiv0Mod0Exhaustive(object minutes)
    {
      var r = new Random();
      var till = DateTime.Now.AddMinutes((int)minutes);
      long c = 0;

      while (till > DateTime.Now)
      {
        var i = r.Next(int.MinValue, int.MaxValue);
        var j = r.Next(int.MinValue, int.MaxValue);

        if (j != 0 && !(i == int.MinValue && j == -1))
        {
          AssertDiv0Mod0(i, j);
          c++;
        }
      }

      lock (LOCK)
      {
        total += c;
      }

      evt.Signal();
    }

    static readonly object LOCK = new object();

    static long total = 0;

    static CountdownEvent evt;

    static void Main(string[] args)
    {
      // prevent hogging entire OS
      Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.BelowNormal;

      const int CORECOUNT = 8;

      // about 2.2 billion tests per minute on my PC (release mode) (yes, it is fast)
      object minutes = 5;

      evt = new CountdownEvent(CORECOUNT);

      for (int i = 0; i < CORECOUNT; i++)
      {
        Thread.Sleep(100); // to make sure ramdon is not using same seed
        ThreadPool.QueueUserWorkItem(TestDivModExhaustive, minutes);
      }

      evt.Wait();

      Console.WriteLine("DivMod:   " + total);

      /*
      evt = new CountdownEvent(CORECOUNT);
      total = 0;

      for (int i = 0; i < CORECOUNT; i++)
      {
        Thread.Sleep(100); // to make sure ramdon is not using same seed
        ThreadPool.QueueUserWorkItem(TestDivModExhaustiveTuple, minutes);
      }

      evt.Wait();

      Console.WriteLine("DivMod T: " + total);
       */
      return;
    }
  }
}
