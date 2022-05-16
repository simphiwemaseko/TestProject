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
   public class SouthAfricaCareerPage

        
    {
        IWebDriver driver;
        By jobTitle = By.CssSelector(".wpjb-line-major a");
        public SouthAfricaCareerPage(IWebDriver driver)

        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.ClassName, Using = "vc_custom_heading")]
        private IWebElement southAfricaCareerPageText;

        //IList<IWebElement> jobs = driver.FindElements(By.CssSelector(".wpjb-line-major"));

        [FindsBy(How = How.CssSelector, Using = ".wpjb-line-major")]
        private IList<IWebElement> jobs;

        public IList<IWebElement> getJobs()
        {
            return jobs;
        }

        public IWebElement getSouthAfricaCareerPageText()
        {
            return southAfricaCareerPageText;
        
        }

        public void waitForSouthAfricaPageJobTextDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("vc_custom_heading")));
        }

        public By getJobTitle()

        {
            return jobTitle;

        }
    }
}
