using CSharpAutomationFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutomationFramework.StepDefinitions.Selenium
{
    [TestFixture]
    [Binding]
    public class TC03_TextInputStepDefinitions : PracticePage
    {
        public TC03_TextInputStepDefinitions(DriverHelper driverHelper) : base(driverHelper.webDriver)
        {

        }

        

        [Given(@"\[I have navigated to the TC03 page]")]
        public void GivenIHaveNavigatedToTC03()
        {
            NavigateHome();
        }

        [Given(@"\[The webpage contains a text input]")]
        public void GivenTheWebpageContainsATextInput()
        {
            Assert.IsTrue(IsElementVisible(textInput));
        }

        [Given(@"\[The text input is empty]")]
        public void GivenTheTextInputIsEmpty()
        {
            Assert.AreEqual("", GetAttribute(textInput, "value"));
        }

        [When(@"\[I type (.*)]")]
        public void IType(string text)
        {
            EnterText(textInput, text);
        }

        [Then(@"\[The text input should contain (.*)]")]
        public void ThenTextInputShouldContain(string text)
        {
            Assert.AreEqual(text, GetAttribute(textInput, "value"));
        }
    }
}
