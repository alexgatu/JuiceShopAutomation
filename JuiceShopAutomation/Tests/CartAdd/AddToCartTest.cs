using System;
using System.Collections.Generic;
using System.Text;
using JuiceShopAutomation.PageModels;
using JuiceShopAutomation.Utilities;
using NUnit.Framework;

namespace JuiceShopAutomation.Tests.CartAdd
{
    class AddToCartTest : BaseTest
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
        public void AddToCart(string email, string pass, string questionId, string answer)
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

            SearchPage sp = new SearchPage(_driver);
            Assert.IsTrue(sp.CheckSearchLabel("All Products"));
            sp.AddToCart(0);

        }
    }
}
