using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.pageobjects
{
   public class GlobalCareerPage
    {
        IWebDriver driver;
        public GlobalCareerPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.CssSelector, Using = ".text-left")]
        private IWebElement pageText;

        //South Africa
        [FindsBy(How = How.LinkText, Using = "South Africa")]
        private IWebElement southAfrica;

        public IWebElement getPageText()
        {

           return pageText;
        }

        public SouthAfricaCareerPage clickSouthAfrica()
        {
            southAfrica.Click();
            return new SouthAfricaCareerPage(driver);
        } 

        public void scrollToSouthAfrica()
        {

            IWebElement frameScroll = driver.FindElement(By.LinkText("South Africa"));
            IJavaScriptExecutor js =(IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true)", frameScroll);
        
        }

        public void waitForPageTextDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".text-left")));
        }
    }
}
