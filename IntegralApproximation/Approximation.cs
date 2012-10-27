using System;
using System.Collections.Generic;
using ZedGraph;

namespace IntegralApproximation
{
    class Approximation
    {
        private double start, end;
        private int intervals;
        private IntegralApproximationType type;
        private string function;
        private Parser parser;

        #region Properties
        public string Function
        {
            get { return function; }
            set { function = value; }
        }

        public double Start
        {
            get { return start; }
            set { start = value; }
        }

        public double End
        {
            get { return end; }
            set { end = value; }
        }

        public int Intervals
        {
            get { return intervals; }
            set { intervals = value; }
        }

        public IntegralApproximationType Type
        {
            get { return type; }
            set { type = value; }
        }
        #endregion

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
