using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DivModTests
{
  [TestClass]
  public class Conformance
  {
    static void AssertDivMod(int x1, int x2, int nd, int xm)
    {
      Assert.AreEqual(x1, (long) nd * x2 + xm, "x1: {0} x2: {1}", x1, x2);
      Assert.IsTrue(xm >= 0);
      Assert.IsTrue(xm < Math.Abs((long)x2));
    }

    static void AssertDivMod(int x1, int x2)
    {
      var nd = SchemeImpl.Div(x1, x2);
      var xm = SchemeImpl.Mod(x1, x2);

      var r = SchemeImpl.DivMod(x1, x2);

      Assert.AreEqual(nd, r.Item1);
      Assert.AreEqual(xm, r.Item2);

      AssertDivMod(x1, x2, nd, xm);
    }

    static void AssertDiv0Mod0(int x1, int x2, int nd, int xm)
    {
      Assert.AreEqual(x1, (long) nd * x2 + xm);
      var absx2 = Math.Abs((long) x2);
      Assert.IsTrue((xm * 2L) >= -absx2);
      Assert.IsTrue((xm * 2L) < absx2);
    }

    static void AssertDiv0Mod0(int x1, int x2)
    {
      var nd = SchemeImpl.Div0(x1, x2);
      var xm = SchemeImpl.Mod0(x1, x2);

      var r = SchemeImpl.Div0Mod0(x1, x2);

      Assert.AreEqual(nd, r.Item1);
      Assert.AreEqual(xm, r.Item2);

      AssertDiv0Mod0(x1, x2, nd, xm);
    }

    static void CheckDivMod(int x1, int x2)
    {
      AssertDivMod(x1, x2);
      AssertDivMod(x1, -x2);
      AssertDivMod(-x1, x2);
      AssertDivMod(-x1, -x2);
    }

    static void CheckDiv0Mod0(int x1, int x2)
    {
      AssertDiv0Mod0(x1, x2);
      AssertDiv0Mod0(x1, -x2);
      AssertDiv0Mod0(-x1, x2);
      AssertDiv0Mod0(-x1, -x2);
    }

    [TestMethod]
    public void TestDivModAll1()
    {
      CheckDivMod(123, 10);
    }

    [TestMethod]
    public void TestDiv0Mod0All1()
    {
      CheckDiv0Mod0(123, 10);
    }

    [TestMethod]
    public void TestDivModAll2()
    {
      CheckDivMod(17, 11);
    }

    [TestMethod]
    public void TestDiv0Mod0All2()
    {
      CheckDiv0Mod0(17, 11);
    }


    [TestMethod]
    public void TestDivModAll3()
    {
      CheckDivMod(-1720408098, -1532586397);
    }

    [TestMethod]
    public void TestDiv0Mod0All3()
    {
      CheckDiv0Mod0(-1720408098, -1532586397);
    }

    [TestMethod]
    public void TestDivModAll4()
    {
      CheckDivMod(-1481342414, -2147483647);
    }

    [TestMethod]
    public void TestDiv0Mod0All4()
    {
      CheckDiv0Mod0(-1481342414, -2147483647);
    }

    [TestMethod]
    public void TestDivModAll5()
    {
      CheckDivMod(539373577, 851709006);
    }

    [TestMethod]
    public void TestDiv0Mod0All5()
    {
      CheckDiv0Mod0(539373577, 851709006);
    }

    [TestMethod]
    public void TestDivModAll6()
    {
      CheckDivMod(705536591, 262297936);
    }

    [TestMethod]
    public void TestDiv0Mod0All6()
    {
      CheckDiv0Mod0(705536591, 262297936);
    }

    [TestMethod]
    public void TestDivModAll7()
    {
      CheckDivMod(-1162572518, -1231776259);
    }

    [TestMethod]
    public void TestDiv0Mod0All7()
    {
      CheckDiv0Mod0(-1162572518, -1231776259);
    }

    [TestMethod]
    public void TestDivModAll8()
    {
      CheckDivMod(-1826813120, -2147483647);
    }

    [TestMethod]
    public void TestDiv0Mod0All8()
    {
      CheckDiv0Mod0(-1826813120, -2147483647);
    }

    [TestMethod]
    public void TestDivModAll9()
    {
      CheckDivMod(-1353172332, -1298327096);
    }

    [TestMethod]
    public void TestDiv0Mod0All9()
    {
      CheckDiv0Mod0(-1353172332, -1298327096);
    }
  }
}
