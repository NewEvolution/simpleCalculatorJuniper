using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SimpleCalculator
{
    public static class Parse
    {
        public static string[] Convert(string input)
        {
            input.Trim(' ');
            int count = 0;
            foreach (char character in input)
            {
                if (character == ' ') count++;
            }
            string nope = "Input is invalid";
            if (count > 2) throw new ArgumentException(nope);
            string[] validOperands = new string[] { "*", "%", "/", "+", "-", "=" };
            string[] validSigns = new string[] { "+", "-" };
            char[] allChars = input.ToCharArray();
            char toRemove = ' ';
            allChars = allChars.Where(character => character != toRemove).ToArray();
            StringBuilder argBuilder = new StringBuilder();
            string firstArgument = "";
            string operand = "";
            string secondArgument = "";
            bool startOfArgument = true;
            for (int i = 0; i < allChars.Length; i++)
            {
                string character = allChars[i].ToString();
                if (startOfArgument)
                {
                    if (character.All(char.IsLetterOrDigit) || validSigns.Contains(character))
                    {
                        startOfArgument = false;
                        argBuilder.Append(character);
                        continue;
                    }
                    else
                    {
                        throw new ArgumentException(nope);
                    }
                }
                else
                {
                    string previousCharacter = allChars[i - 1].ToString();
                    if (validSigns.Contains(previousCharacter) && character.All(char.IsLetterOrDigit))
                    {
                        argBuilder.Append(character);
                        continue;
                    }
                    if (previousCharacter.All(char.IsDigit) && character.All(char.IsDigit))
                    {
                        argBuilder.Append(character);
                        continue;
                    }
                    if (previousCharacter.All(char.IsLetterOrDigit) && validOperands.Contains(character))
                    {
                        firstArgument = argBuilder.ToString();
                        argBuilder = new StringBuilder();
                        if (operand == "")
                        {
                            operand = character;
                        }
                        else
                        {
                            throw new ArgumentException(nope);
                        }
                        startOfArgument = true;
                        continue;
                    }
                    throw new ArgumentException(nope);
                }
            }
            secondArgument = argBuilder.ToString();
            string[] output = new string[3] { firstArgument, operand, secondArgument};
            foreach (string item in output)
            {
                if (item == "")
                {
                    throw new ArgumentException(nope);
                }
            }
            return output;
        }
    }
}
