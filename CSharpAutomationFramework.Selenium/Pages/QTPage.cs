using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutomationFramework.Selenium.Pages
{
    public class QTPage : WebReusableComponents
    {
        public QTPage(IWebDriver driver) : base(driver, ("https://qualitestgroup.com/", "The World’s Leading AI-Led Quality Engineering Company | Qualitest")) { }

        protected readonly By btnContactUs = By.XPath("//a[@href='/contact-us/']");
        protected readonly By frmContact = By.XPath("//form[@class='hs-form stacked hs-form-private hsForm_34dd68e0-b077-4e95-9243-b861f3f2fd7d hs-form-34dd68e0-b077-4e95-9243-b861f3f2fd7d hs-form-34dd68e0-b077-4e95-9243-b861f3f2fd7d_68161d33-37f9-41f6-b593-f338f4c5cdb2']");
       
        
        
        protected By txtFirstname { get { AssertContactUs(); return By.Name("firstname"); } }
        protected By txtLastname { get { AssertContactUs(); return By.Name("lastname"); } }
        protected By txtCompany { get { AssertContactUs(); return By.Name("company"); } }
        protected By txtPhone { get { AssertContactUs(); return By.Name("phone"); } }
        protected By txtEmail { get { AssertContactUs(); return By.Name("email"); } }
        protected By slctLocation { get { AssertContactUs(); return By.Name("location"); } }
        protected By txtHowCanWeHelp { get { AssertContactUs(); return By.Name("message"); } }
        protected By btnSubmit { get { AssertContactUs(); return By.XPath("//input[@type='submit']"); } }
        
        protected List<IWebElement> lblSubjectRadios {  get { AssertContactUs(); return GetWebElementList(By.XPath("//label[@class='hs-form-radio-display']")); } }

        public string urlContactUs => homePage.websiteURL + "contact-us/";

        public void GoToContactUs()
        {
            driver.Navigate().GoToUrl(urlContactUs);
        }

        private void AssertContactUs()
        {
            if(!urlContactUs.Equals(driver.Url))
            {
                throw new Exception("This field is on the present on the contact us page. Navigate there to use it.");
            }

        }



    }
}
