using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DivModTests
{
  [TestClass]
  public class SmallTests
  {
    [TestMethod]
    public void TestDivPP()
    {
      Assert.AreEqual(1, SchemeImpl.Div(17, 11));
    }

    [TestMethod]
    public void TestModPP()
    {
      Assert.AreEqual(6, SchemeImpl.Mod(17, 11));
    }

    [TestMethod]
    public void TestDivPN()
    {
      Assert.AreEqual(-1, SchemeImpl.Div(17, -11));
    }

    [TestMethod]
    public void TestModPN()
    {
      Assert.AreEqual(6, SchemeImpl.Mod(17, -11));
    }

    [TestMethod]
    public void TestDivNP()
    {
      Assert.AreEqual(-2, SchemeImpl.Div(-17, 11));
    }

    [TestMethod]
    public void TestModNP()
    {
      Assert.AreEqual(5, SchemeImpl.Mod(-17, 11));
    }

    [TestMethod]
    public void TestDivNN()
    {
      Assert.AreEqual(2, SchemeImpl.Div(-17, -11));
    }

    [TestMethod]
    public void TestModNN()
    {
      Assert.AreEqual(5, SchemeImpl.Mod(-17, -11));
    }

    [TestMethod]
    public void TestDiv0PP()
    {
      Assert.AreEqual(2, SchemeImpl.Div0(17, 11));
    }

    [TestMethod]
    public void TestMod0PP()
    {
      Assert.AreEqual(-5, SchemeImpl.Mod0(17, 11));
    }

    [TestMethod]
    public void TestDiv0PN()
    {
      Assert.AreEqual(-2, SchemeImpl.Div0(17, -11));
    }

    [TestMethod]
    public void TestMod0PN()
    {
      Assert.AreEqual(-5, SchemeImpl.Mod0(17, -11));
    }

    [TestMethod]
    public void TestDiv0NP()
    {
      Assert.AreEqual(-2, SchemeImpl.Div0(-17, 11));
    }

    [TestMethod]
    public void TestMod0NP()
    {
      Assert.AreEqual(5, SchemeImpl.Mod0(-17, 11));
    }

    [TestMethod]
    public void TestDiv0NN()
    {
      Assert.AreEqual(2, SchemeImpl.Div0(-17, -11));
    }

    [TestMethod]
    public void TestMod0NN()
    {
      Assert.AreEqual(5, SchemeImpl.Mod0(-17, -11));
    }
  }
}
