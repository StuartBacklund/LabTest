using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabTest.Web.Tests
{
    public static class Helpers
    {
        public static T MostCommon<T>(this IEnumerable<T> list)
        {
            return list.GroupBy(i => i).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
        }

        public static bool ListItemCountIsEven<T>(this IEnumerable<T> list)
        {
            return (list.Count() % 2 == 0);
        }

        public static bool IsOdd(this int i)
        {
            return (i % 2 == 1);
        }

        public static int GetElementOccurerence(this IEnumerable<int> list, int value)
        {
            return list.Where(x => x.Equals(value)).Count();
        }
    }
}