using System;
using System.Collections.Generic;
using YAMP;

namespace IntegralApproximation
{
    public class Parser
    {
        public double Evaluate(string expression)
        {
            return TryEvaluate(expression).Value;
        }

        public double[] Evaluate(string function, double[] x)
        {
            return TryEvaluate(function, x);
        }

        public double Evaluate(string function, double x)
        {
            return TryEvaluate(function, x).Value;
        }

        public bool IsValidExpression(string expression)
        {
            return TryEvaluate(expression).HasValue;
        }

        public bool IsValidFunction(string function)
        {
            return TryEvaluate(function, 0).HasValue;
        }

        public double? TryEvaluate(string expression)
        {
            try
            {
                YAMP.Parser parser = YAMP.Parser.Parse(expression);
                return ((ScalarValue)parser.Execute()).Value;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public double? TryEvaluate(string function, double x)
        {
            try
            {
                Dictionary<string, Value> values =
                    new Dictionary<string, Value> { { "x", new ScalarValue(x) } };
                YAMP.Parser parser = YAMP.Parser.Parse(function);
                return ((ScalarValue)parser.Execute(values)).Value;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public double[] TryEvaluate(string function, double[] x)
        {

            try
            {
                double[] y = new double[x.Length];
                Dictionary<string, Value> values = new Dictionary<string, Value>();
                ScalarValue value = new ScalarValue();
                values["x"] = value;
                YAMP.Parser parser = YAMP.Parser.Parse(function);
                for (int i = 0; i < x.Length; i++)
                {
                    value.Value = x[i];
                    y[i] = ((ScalarValue)parser.Execute(values)).Value;
                }
                return y;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
