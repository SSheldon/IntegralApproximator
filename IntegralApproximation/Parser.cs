using System;
using System.Collections;
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
                return (parser.Execute() as ScalarValue).Value;
            }
            catch (YAMPException)
            {
                return null;
            }
        }

        public double? TryEvaluate(string function, double x)
        {
            try
            {
                Hashtable values = new Hashtable { { "x", x } };
                YAMP.Parser parser = YAMP.Parser.Parse(function);
                return (parser.Execute(values) as ScalarValue).Value;
            }
            catch (YAMPException)
            {
                return null;
            }
        }

        public double[] TryEvaluate(string function, double[] x)
        {

            try
            {
                double[] y = new double[x.Length];
                Hashtable values = new Hashtable();
                YAMP.Parser parser = YAMP.Parser.Parse(function);
                for (int i = 0; i < x.Length; i++)
                {
                    values["x"] = x[i];
                    y[i] = (parser.Execute(values) as ScalarValue).Value;
                }
                return y;
            }
            catch (YAMPException)
            {
                return null;
            }
        }
    }
}
