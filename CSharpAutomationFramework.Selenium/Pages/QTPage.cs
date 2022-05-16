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

        protected By btnContactUs = By.XPath("//a[@href='/contact-us/']");
        protected By frmContact = By.XPath("//form[@class='hs-form stacked hs-form-private hsForm_34dd68e0-b077-4e95-9243-b861f3f2fd7d hs-form-34dd68e0-b077-4e95-9243-b861f3f2fd7d hs-form-34dd68e0-b077-4e95-9243-b861f3f2fd7d_68161d33-37f9-41f6-b593-f338f4c5cdb2']");

    }
}
