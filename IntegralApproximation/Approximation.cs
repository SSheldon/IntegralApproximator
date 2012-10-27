using System;
using System.Collections.Generic;
using ZedGraph;

namespace IntegralApproximation
{
    class Approximation
    {
        private Parser parser;

        public string Function
        { get; set; }

        public double Start
        { get; set; }

        public double End
        { get; set; }

        public int Intervals
        { get; set; }

        public IntegralApproximationType Type
        { get; set; }

        public Approximation(Parser parser)
        {
            this.parser = parser;
        }

        /// <summary>
        /// Graphs this Approximation and returns the resulting CurveItems.
        /// </summary>
        /// <param name="min">The minimum x-value of the graph</param>
        /// <param name="max">The maximum x-value of the graph</param>
        /// <param name="step">The x-step to graph functions with</param>
        public IEnumerable<CurveItem> Graph(double min, double max, double step)
        {
            return null;
        }

        /// <summary>
        /// Calculates this Approximation and returns the result.
        /// </summary>
        public double Calculate()
        {
            return 0;
        }
    }
}
