using NUnit.Framework;
using JuiceShopAutomation.Tests;
using JuiceShopAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuiceShopAutomation.Tests.Authentication
{
    public class AuthenticationTests : BaseTest
    {

        string url = FrameworkConstants.GetUrl();

        [Test]
        public void AuthenticationPositive()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
        }


    }
}
