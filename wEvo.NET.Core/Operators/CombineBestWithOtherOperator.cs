﻿using System.Collections.Generic;
using wEvo.NET.Core.Utils;

namespace wEvo.NET.Core.Operators
{
    /**
    * Takes a result of another operator plus the best individual from
    * a given population (one for each objective function) and combines
    * them.
    * @author Marcin Brodziak (marcin.brodziak@gmail.com)
    * @param <T> type of the individual.
    */
    public class CombineBestWithOtherOperator<T> : Operator<T> where T : Individuals.Individual
    {
        /** Objective functions used in evaluation. */
        private List<ObjectiveFunction<T>> objectiveFunctions;

        /** Operator that serves the basis for this one. */
        private Operator<T> op;

        /** Random number generator. */
        private WevoRandom random;

        /**
        * Creates the operator.
        * @param functions Objective function to use.
        * @param operator  Operator to apply.
        * @param random Random number generator.
        */
        public CombineBestWithOtherOperator( List<ObjectiveFunction<T>> functions, Operator<T> op, WevoRandom random)
        {
            this.objectiveFunctions = functions;
            this.op = op;
            this.random = random;
        }

        public Population<T> Apply(Population<T> population)
        {
            Population<T> result = op.Apply(population);

            foreach (ObjectiveFunction<T> function in objectiveFunctions)
            {
                T bestIndividual = population.GetIndividuals()[0];
                for (int i = 1; i < population.Size(); i++)
                {
                    if (function.Compute(population.GetIndividuals()[i]) > function.Compute(bestIndividual))
                    {
                        bestIndividual = population.GetIndividuals()[i];
                    }
                }

                result = Core.Population<T>.RemoveRandomIndividual(random, result);
                result.AddIndividual(bestIndividual);
            }
            return result;
        }
    }
}
