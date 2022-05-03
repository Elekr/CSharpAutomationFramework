using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutomationFramework.SelfTesting.reusable
{
    public class WebReusableComponentsTests
    {
        public IWebDriver driver = new ChromeDriver(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Drivers\\");
        class WRC_Tester : CSharpAutomationFramework.reusable.WebReusableComponents
        {
            public WRC_Tester(IWebDriver driver) : base(driver, ("https://google.co.uk",""))
            {

            }
        }
        WRC_Tester tester;
        public void BeforeEach()
        {
            tester = new WRC_Tester(driver);
        }

        [Test]
        public void testTest()
        {
            BeforeEach();
            tester.navigateHome();
        }

    }
}
