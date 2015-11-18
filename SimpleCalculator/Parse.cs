using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class Parse
    {
        public string[] Convert(string input)
        {
            string[] validOperands = new string[] { "*", "%", "/", "+", "-", "=" };
            string[] validSigns = new string[] { "+", "-" };
            string nope = "Input is invalid";
            char[] allChars = input.ToCharArray();
            char toRemove = ' ';
            allChars = allChars.Where(character => character != toRemove).ToArray();
            StringBuilder firstArg = new StringBuilder();
            StringBuilder secondArg = new StringBuilder();
            for (int i = 0; i < allChars.Length; i++)
            {
                string character = allChars[i].ToString();
                if (!character.All(char.IsLetterOrDigit) && !validOperands.Contains(character))
                {
                    throw new ArgumentException(nope);
                }
                if (i == 0)
                {
                    if (!character.All(char.IsLetterOrDigit) && !validSigns.Contains(character))
                    {
                        throw new ArgumentException(nope);
                    }
                    else
                    {
                        firstArg.Append(allChars[i]);
                    }
                }
                else if (validSigns.Contains(allChars[i - 1].ToString()))
                {

                }
            }
            if(validSigns.Contains(allChars[0].ToString()))
            {

            }
            string[] output = new string[3];
            if (output.Length != 3) throw new ArgumentException(nope);
            int firstArg;
            int secondArg;
            bool firstArgIsInt = int.TryParse(output[0], out firstArg);
            bool secondArgIsInt = int.TryParse(output[2], out secondArg);
            if (!firstArgIsInt && (output[0].Length > 1 || !output[0].All(char.IsLetter))) throw new ArgumentException(nope);
            if (output[1].Length > 1 || !validOperands.Contains(output[1])) throw new ArgumentException(nope);
            if (!secondArgIsInt && (output[2].Length > 1 || !output[2].All(char.IsLetter))) throw new ArgumentException(nope);
            return output;
        }
    }
}
