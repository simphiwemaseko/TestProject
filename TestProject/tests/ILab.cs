using CsharpSelFramework.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.pageobjects;

namespace TestProject.tests
{
    class ILab:Base
    {


        [Test]

        public void JobApplicationTest()
        {

            LandingPage landingPage = new LandingPage(getDriver());
            landingPage.waitForBannerDisplay();
            string expectedBanner = landingPage.getBanner().Text;
            Assert.AreEqual(expectedBanner, "ON THE MONEY");
            GlobalCareerPage globalCareerPage = landingPage.clickCareer();

            globalCareerPage.waitForPageTextDisplay();
            string expectedGlobalCareerText = globalCareerPage.getPageText().Text;
            Assert.AreEqual(expectedGlobalCareerText, "WORK WITH iLAB");
            globalCareerPage.scrollToSouthAfrica();
            globalCareerPage.clickSouthAfrica();



        }


    }
}
