using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Kata
{
    public static Tuple<int, int> NbrOfLaps(int x, int y)
    {
        if (x < 0 || y < 0)
            return new Tuple<int, int>(0, 0);
        if (x == y)
            return new Tuple<int, int>(1, 1);

        int NOD = GCD(x, y);
        int NOK = (x * y) / NOD;
        return new Tuple<int, int>(NOK / x, NOK / y);
    }

    public static int GCD(int a, int b)
    {
        while (a != 0 && b != 0)
        {
            if (a > b)
                a %= b;
            else
                b %= a;
        }

        return a == 0 ? b : a;
    }

    public static int DigitalRoot(long n)
    {
        int res = 0;
        while (n != 0)
        {
            res += (int)(n % 10);
            n /= 10;
        }
        return res;
    }

    /////////////////////////////////////////////////////////////////////////////////////
    public static Dictionary<string, int> Symbols = new Dictionary<string, int>()
      {
          {"zero", 0},
          {"one", 1},
          {"two", 2},
          {"three", 3},
          {"four", 4},
          {"five", 5},
          {"six", 6},
          {"seven", 7},
          {"eight", 8},
          {"nine", 9}
      };

    public static string AverageString(string str)
    {
        var arr = str.Split(' ');
        int sum = 0;
        foreach (var el in arr)
        {
            if (!Symbols.ContainsKey(el))
                return "n/a";

            sum += Symbols[el];
        }

        int average = sum / arr.Length;
        return Symbols.FirstOrDefault(x => x.Value == average).Key;
    }
}