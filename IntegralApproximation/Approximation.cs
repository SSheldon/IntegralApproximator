using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using ZedGraph;

namespace IntegralApproximation
{
    public enum IntegralApproximationType
    { LeftSum, RightSum, MidpointSum, Trapezoidal, Simpson }

    class Approximation
    {
        private double start, end;
        private int intervals;
        private IntegralApproximationType type;

        private string function;
        private Parser parser;

        private List<CurveItem> curves;
        private double graphMin, graphMax, graphStep;

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

            this.curves = new List<CurveItem>(3);
        }

        /// <summary>
        /// Evaluates this Approximation's function at the given values.
        /// </summary>
        /// <param name="x">The values to evaluate at.</param>
        private double[] Evaluate(double[] x)
        {
            return parser.Evaluate(function, x);
        }

        private double Evaluate(double x)
        {
            return parser.Evaluate(function, x);
        }

        private double[] EvaluateQuadraticInterpolation(double[] x, double a, double b)
        {
            double[] y = new double[x.Length];
            double m = (a + b) / 2D;
            double fA = Evaluate(a);
            double fM = Evaluate(m);
            double fB = Evaluate(b);

            for (int counter = 0; counter < x.Length; counter++)
            {
                y[counter] = fA * (((x[counter] - m) * (x[counter] - b)) / ((a - m) * (a - b))) +
                    fM * (((x[counter] - a) * (x[counter] - b)) / ((m - a) * (m - b))) +
                    fB * (((x[counter] - a) * (x[counter] - m)) / ((b - a) * (b - m)));
            }
            return y;
        }

        /// <summary>
        /// Returns the resulting values for stepping through an interval.
        /// </summary>
        /// <param name="min">The minimum value of the interval</param>
        /// <param name="max">The maximum value of the interval</param>
        /// <param name="step">The amount to step by</param>
        private static double[] Steps(double min, double max, double step)
        {
            double[] x = new double[(int)Math.Floor((max - min) / step) + 1];
            for (int counter = 0; counter < x.Length; counter++)
            {
                x[counter] = min + step * counter;
            }
            return x;
        }

        private double[] IntervalXValues()
        {
            double[] x = new double[intervals + 1];
            x[0] = start;
            for (int counter = 1; counter < intervals; counter++)
            {
                x[counter] = start + (double)counter * ((end - start) / (double)intervals);
            }
            x[intervals] = end;
            return x;
        }

        private PointPairList IntervalPoints()
        {
            double[] x = IntervalXValues();
            return new PointPairList(x, Evaluate(x));
        }

        #region Graphing
        /// <summary>
        /// Graphs this Approximation and returns the resulting CurveItems.
        /// </summary>
        /// <param name="min">The minimum x-value of the graph</param>
        /// <param name="max">The maximum x-value of the graph</param>
        /// <param name="step">The x-step to graph functions with</param>
        public IEnumerable<CurveItem> Graph(double min, double max, double step)
        {
            curves.Clear();
            graphMin = min;
            graphMax = max;
            graphStep = step;

            GraphFunction();
            switch (type)
            {
                case IntegralApproximationType.LeftSum:
                    GraphLeftSum();
                    break;
                case IntegralApproximationType.RightSum:
                    GraphRightSum();
                    break;
                case IntegralApproximationType.MidpointSum:
                    GraphMidpointSum();
                    break;
                case IntegralApproximationType.Trapezoidal:
                    GraphTrapezoidalApprox();
                    break;
                case IntegralApproximationType.Simpson:
                    GraphSimpsonRule();
                    break;
            }

            return curves;
        }

        private void GraphFunction()
        {
            double[] x = Steps(graphMin, graphMax, graphStep);
            LineItem function = new LineItem("Function", x, Evaluate(x), Color.Red, SymbolType.None);
            function.Line.IsSmooth = false;
            curves.Add(function);
        }

        private void GraphLeftSum()
        {
            double[] x = IntervalXValues();
            double[] leftEndpoints = new double[intervals];
            for (int counter = 0; counter < intervals; counter++)
            {
                leftEndpoints[counter] = x[counter];
            }
            GraphRectangles(Evaluate(leftEndpoints));
        }

        private void GraphRightSum()
        {
            double[] x = IntervalXValues();
            double[] rightEndpoints = new double[intervals];
            for (int counter = 0; counter < intervals; counter++)
            {
                rightEndpoints[counter] = x[counter + 1];
            }
            GraphRectangles(Evaluate(rightEndpoints));
        }

        private void GraphMidpointSum()
        {
            double[] x = IntervalXValues();
            double[] midpoints = new double[intervals];
            for (int counter = 0; counter < intervals; counter++)
            {
                midpoints[counter] = (x[counter] + x[counter + 1]) / 2D;
            }
            GraphRectangles(Evaluate(midpoints));
        }

        private void GraphRectangles(double[] heights)
        {
            if (heights.Length != intervals) return;
            double[] x = IntervalXValues();

            PointPairList endpoints = new PointPairList();
            endpoints.Add(x[0], heights[0]);
            for (int counter = 1; counter < intervals; counter++) endpoints.Add(x[counter], heights[counter]);
            endpoints.Add(x[intervals], heights[intervals - 1]);
            GraphSeparators(endpoints);

            PointPairList points = new PointPairList();
            for (int counter = 0; counter < intervals; counter++)
            {
                points.Add(x[counter], heights[counter]);
                points.Add(x[counter + 1], heights[counter]);
            }
            LineItem approx = new LineItem("Approx", points, Color.Blue, SymbolType.None);
            approx.Line.Fill = new Fill(Color.LightBlue);
            curves.Add(approx);
        }

        private void GraphTrapezoidalApprox()
        {
            GraphSeparators();

            LineItem approx = new LineItem("Approx", IntervalPoints(), Color.Blue, SymbolType.None);
            approx.Line.Fill = new Fill(Color.LightBlue);
            curves.Add(approx);
        }

        private void GraphSimpsonRule()
        {
            GraphSeparators();

            PointPairList points = new PointPairList();
            double[] endpoints = IntervalXValues();

            for (int interval = 0; interval < intervals; interval++)
            {
                double a = endpoints[interval];
                double b = endpoints[interval + 1];
                double[] x = Steps(a, b, graphStep);
                points.Add(x, EvaluateQuadraticInterpolation(x, a, b));
                //Common endpoints are being added twice...
            }

            LineItem approx = new LineItem("Approx", points, Color.Blue, SymbolType.None);
            approx.Line.Fill = new Fill(Color.LightBlue);
            approx.Line.IsSmooth = false;
            curves.Add(approx);
        }

        private void GraphSeparators()
        {
            GraphSeparators(IntervalPoints());
        }

        private void GraphSeparators(PointPairList endpoints)
        {
            PointPairList points = new PointPairList();
            endpoints.Sort(SortType.XValues);

            points.Add(endpoints[0]);
            for (int counter = 0; counter < endpoints.Count - 1; counter++)
            {
                points.Add(endpoints[counter].X, 0);
                points.Add(endpoints[counter + 1].X, 0);
                points.Add(endpoints[counter + 1]);
            }

            LineItem separator = new LineItem("Separator", points, Color.Blue, SymbolType.None);
            curves.Add(separator);
        }
        #endregion

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
