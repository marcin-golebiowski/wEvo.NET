﻿
using wevo.NET;
using wevo.NET.Individuals;

namespace  wevo.NET.Samples.ObjectiveFunctions
{
    internal class OneMax
    {
        public static double Compute(BinaryVector individual)
        {
            int result = 0;
            int individual_dimension = individual.GetSize();
            for (int i = 0; i < individual_dimension; i++)
            {
                if (individual.GetBit(i))
                {
                    result += 1;
                }
            }
            return result;
        }
    }
}
