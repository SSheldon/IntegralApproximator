using System;
using MTPARSERCOMLib;

namespace Integral_Approximation
{
    public class Parser
    {
        MTParserClass parser;
        MTDoubleVectorClass batchVar;
        MTDoubleClass singleVar;

        public Parser()
        {
            parser = new MTParserClass();
            parser.defineConst("pi", Math.PI);
            parser.defineConst("π", Math.PI);
            parser.defineConst("e", Math.E);
            singleVar = new MTDoubleClass();
            singleVar.create("x", 0);
            batchVar = new MTDoubleVectorClass();
            batchVar.create("x");
        }

        public double Evaluate(string expression)
        {
            return parser.evaluate(expression);
        }

        public double[] Evaluate(string function, double[] x)
        {
            double[] y = new double[x.Length];
            parser.defineVar(batchVar as IMTVariable);
            parser.compile(function);
            batchVar.setValueVector(x);
            parser.evaluateCompiledBatch(x.Length, y);
            parser.undefineAllVars();
            return y;
        }

        public double Evaluate(string function, double x)
        {
            parser.defineVar(singleVar as IMTVariable);
            parser.compile(function);
            singleVar.setValue(x);
            double y = parser.evaluateCompiled();
            parser.undefineAllVars();
            return y;

            //double[] xArray = { x };
            //return Function(xArray)[0]; 
        }

        public bool IsValidExpression(string expression)
        {
            try
            {
                parser.evaluate(expression);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IsValidFunction(string function)
        {
            try
            {
                parser.defineVar(batchVar as IMTVariable);
                parser.compile(function);
                parser.undefineAllVars();
                return true;
            }
            catch
            {
                parser.undefineAllVars();
                return false;
            }
        }
    }
}
