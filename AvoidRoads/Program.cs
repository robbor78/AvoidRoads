using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvoidRoads
{
  public class Program
  {
    static void Main(string[] args)
    {
    }

    public long numWays(int width, int height, String[] bad)
    {
      long numways = 0L;
      int max = width + height;
      int[][] map = new int[width + 1][];
      for (int i = 0; i <= width; i++)
      {
        map[i] = Enumerable.Repeat(0, height + 1).ToArray();
      }

      for (int y = 0; y <= height; y++)
      {
        if (y == 0)
        {
          numways++;
        }
        for (int x = 0; x <= width; x++)
        {

          if (map[x][y] > max)
          {
            numways--;
            continue;
          }

          //move forward
          if (x < width)
          {
            if (x == 0 && y < height)
            {
              numways++;
            }
            map[x + 1][y]++;
          }

          //move up
          if (y < height)
          {
            if (x > 0 && x < width)
            {
              numways++;
              if (y > 0) //&& y<height
              {
                numways++;
              }
            }
            map[x][y + 1]++;
          }
        }

      }

      return numways;
    }

    public long numWays2(int width, int height, String[] bad)
    {
      int max = width + height;
      long[][] map = new long[width + 1][];
      for (int i = 0; i <= width; i++)
      {
        map[i] = Enumerable.Repeat(0L, height + 1).ToArray();
      }

      int[][] badRoads = new int[bad.Length][];

      for (int i = 0; i < bad.Length; i++)
      {
        string[] coords = bad[i].Split(null);
        int x1 = int.Parse(coords[0]);
        int y1 = int.Parse(coords[1]);
        int x2 = int.Parse(coords[2]);
        int y2 = int.Parse(coords[3]);

        sort(ref x1, ref y1, ref x2, ref y2);

        badRoads[i] = new int[] { x1, y1, x2, y2 };

      }

      map[0][0] = 1;
      for (int y = 0; y <= height; y++)
      {

        for (int x = 0; x <= width; x++)
        {
          if (x == 0 && y == 0)
          {
            continue;
          }

          map[x][y] += x > 0 && isOpen(x - 1, y, x, y, badRoads) ? map[x - 1][y] : 0;
          map[x][y] += y > 0 && isOpen(x, y - 1, x, y, badRoads) ? map[x][y - 1] : 0;
        }

      }

      return map[width][height];
    }

    private bool isOpen(int x1, int y1, int x2, int y2, int[][] badRoads)
    {
      return badRoads==null || badRoads.Length==0 || 
        (badRoads.Where(a=>a[0]== x1 && a[1]== y1 && a[2]== x2 && a[3]== y2).Count()==0 &&
        badRoads.Where(a => a[0] == x2 && a[1] == y2 && a[2] == x1 && a[3] == y1).Count() == 0);
    }

    private void sort(ref int x1, ref int y1, ref int x2, ref int y2)
    {
      if (x2 < x1 || y2 < y1)
      {
        swop(ref x1, ref x2);
        swop(ref y1, ref y2);
      }
    }

    private void swop(ref int a, ref int b)
    {
      int tmp = a;
      a = b;
      b = tmp;
    }
  }
}
