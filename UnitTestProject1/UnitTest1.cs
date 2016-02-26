using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AvoidRoads;

namespace UnitTestProject1
{
  [TestClass]
  public class UnitTest1
  {
    private readonly int W = 0;
    private readonly int H = 0;

    [TestMethod]
    public void TestMethod1()
    {

      int[][] allWH = new int[][] {

         new int[] { 1,1 },
         new int[] { 1,1 },
          new int[] { 1,1 },
          new int[] { 1,1 },
          new int[] { 2,2 },
          new int[] { 2,2 },
          new int[] { 2,2 },
          new int[] { 2,2 },
          new int[] { 3,3 },
          new int[] { 3,3 },
          new int[] { 3,3 },
        new int[] { 6, 6 },
        new int[] { 35, 31 }
      };


      string[][] allBad = new string[][] {

        new string[] { },
            new string[] {"0 0 0 1" },
            new string[] {"0 0 1 0" },
            new string[] { "0 0 0 1", "0 0 1 0" },
        new string[] { },
           new string[] {"1 1 1 2" },
           new string[] {"1 1 1 2", "1 1 2 1" },
                new string[] { "0 0 1 0","1 1 1 2", "1 1 2 1" },
            new string[] { },
             new string[] {"1 1 1 2" },
             new string[] {"0 0 1 0" },
        new string[] { "0 0 0 1", "6 6 5 6" },
        new string[] { }
      };

      long[] allNums = new long[] { 2L, 1L, 1L, 0L, 6L, 4L, 2L, 0L, 20L, 14L, 10L, 252L, 6406484391866534976L };

      Program p = new Program();

      int length = allNums.Length;
      for (int i = 0; i < length - 1; i++)
      {
        int width = allWH[i][W];
        int height = allWH[i][H];
        string[] bad = allBad[i];

        long actual = p.numWays2(width, height, bad);

        long expected = allNums[i];

        Assert.AreEqual(expected, actual);
      }
    }
  }
}
