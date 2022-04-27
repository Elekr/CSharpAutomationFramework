using NUnit.Framework;
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
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
                    throw new InvalidSelectorException("Error, unable to identify locator '"+locatorType+"'");
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
