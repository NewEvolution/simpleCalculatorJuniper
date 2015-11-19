using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public static class Evaluate
    {
        public static int Eval(string[] parsedData)
        {
            int argument1;
            int argument2;
            bool arg1test = int.TryParse(parsedData[0], out argument1);
            bool arg2test = int.TryParse(parsedData[2], out argument2);
            switch (parsedData[1])
            {
                case "+": return Add(argument1, argument2);
                case "-": return Subtract(argument1, argument2);
                case "*": return Multiply(argument1, argument2);
                case "/": return Divide(argument1, argument2);
                case "%": return Modulo(argument1, argument2);
            }
            throw new ArgumentException("Arggggh");
        }

        private static int Modulo(int argument1, int argument2)
        {
            return argument1 % argument2;
        }

        private static int Divide(int argument1, int argument2)
        {
            return argument1 / argument2;
        }

        private static int Multiply(int argument1, int argument2)
        {
            return argument1 * argument2;
        }

        private static int Subtract(int argument1, int argument2)
        {
            return argument1 - argument2;
        }

        private static int Add(int argument1, int argument2)
        {
            return argument1 + argument2;
        }
    }
}
