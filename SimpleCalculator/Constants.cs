using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class Constants
    {
        private Dictionary<string, int> constants = new Dictionary<string, int>();

        public void Store(string key, int value)
        {
            int unused;
            key = key.ToLower();
            bool test = constants.TryGetValue(key, out unused);
            if (test) throw new ArgumentException(key + " is already defined.");
            else constants.Add(key, value);
        }

        public int Retrieve(string key)
        {
            int value;
            key = key.ToLower();
            bool test = constants.TryGetValue(key, out value);
            if (test) return value;
            else throw new KeyNotFoundException(key + " is not defined.");
        }
    }
}
