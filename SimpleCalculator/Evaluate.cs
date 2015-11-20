using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public static class Evaluate
    {
        public static Constants cons = new Constants();

        public static int Eval(string[] parsedData)
        {
            Stack.LastE = parsedData;
            int argument1;
            int argument2;
            bool arg1test = int.TryParse(parsedData[0], out argument1);
            bool arg2test = int.TryParse(parsedData[2], out argument2);
            int value = 0;
            switch (parsedData[1])
            {
                case "=":
                    if (!arg1test) cons.Store(parsedData[0], argument2);
                    break;
                case "+":
                    if (!arg1test) argument1 = cons.Retrieve(parsedData[0]);
                    value = Add(argument1, argument2);
                    break;
                case "-":
                    if (!arg1test) argument1 = cons.Retrieve(parsedData[0]);
                    value = Subtract(argument1, argument2);
                    break;
                case "*":
                    if (!arg1test) argument1 = cons.Retrieve(parsedData[0]);
                    value = Multiply(argument1, argument2);
                    break;
                case "/":
                    if (!arg1test) argument1 = cons.Retrieve(parsedData[0]);
                    value = Divide(argument1, argument2);
                    break;
                case "%":
                    if (!arg1test) argument1 = cons.Retrieve(parsedData[0]);
                    value = Modulo(argument1, argument2);
                    break;
            }
            Stack.Last = value;
            return value;
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
