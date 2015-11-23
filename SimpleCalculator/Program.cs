using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SimpleCalculator
{
    class Program
    {
        public static void Main()
        {
            int count = 0;
            string command = "";
            while (true)
            {
                string prompt = "[" + count.ToString() + "]> ";
                Console.Write(prompt);
                command = Console.ReadLine();
                if (command.ToLower() == "exit" || command.ToLower() == "quit")
                {
                    break;
                }
                string message = "    = ";
                try
                {
                    message += Evaluate.Eval(Parse.Convert(command));
                }
                catch (Exception e)
                {
                    message += e.Message;
                    count--;
                }
                Console.WriteLine(message);
                count++;
            }
            Console.WriteLine("Bye!!");
        }
    }
}
