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
    class JobApplicationPage
    {
        IWebDriver driver;
        public JobApplicationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.CssSelector, Using = ".pull-left")]
        private IWebElement jobApplicationPageText;

        

        [FindsBy(How = How.CssSelector, Using = ".wpjb-form-job-apply")]
        private IWebElement apply;


        [FindsBy(How = How.Id, Using = "applicant_name")]
        private IWebElement applicantName;

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement applicantEmail;

        [FindsBy(How = How.Id, Using = "phone")]
        private IWebElement applicantPhone;

        
        [FindsBy(How = How.CssSelector, Using = ".wpjb-submit")]
        private IWebElement submitApplication;

        //".wpjb-errors"

        [FindsBy(How = How.CssSelector, Using = ".wpjb-errors")]
        private IWebElement uploadTextError;


        public IWebElement getUploadTextError()
        {

            return uploadTextError;

        }

        public void clickSendApplication()
        {
            submitApplication.Submit();
        }


        public void applicantDetails(string name, string email, string phone)
        {
            applicantName.SendKeys(name);
            applicantEmail.SendKeys(email);
            applicantPhone.SendKeys(phone);
        }

        public void clickApply()
        {
            apply.Click();
        
        }

        public IWebElement getJobApplicationPageText()
        {
            return jobApplicationPageText;
        
        }

        public void waitForApplicationTextDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".pull-left")));
        }

        public void scrollToApply()
        {

            IWebElement frameScroll = driver.FindElement(By.CssSelector(".wpjb-form-job-apply"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true)", frameScroll);

        }


        public void scrollToSubmitApplication()
        {

            IWebElement frameScroll = driver.FindElement(By.CssSelector(".wpjb-submit"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true)", frameScroll);

        }

      

        public void waitForApplicationErrorDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".wpjb-icon-attention")));
        }

     
        public void scrollToUploadError()
        {

            IWebElement frameScroll = driver.FindElement(By.CssSelector(".wpjb-errors"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true)", frameScroll);

        }

    }
}
