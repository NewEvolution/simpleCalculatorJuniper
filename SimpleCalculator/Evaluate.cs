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

        public static string Eval(string[] parsedData)
        {
            int argument1;
            int argument2;
            string nope = "input is invalid";
            bool arg1test = int.TryParse(parsedData[0], out argument1);
            bool arg2test = int.TryParse(parsedData[2], out argument2);
            int value = 0;
            if (parsedData[1] == "=")
            {
                if (!arg2test) argument2 = cons.Retrieve(parsedData[2]);
                if (!arg1test) cons.Store(parsedData[0], argument2);
                else throw new ArgumentException(nope);
                return "saved '" + parsedData[0] + "' as '" + argument2.ToString() + "'" ;
            }
            else if (parsedData[1] == "Last")
            {
                return Stack.Last;
            }
            else if (parsedData[1] == "LastE")
            {
                return Stack.LastE;
            }
            else
            {
                if (!arg1test) argument1 = cons.Retrieve(parsedData[0]);
                if (!arg2test) argument2 = cons.Retrieve(parsedData[2]);
                switch (parsedData[1])
                {
                    case "+":
                        value = Add(argument1, argument2);
                        break;
                    case "-":
                        value = Subtract(argument1, argument2);
                        break;
                    case "*":
                        value = Multiply(argument1, argument2);
                        break;
                    case "/":
                        value = Divide(argument1, argument2);
                        break;
                    case "%":
                        value = Modulo(argument1, argument2);
                        break;
                }
            }
            Stack.LastE = String.Join(" ", parsedData);
            Stack.Last = value.ToString();
            return value.ToString();
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
