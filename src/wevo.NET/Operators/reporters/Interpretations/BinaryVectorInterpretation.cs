﻿using System.Text;
using wevo.NET.Individuals;

namespace wevo.NET.Operators.Reporters.Interpretations
{
    public class BinaryVectorInterpretation : Interpretation<BinaryVector>
    {
        public string Interprete(BinaryVector individual)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < individual.GetSize(); i++)
            {
                builder.Append(individual.GetBit(i) ? "1" : "0");
            }

            builder.AppendLine();

            return builder.ToString();
        }
    }
}
