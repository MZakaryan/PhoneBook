// <copyright file="UtilitiesTest.cs">Copyright ©  2017</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneBook_v2._0;

namespace PhoneBook_v2._0.Tests
{
    /// <summary>This class contains parameterized unit tests for Utilities</summary>
    [PexClass(typeof(Utilities))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class UtilitiesTest
    {
        /// <summary>Test stub for DisplayMenu()</summary>
        [PexMethod]
        internal void DisplayMenuTest()
        {
            Utilities.DisplayMenu();
            // TODO: add assertions to method UtilitiesTest.DisplayMenuTest()
        }
    }
}
