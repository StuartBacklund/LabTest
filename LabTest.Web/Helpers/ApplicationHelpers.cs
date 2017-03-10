using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace LabTest.Web.Helpers
{
    public static class ApplicationHelpers
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

        public static int[] ConvertCSVtoIntArray(this string strFilePath)
        {
            List<int> dt = new List<int>();

            var contents = File.ReadAllText(strFilePath).Split('\n');

            foreach (var item in contents)
            {
                if (item.Length > 1)
                {
                    var rowItems = item.Split(',');

                    for (int i = 0; i < rowItems.Length; i++)
                    {
                        var value = int.Parse(rowItems[i].Trim());
                        dt.Add(value);
                    }
                }
            }
            return dt.ToArray();
        }

        public static string BuildString(int[] arrNumbers)
        {
            var sb = new StringBuilder();
            foreach (var item in arrNumbers)
            {
                sb.Append($" {item.ToString()} ");
            }
            return sb.ToString();
        }

        public static string[] UploadCSVtoArray(HttpPostedFileBase FileUpload)
        {
            string[] contents = null;

            StreamReader reader = new StreamReader(FileUpload.InputStream);
            while (!reader.EndOfStream)
            {
                contents = reader.ReadToEnd().Split('\n');
            }
            return contents;
        }

        public static int[] ConvertStringToIntArray(string file)
        {
            List<int> dt = new List<int>();

            if (file.Length > 1)
            {
                var rowItems = file.Split(',');

                for (int i = 0; i < rowItems.Length; i++)
                {
                    var value = int.Parse(rowItems[i].Trim());
                    dt.Add(value);
                }
            }
            return dt.ToArray();
        }

        public static int GetMaxOccurrence(this IEnumerable<int> list)
        {
            return list.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count()).OrderByDescending(grp => grp.Value).Select(grp => grp.Value).First();
        }

        public static int CalculateResult(this int listCount, int item)
        {
            var result = -1;
            var halfListCount = listCount / 2;
            if (halfListCount.IsOdd())
            {
                if (item > halfListCount)
                {
                    result = 1;
                }
            }
            if (item > halfListCount + 1)
            {
                result = 1;
            }
            return result;
        }
    }
}