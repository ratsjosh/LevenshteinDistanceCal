using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevenshteinDistanceCal.Factories
{
    public class MathsFactory
    {
        public static int Compute(string original, string modified)
        {
            if (string.IsNullOrEmpty(original))
            {
                if (string.IsNullOrEmpty(modified))
                    return 0;
                return modified.Length;
            }

            if (string.IsNullOrEmpty(modified))
            {
                return original.Length;
            }

            //// Get length of each string
            int n = original.Length;
            int m = modified.Length;
            //// Plot the table for string comparison
            int[,] d = new int[n + 1, m + 1];

            // initialize the top and right of the table to 0, 1, 2, ...
            for (int i = 0; i <= n; d[i, 0] = i++) ;
            for (int j = 1; j <= m; d[0, j] = j++) ;

            // Iterate through each row
            for (int i = 1; i <= n; i++)
            {
                // Iterate trhough each column
                for (int j = 1; j <= m; j++)
                {
                    // Comparison of the letter
                    //        // Example:
                    //        // original -> Execution
                    //        // modified -> Invention
                    //        // If('E' is the same as 'I') cost = 0
                    //        // Else cost = 1
                    // NOTE: Higher the value, the further the distance

                    int cost = (modified[j - 1] == original[i - 1]) ? 0 : 1;

                    int min1 = d[i - 1, j] + 1;
                    int min2 = d[i, j - 1] + 1;
                    int min3 = d[i - 1, j - 1] + cost;

                    // Get the minimum out of all the 3 adjacent cells
                    d[i, j] = Math.Min(Math.Min(min1, min2), min3);
                }
            }
            return d[n, m];
        }

        public static float Similarity(string string1, string string2)
        {
            float dis = Compute(string1, string2);
            float maxLen = string1.Length;
            if (maxLen < string2.Length)
                maxLen = string2.Length;
            if (maxLen == 0.0F)
                return 1.0F;
            else
                return (1.0F - dis / maxLen) * 100;
        }
    }
}
