using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JBHifi
{
    [Binding]
    public class JBHifiLogin
    {
        FirefoxDriver driver = new FirefoxDriver();
        [Given(@"I goto the JBHifi website at: ""(.*)""")]
        public void GivenIGotoJBHifiWebsite(string url)
        {
            driver.Navigate().GoToUrl(url);

        }

        [When(@"I signup for special offers with: ""(.*)""")]
        public void WhenISignUp(string useraccount)
        {
            IWebElement signup = driver.FindElementById("sign_up");
            signup.SendKeys(useraccount);
            IWebElement Go = driver.FindElement(By.XPath("//span[contains(.,'Go')]"));
            Go.Click();
        }

        [Then(@"the email entered is unsuccessful")]
        public void ThenTheEmailEnteredIsUnsuccessful()
        {
            try
            {
                IWebElement errorBorder = driver.FindElementByXPath("//fieldset[@class='inline-form error']");
            }
            catch(Exception)
            {
                Assert.Fail();
            }
        }

        [After]
        public void After()
        {
            driver.Close();
        }

    }
}
