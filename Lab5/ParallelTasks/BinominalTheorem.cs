using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelTasks
{
    static class BinominalTheorem
    {
        public static int CalcNumerator(int n, int k)
        {
            int numerator = 1;
            for(int i = n; i >= n - k + 1; i--)
            {
                numerator *= i;
            }
            return numerator;
        }

        public static int CalcDenominator(int n, int k)
        {
            int denominator = 1;
            for(int i = 2; i<= k; i++)
            {
                denominator *= i;
            }
            return denominator;
        }

        public static async Task<int> CalcNumeratorAsync(int n, int k)
        {
            return await Task.Run(()=>CalcNumerator(n, k));
        }

        public static async Task<int> CalcDenominatorAsync(int n, int k)
        {
            return await Task.Run(() => CalcDenominator(n, k));
        }


    }
}
