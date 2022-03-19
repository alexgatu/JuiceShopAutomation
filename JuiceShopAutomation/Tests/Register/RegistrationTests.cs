using System;
using System.Collections.Generic;
using System.Text;
using JuiceShopAutomation.PageModels;
using JuiceShopAutomation.Utilities;
using NUnit.Framework;

namespace JuiceShopAutomation.Tests.Register
{
    class RegistrationTests : BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        private static IEnumerable<TestCaseData> GetCredentialsDataCsv2()
        {
            foreach (var values in Utils.GetGenericData("TestData\\credentials.csv"))
            {
                yield return new TestCaseData(values);
            }
        }

        [Test]
        public void RegisterTest()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.CloseOpenBanner();
            mp.MoveToLoginPage();

            _driver.Navigate().GoToUrl(url + registrationUrlPath);
            RegistrationPage rp = new RegistrationPage(_driver);
            Assert.IsTrue(rp.CheckRegistrationLabel("User Registration"));
            rp.RegisterUser(Utils.GenerateRandomStringCount(10) + "@test.com", Utils.GenerateRandomStringCount(10), false, 1, Utils.GenerateRandomStringCount(10));;


        }

    }
}
