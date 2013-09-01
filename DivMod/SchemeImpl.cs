﻿using System;
//http://www.r6rs.org/final/html/r6rs/r6rs-Z-H-14.html#node_sec_11.7.3.1
using System.Runtime.CompilerServices;

public static class SchemeImpl
{
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static int Div(int x1, int x2)
  {
    if (x1 == 0)
    {
      return 0;
    }
    if (x1 > 0)
    {
      return x1 / x2;
    }
    if (x2 > 0)
    {
      return (x1 + 1) / x2 - 1;
    }
    return (x1 + 1) / x2 + 1;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static int Mod(int x1, int x2)
  {
    // the following can overflow...
    //return -(Div(x1, x2) * x2 - x1);
    
    int m = x1 % x2;

    if (m == 0 || x1 > 0)
    {
      return m;
    }
    if (x2 > 0)
    {
      return m + x2;
    }
    return m - x2;
  }

  // FIXME: can overflow
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Tuple<int,int> DivMod(int x1, int x2)
  {
    var nd = Div(x1, x2);
    return Tuple.Create(nd, -(nd * x2 - x1));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Tuple<int, int> DivModSlow(int x1, int x2)
  {
    return Tuple.Create(Div(x1, x2), Mod(x1,x2));
  }

  // FIXME: this is all wrong
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static int Div0(int x1, int x2)
  {
    var r = DivMod(x1, x2);
    int d = r.Item1;
    int m = r.Item2;

    int halfx2 = Math.Abs(x2 >> 1);

    if (m < halfx2)
    {
      return d;
    }
    if (x2 > 0)
    {
      return d + 1;
    }
    return d - 1;
  }

  // FIXME: can overflow
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static int Mod0(int x1, int x2)
  {
    return -(Div0(x1, x2) * x2 - x1);
  }

  // FIXME: can overflow
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Tuple<int, int> Div0Mod0(int x1, int x2)
  {
    var nd = Div0(x1, x2);
    return Tuple.Create(nd, -(nd * x2 - x1));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Tuple<int, int> Div0Mod0Slow(int x1, int x2)
  {
    return Tuple.Create(Div0(x1, x2), Mod0(x1,x2));
  }
}


