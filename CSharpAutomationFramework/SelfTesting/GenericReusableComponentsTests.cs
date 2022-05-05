using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutomationFramework.reusable
{
    [TestFixture]
    public class GenericReusableComponentsTests
    {
        [Test]
        [TestCase("XPATH", "//div")]
        [TestCase("ID", "blah")]
        [TestCase("NAME", "some name")]
        [TestCase("LINKTEXT", "some link")]
        public void GenerateLocator_generateLocator(string type, string value)
        {
            By locator = GenericReusableComponents.GenerateLocator(type, value);
            Assert.IsNotNull(locator);
        }

        [Test]
        [TestCase("XPAH", "//div")]
        [TestCase("I", "blah")]
        [TestCase("NME", "some name")]
        [TestCase("LNKTEXT", "some link")]
        public void FailGenerateLocator_generateLocator(string type, string value)
        {
            Assert.Throws<InvalidSelectorException>(delegate { GenericReusableComponents.GenerateLocator(type, value); });
            
        }
    }
}
