using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;


namespace TestProject.pageobjects
{
    public class LandingPage
    {
        IWebDriver driver;
        public LandingPage(IWebDriver driver)
        {


            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "slide-1-layer-2")]
        private IWebElement bannerText;

        public IWebElement getBanner()
        {
            return bannerText;
        
        }

        //CAREERS
        [FindsBy(How = How.LinkText, Using = "CAREERS")]
        private IWebElement career;

        public GlobalCareerPage clickCareer()
        {
            career.Click();
            return new GlobalCareerPage(driver);
        
        }

        public void waitForBannerDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("slide-1-layer-2")));
        }

    }
}
