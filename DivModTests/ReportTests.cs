using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DivModTests
{
  [TestClass]
  public class ReportTests
  {
    [TestMethod]
    public void TestDivPP()
    {
      Assert.AreEqual(12, SchemeImpl.Div(123, 10));
    }

    [TestMethod]
    public void TestModPP()
    {
      Assert.AreEqual(3, SchemeImpl.Mod(123, 10));
    }

    [TestMethod]
    public void TestDivPN()
    {
      Assert.AreEqual(-12, SchemeImpl.Div(123, -10));
    }

    [TestMethod]
    public void TestModPN()
    {
      Assert.AreEqual(3, SchemeImpl.Mod(123, -10));
    }

    [TestMethod]
    public void TestDivNP()
    {
      Assert.AreEqual(-13, SchemeImpl.Div(-123, 10));
    }

    [TestMethod]
    public void TestModNP()
    {
      Assert.AreEqual(7, SchemeImpl.Mod(-123, 10));
    }

    [TestMethod]
    public void TestDivNN()
    {
      Assert.AreEqual(13, SchemeImpl.Div(-123, -10));
    }

    [TestMethod]
    public void TestModNN()
    {
      Assert.AreEqual(7, SchemeImpl.Mod(-123, -10));
    }

    [TestMethod]
    public void TestDiv0PP()
    {
      Assert.AreEqual(12, SchemeImpl.Div0(123, 10));
    }

    [TestMethod]
    public void TestMod0PP()
    {
      Assert.AreEqual(3, SchemeImpl.Mod0(123, 10));
    }

    [TestMethod]
    public void TestDiv0PN()
    {
      Assert.AreEqual(-12, SchemeImpl.Div0(123, -10));
    }

    [TestMethod]
    public void TestMod0PN()
    {
      Assert.AreEqual(3, SchemeImpl.Mod0(123, -10));
    }

    [TestMethod]
    public void TestDiv0NP()
    {
      Assert.AreEqual(-12, SchemeImpl.Div0(-123, 10));
    }

    [TestMethod]
    public void TestMod0NP()
    {
      Assert.AreEqual(-3, SchemeImpl.Mod0(-123, 10));
    }

    [TestMethod]
    public void TestDiv0NN()
    {
      Assert.AreEqual(12, SchemeImpl.Div0(-123, -10));
    }

    [TestMethod]
    public void TestMod0NN()
    {
      Assert.AreEqual(-3, SchemeImpl.Mod0(-123, -10));
    }
  }
}
