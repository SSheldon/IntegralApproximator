using System;
using System.Collections.Generic;
using System.Linq;
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
        /// Evaluates this Approximation's function at the given values.
        /// </summary>
        /// <param name="x">The values to evaluate at.</param>
        private double[] Evaluate(double[] x)
        {
            return parser.Evaluate(function, x);
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

        #region Approximations
        /// <summary>
        /// Calculates this Approximation and returns the result.
        /// </summary>
        public double Calculate()
        {
            switch (type)
            {
                case IntegralApproximationType.LeftSum:
                    return CalculateLeftSum();
                case IntegralApproximationType.RightSum:
                    return CalculateRightSum();
                case IntegralApproximationType.MidpointSum:
                    return CalculateMidpointSum();
                case IntegralApproximationType.Trapezoidal:
                    return CalculateTrapezoidalApprox();
                case IntegralApproximationType.Simpson:
                    return CalculateSimpsonRule();
                default:
                    return 0;
            }
        }

        private double CalculateRightSum()
        {
            double[] x = new double[intervals];
            for (int counter = 0; counter < intervals; counter++)
            {
                x[counter] = start + ((end - start) / (double)intervals) * (double)(counter + 1);
            }
            return Evaluate(x).Sum() * ((end - start) / (double)intervals);
        }

        private double CalculateLeftSum()
        {
            double[] x = new double[intervals];
            for (int counter = 0; counter < intervals; counter++)
            {
                x[counter] = start + ((end - start) / (double)intervals) * (double)(counter);
            }
            return Evaluate(x).Sum() * ((end - start) / (double)intervals);
        }

        private double CalculateMidpointSum()
        {
            double[] x = new double[intervals];
            for (int counter = 0; counter < intervals; counter++)
            {
                x[counter] = start + ((end - start) / (double)intervals) * ((double)counter + .5D);
            }
            return Evaluate(x).Sum() * ((end - start) / (double)intervals);
        }

        private double CalculateTrapezoidalApprox()
        {
            return (CalculateRightSum() + CalculateLeftSum()) / 2D;
        }

        private double CalculateSimpsonRule()
        {
            return (2D * CalculateMidpointSum() + CalculateTrapezoidalApprox()) / 3D;
        }
        #endregion
    }
}
