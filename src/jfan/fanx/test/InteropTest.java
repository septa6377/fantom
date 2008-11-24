//
// Copyright (c) 2008, Brian Frank and Andy Frank
// Licensed under the Academic Free License version 3.0
//
// History:
//   20 Sep 08  Brian Frank  Creation
//
package fanx.test;

import fanx.util.*;

/**
 * InteropTest
 */
public class InteropTest
{

//////////////////////////////////////////////////////////////////////////
// Primitives
//////////////////////////////////////////////////////////////////////////

  long num = 1000;

  public byte   numb() { return (byte)num; }
  public short  nums() { return (short)num; }
  public char   numc() { return (char)num; }
  public int    numi() { return (int)num; }
  public long   numl() { return num; }
  public double numd() { return num; }
  public float  numf() { return num; }

  public void numb(byte x)   { num = x; }
  public void nums(short x)  { num = x; }
  public void numc(char x)   { num = x; }
  public void numi(int x)    { num = x; }
  public void numl(long x)   { num = x; }
  public void numd(double x) { num = (long)x; }
  public void numf(float x)  { num = (long)x; }

  public byte   numb = 'b';
  public short  nums = 's';
  public char   numc = 'c';
  public int    numi = 'i';
  public long   numl = 'l';
  public float  numf = 'f';
  public double numd = 'd';

  public static byte   snumb = 'B';
  public static short  snums = 'S';
  public static char   snumc = 'C';
  public static int    snumi = 'I';
  public static long   snuml = 'L';
  public static float  snumf = 'F';
  public static double snumd = 'D';

  public void numadd(byte b, short s, int i, float f)  { num = b + s + i + (int)f; }

//////////////////////////////////////////////////////////////////////////
// Arrays
//////////////////////////////////////////////////////////////////////////

  public InteropTest a;
  public InteropTest b;
  public InteropTest c;

  public InteropTest initArray()
  {
    a = new InteropTest();
    b = new InteropTest();
    c = new InteropTest();
    return this;
  }

  public InteropTest[] array1() { return new InteropTest[] { a, b, c}; }

  public void array1(InteropTest[] x) { a = x[0]; b = x[1]; c = x[2]; }

}