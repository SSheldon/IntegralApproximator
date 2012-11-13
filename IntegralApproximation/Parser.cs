using System;
using System.Collections;
using YAMP;

namespace IntegralApproximation
{
    public class Parser
    {
        public double Evaluate(string expression)
        {
            YAMP.Parser parser = YAMP.Parser.Parse(expression);
            return (parser.Execute() as ScalarValue).Value;
        }

        public double[] Evaluate(string function, double[] x)
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

        public double Evaluate(string function, double x)
        {
            Hashtable values = new Hashtable { { "x", x } };
            YAMP.Parser parser = YAMP.Parser.Parse(function);
            return (parser.Execute(values) as ScalarValue).Value;
        }

        public bool IsValidExpression(string expression)
        {
            try
            {
                Evaluate(expression);
                return true;
            }
            catch (YAMPException)
            {
                return false;
            }
        }

        public bool IsValidFunction(string function)
        {
            try
            {
                Evaluate(function, 0);
                return true;
            }
            catch (YAMPException)
            {
                return false;
            }
        }
    }
}
