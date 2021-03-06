using NUnit.Framework;
using JuiceShopAutomation.Tests;
using JuiceShopAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using JuiceShopAutomation.PageModels;

namespace JuiceShopAutomation.Tests.Authentication
{
    public class AuthenticationTests : BaseTest
    {

        string url = FrameworkConstants.GetUrl();

        private static IEnumerable<TestCaseData> GetCredentialsDataCsv()
        {
            foreach (var values in Utils.GetGenericData("TestData\\authenticationData.csv"))
            {
                yield return new TestCaseData(values);
            }
        }

        [Test, TestCaseSource("GetCredentialsDataCsv")]
        public void AuthenticationPositive(string email, string pass, string questionId, string answer)
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.CloseOpenBanner();
            mp.MoveToLoginPage();

            LoginPage lp = new LoginPage(_driver);
            Assert.IsTrue(lp.CheckLoginLabel("Login"));
            lp.Login(email, pass);
        }


    }
}
