using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutomationFramework.reusable
{
    public abstract class GenericReusableComponents
    {
        /// <summary>
        ///     Function to generate Locator
        /// </summary>
        /// <param name="locatorValue">Type of locator ("XPATH", "ID", "NAME" or "LINKTEXT)</param> 
        /// <param name="locatorType">Value of the locator</param>
        /// TODO: IMPLEMENT LOGGING FOR DEFAULT CASE
        public By generateLocator(string locatorType, string locatorValue)
        {
            By loc = null;
            switch(locatorType)
            {
                case "XPATH":
                    loc = By.XPath(locatorValue);
                    break;
                case "ID":
                    loc = By.Id(locatorValue);
                    break;
                case "NAME":
                    loc = By.Name(locatorValue);
                    break ;
                case "LINKTEXT":
                    loc = By.LinkText(locatorValue);
                    break;
                default:
                    Console.WriteLine("Error, unable to identify locator");
                    break;
            }
            return loc;
        }

        /// <summary>
        ///     Function to pause the execution for the specified time period
        /// </summary>
        /// <param name="timeInSeconds">The wait time in seconds</param>
        public void wait(long timeInSeconds)
        {
            long endTime = DateTimeOffset.Now.ToUnixTimeMilliseconds() + (timeInSeconds * 1000);
            while(DateTimeOffset.Now.ToUnixTimeMilliseconds() < endTime)
            {
            }
        }
    }
}
