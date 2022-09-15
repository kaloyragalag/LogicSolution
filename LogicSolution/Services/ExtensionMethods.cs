using System.Collections.Generic;
using System;
using System.Linq;

namespace LogicSolution.Services
{
    public static class ExtensionMethods
    {
        public static T[,] To2DArray<T>(this IList<T[]> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            int max = source.Select(l => l).Max(l => l.Count());

            var result = new T[source.Count, max];

            for (int i = 0; i < source.Count; i++)
            {
                for (int j = 0; j < source[i].Count(); j++)
                {
                    result[i, j] = source[i][j];
                }
            }

            return result;
        }
    }
}
