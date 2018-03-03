using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneBook_v2._0;

namespace UnitTestProject1
{
    [TestClass]
    public class MyExtensionsTesting
    {
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ContainsTester()
        {
            //Init
            int[] testArray = { 3, 6, 5, 2, 7, 9, 2, 10 };

            int[] test = null;

            //Action
            bool contains = testArray.Contains(7);
            bool doesNotContains = testArray.Contains(20);

            Enumerable.Contains(test, 5);
            //Assert
            Assert.AreEqual(true, contains);
            Assert.IsTrue(doesNotContains == false);

        }
    }

}
