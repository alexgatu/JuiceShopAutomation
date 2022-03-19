using System;
using System.Collections.Generic;
using System.Text;
using JuiceShopAutomation.PageModels.POM;
using OpenQA.Selenium;

namespace JuiceShopAutomation.PageModels
{
    public class SearchPage : BasePage
    {
        const string addToCartButtonsSelector = "buttton"; //css
        const string pageTextSelector = ".heading > div:nth-child(1)"; // css

        public SearchPage(IWebDriver driver) : base(driver)
        {

        }

        public Boolean CheckSearchLabel(string label)
        {
            return String.Equals(label.ToLower(), driver.FindElement(By.CssSelector(pageTextSelector)).Text.ToLower());
        }

        public void AddToCart(int itemIndex)
        {

            var addButtons = driver.FindElements(By.TagName(addToCartButtonsSelector));
            //var button = addButtons[itemIndex];
            Console.Write(addButtons.Count);
            //button.Click();

        }
    }
}
