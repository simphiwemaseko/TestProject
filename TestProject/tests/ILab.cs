using CsharpSelFramework.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using TestProject.pageobjects;

namespace TestProject.tests
{
    class ILab:Base
    {


        [Test, TestCaseSource("AddTestDataConfig")]
        
        public void JobApplicationTest(string name, string email, string[] expectedJobs)
        {
            //String[] expectedJobs = { "Interns - BSC Computer Science, National Diploma: IT Development Graduates" };
            LandingPage landingPage = new LandingPage(getDriver());
            landingPage.waitForBannerDisplay();
            string expectedBanner = landingPage.getBanner().Text;
            Assert.AreEqual(expectedBanner, "ON THE MONEY");
            GlobalCareerPage globalCareerPage = landingPage.clickCareer();

            globalCareerPage.waitForPageTextDisplay();
            string expectedGlobalCareerText = globalCareerPage.getPageText().Text;
            Assert.AreEqual(expectedGlobalCareerText, "WORK WITH iLAB");
            globalCareerPage.scrollToSouthAfrica();
            SouthAfricaCareerPage southAfricaCareerPage = globalCareerPage.clickSouthAfrica();
            southAfricaCareerPage.waitForSouthAfricaPageJobTextDisplay();
            string expectedSouthAfricaCarrerText = southAfricaCareerPage.getSouthAfricaCareerPageText().Text;
            Assert.AreEqual(expectedSouthAfricaCarrerText, "WORK WITH THE BEST");


            IList<IWebElement> jobs = southAfricaCareerPage.getJobs();

            foreach(IWebElement job in jobs)

            { 
             if (expectedJobs.Contains(job.FindElement(southAfricaCareerPage.getJobTitle()).Text))

                {
                    job.FindElement(southAfricaCareerPage.getJobTitle()).Click();
                    break;
                }

            }

            JobApplicationPage jobApplicationPage = new JobApplicationPage(getDriver());
            jobApplicationPage.waitForApplicationTextDisplay();
            string expectedJobApplicationText =jobApplicationPage.getJobApplicationPageText().Text;
            Assert.AreEqual(expectedJobApplicationText, "Interns – BSC Computer Science, National Diploma: IT Development Graduates");
            jobApplicationPage.scrollToApply();
            jobApplicationPage.clickApply();

            Random rnd = new Random();
            string number = rnd.Next().ToString();
            string contact = number.Insert(3, " ");
            string phone = contact.Remove(8);

            jobApplicationPage.applicantDetails(name, email,"083" +" "+ phone);
            jobApplicationPage.scrollToSubmitApplication();
            jobApplicationPage.clickSendApplication();
            jobApplicationPage.waitForApplicationErrorDisplay();
            jobApplicationPage.scrollToUploadError();
            string expectedUploadTextError = jobApplicationPage.getUploadTextError().Text;
            Assert.AreEqual(expectedUploadTextError, "You need to upload at least one file.");
   

        }

        public static IEnumerable<TestCaseData> AddTestDataConfig()
        {
            yield return new TestCaseData(getDataParser().extractData("name"),
            getDataParser().extractData("email"),getDataParser().extractDataArray("jobs"));
                
        }
    }
}
