using System;
using System.IO;
using System.Linq;
using NUnit.Framework;

using System.Collections.Generic;
using LabTest.Presentation.Web.Helpers;

namespace UITest1
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void AppLaunches()
        {
            List<string> listA = new List<string>();
            string[] values = new string[] { }; ;
            using (var fs = File.OpenRead(@"test2.csv"))
            {
                using (var reader = new StreamReader(fs))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine().Split(',');
                        // values = line.Split(';');
                    }

                    Assert.IsNotNull(values);
                }
            }

            var intList = values.Where(x => char.IsDigit(Convert.ToChar(x))).Select(x => x.Count()).GroupBy(x => x).ToList();
        }

        [Test]
        public void GetElements()
        {
            var result = -1;
            var contents = File.ReadAllText(@"test3.csv").Split('\n');

            foreach (var item in contents)
            {
                if (item.Length > 1)
                {
                    var list = item.Split(',').ToArray();
                    var most = list.MostCommon().First();
                    var listCount = list.Count() / 2;
                    var occurrenceOfElement = list.Where(x => x.Equals(most)).Count();

                    var itemCount = list.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count()).OrderByDescending(grp => grp.Value).Select(grp => grp.Value).First();

                    if (list.Count().IsOdd())
                    {
                        if (itemCount > listCount)
                        {
                            result = 1;
                        }
                    }
                    if (itemCount > listCount + 1)
                    {
                        result = 1;
                    }
                }
            }
            Assert.IsTrue(result == -1);
        }

        public static bool IsInteger(string value)
        {
            int i;
            return int.TryParse(value, out i);
        }

        [Test]
        public void UploadAndCreateArray_Test()
        {
            var result = ApplicationHelpers.ConvertCSVtoIntArray(@"test3.csv");
            var contents = File.ReadAllText(@"test3.csv").Split('\n');
        }
    }
}

//.Replace(';',',')