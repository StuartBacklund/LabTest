using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace LabTest.Web.Tests
{
    [TestClass]
    public class Application_Tests
    {
        [TestMethod]
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
            Assert.IsTrue(result == 1);
        }
    }
}