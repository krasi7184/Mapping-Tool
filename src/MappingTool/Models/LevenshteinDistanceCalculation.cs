using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MappingTool.Models
{
    public static class LevenshteinDistanceCalculation
    {
        public static int LevenshteinDistance(string str1, string str2)
        {
            if (str1 == null && str2 == null) return default(int);

            if (string.IsNullOrEmpty(str1)) return str2.Length;
            if (string.IsNullOrEmpty(str2)) return str1.Length;

            int n = str1.Length;
            int m = str2.Length;

            int[,] distance = new int[n + 1, m + 1];

            for (int i = 0; i <= n; i++)
            {
                distance[i, 0] = i;
            }
            for (int i = 1; i <= m; i++)
            {
                distance[0, i] = i;
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = (str1[i - 1] == str2[j - 1]) ? 0 : 1;

                    distance[i, j] = Math.Min(Math.Min(distance[i - 1, j - 1] + cost, distance[i - 1, j] + 1),
                    distance[i, j - 1] + 1);
                }
            }

            return distance[n, m];
        }
    }
}
