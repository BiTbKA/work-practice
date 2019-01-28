using System;

public class NthSeries
{

    public static string seriesSum(int n)
    {
        double res = 0, k = 4;
        for (int i = 0; i < n; i++)
        {
            if (i == 0)
            {
                res += 1;
                continue;
            }

            res += 1 / k;
            k += 3;
        }
        return String.Format("{0:0.00}", Math.Round(res, 2));
    }
}