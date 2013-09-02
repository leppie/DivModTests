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
    public void TestDivModAll01()
    {
      CheckDivMod(123, 10);
    }

    [TestMethod]
    public void TestDiv0Mod0All01()
    {
      CheckDiv0Mod0(123, 10);
    }

    [TestMethod]
    public void TestDivModAll02()
    {
      CheckDivMod(17, 11);
    }

    [TestMethod]
    public void TestDiv0Mod0All02()
    {
      CheckDiv0Mod0(17, 11);
    }


    [TestMethod]
    public void TestDivModAll03()
    {
      CheckDivMod(-1720408098, -1532586397);
    }

    [TestMethod]
    public void TestDiv0Mod0All03()
    {
      CheckDiv0Mod0(-1720408098, -1532586397);
    }

    [TestMethod]
    public void TestDivModAll04()
    {
      CheckDivMod(-1481342414, -2147483647);
    }

    [TestMethod]
    public void TestDiv0Mod0All04()
    {
      CheckDiv0Mod0(-1481342414, -2147483647);
    }

    [TestMethod]
    public void TestDivModAll05()
    {
      CheckDivMod(539373577, 851709006);
    }

    [TestMethod]
    public void TestDiv0Mod0All05()
    {
      CheckDiv0Mod0(539373577, 851709006);
    }

    [TestMethod]
    public void TestDivModAll06()
    {
      CheckDivMod(705536591, 262297936);
    }

    [TestMethod]
    public void TestDiv0Mod0All06()
    {
      CheckDiv0Mod0(705536591, 262297936);
    }

    [TestMethod]
    public void TestDivModAll07()
    {
      CheckDivMod(-1162572518, -1231776259);
    }

    [TestMethod]
    public void TestDiv0Mod0All07()
    {
      CheckDiv0Mod0(-1162572518, -1231776259);
    }

    [TestMethod]
    public void TestDivModAll08()
    {
      CheckDivMod(-1826813120, -2147483647);
    }

    [TestMethod]
    public void TestDiv0Mod0All08()
    {
      CheckDiv0Mod0(-1826813120, -2147483647);
    }

    [TestMethod]
    public void TestDivModAll09()
    {
      CheckDivMod(-1353172332, -1298327096);
    }

    [TestMethod]
    public void TestDiv0Mod0All09()
    {
      CheckDiv0Mod0(-1353172332, -1298327096);
    }

    [TestMethod]
    public void TestDivModAll10()
    {
      CheckDivMod(2132865653, 103461909);
    }

    [TestMethod]
    public void TestDiv0Mod0All10()
    {
      CheckDiv0Mod0(2132865653, 103461909);
    }

    [TestMethod]
    public void TestDivModAll11()
    {
      CheckDivMod(-2100699579, -768449697);
    }

    [TestMethod]
    public void TestDiv0Mod0All11()
    {
      CheckDiv0Mod0(-2100699579, -768449697);
    }

    [TestMethod]
    public void TestDivModAll12()
    {
      CheckDivMod(-2118249709, 811121673);
    }

    [TestMethod]
    public void TestDiv0Mod0All12()
    {
      CheckDiv0Mod0(-2118249709, 811121673);
    }

    [TestMethod]
    public void TestDivModAll13()
    {
      CheckDivMod(1950519675, 757249701);
    }

    [TestMethod]
    public void TestDiv0Mod0All13()
    {
      CheckDiv0Mod0(1950519675, 757249701);
    }

    [TestMethod]
    public void TestDivModAll14()
    {
      CheckDivMod(-1162764488, 3163985);
    }

    [TestMethod]
    public void TestDiv0Mod0All14()
    {
      CheckDiv0Mod0(-1162764488, 3163985);
    }

    [TestMethod]
    public void TestDivModAll15()
    {
      CheckDivMod(-1845935439, 2);
    }

    [TestMethod]
    public void TestDiv0Mod0All15()
    {
      CheckDiv0Mod0(-1845935439, 2);
    }

    [TestMethod]
    public void TestDivModAll16()
    {
      CheckDivMod(1460678851, -2);
    }

    [TestMethod]
    public void TestDiv0Mod0All16()
    {
      CheckDiv0Mod0(1460678851, -2);
    }

    [TestMethod]
    public void TestDivModAll17()
    {
      CheckDivMod(65383479, 4182);
    }

    [TestMethod]
    public void TestDiv0Mod0All17()
    {
      CheckDiv0Mod0(65383479, 4182);
    }



  }
}
