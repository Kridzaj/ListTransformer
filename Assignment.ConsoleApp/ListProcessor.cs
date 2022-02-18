using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.ConsoleApp
{
    public static class ListProcessor
    {
        /// <summary>
        /// Prepares a list for output 
        /// </summary>
        /// <param name="start">Start index</param>
        /// <param name="end">End index</param>
        /// <param name="firstName">First Name</param>
        /// <param name="lastName">Last Name</param>
        /// <returns></returns>
        public static List<string> PrepareList(int start, int end, string firstName, string lastName)
        {
            List<string> retVal = new List<string>();
            if (start > end)
            {
                throw new Exception("Invalid start and end values");
            }
            for (int i = start; i <= end; i++)
            {
                if (i % 15 == 0)
                {
                    retVal.Add($"{firstName}{lastName}");
                    continue;
                }
                if (i % 5 == 0)
                {
                    retVal.Add(lastName);
                    continue;
                }
                if (i % 3 == 0)
                {
                    retVal.Add(firstName);
                    continue;
                }
                retVal.Add(i.ToString());
            }

            return retVal;
        }
    }
}
