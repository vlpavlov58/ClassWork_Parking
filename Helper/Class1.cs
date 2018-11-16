using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Helper
{
    public static class Helper
    {
        public static int GetRandomIndex(int minNumber, int maxNumber, bool isArray = false)
        {
            Thread.Sleep(1);

            return new Random()
                .Next(minNumber, isArray ? maxNumber : --maxNumber);
        }

        public static T GetRandom<T>(this IEnumerable<T> array)
        {
            var innerArray = array.ToList();
            return innerArray[GetRandomIndex(0, innerArray.ToList().Count, true)];
        }
    }
}
