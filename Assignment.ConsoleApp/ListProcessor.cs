using Assignment.Application.DTO;
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
        public static List<OutputDto> PrepareList(int start, int end, string firstName, string lastName)
        {
            List<OutputDto> retVal = new List<OutputDto>();
            if (start > end)
            {
                throw new Exception("Invalid start and end values");
            }
            for (int i = start; i <= end; i++)
            {
                retVal.Add(ConstructOutput(i, firstName, lastName));
            }
            return retVal;
        }

        /// <summary>
        /// Constructs the output value string
        /// </summary>
        /// <param name="index"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public static OutputDto ConstructOutput(int index, string firstName, string lastName)
        {
            OutputDto retVal = new OutputDto();
            retVal.Ordinal = index;
            retVal.Value = index.ToString();
            if (index % 15 == 0)
            {
                retVal.Value = $"{firstName}{lastName}";
            }
            if (index % 5 == 0 && index % 15 != 0)
            {
                retVal.Value = lastName;
            }
            if (index % 3 == 0 && index % 15 != 0)
            {
                retVal.Value = firstName;
            }
            return retVal;
        }
    }
}
