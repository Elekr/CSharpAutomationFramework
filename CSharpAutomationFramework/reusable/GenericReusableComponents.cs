using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutomationFramework.reusable
{
    
    public abstract class GenericReusableComponents
    {
        protected Hook hook;

        public abstract void Log(AventStack.ExtentReports.Status status, string messsage);

        /// <summary>
        ///     Function to generate Locator
        /// </summary>
        /// <param name="locatorValue">Value of the locator</param> 
        /// <param name="locatorType">Type of locator ("XPATH", "ID", "NAME" or "LINKTEXT)</param>
        public static By GenerateLocator(string locatorType, string locatorValue)
        {
            By loc;
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
            }
            return loc;
        }

        /// <summary>
        ///     Function to pause the execution for the specified time period
        /// </summary>
        /// <param name="timeInSeconds">The wait time in seconds</param>
        public static void Wait(long timeInSeconds)
        {
            long endTime = DateTimeOffset.Now.ToUnixTimeMilliseconds() + (timeInSeconds * 1000);
            while(DateTimeOffset.Now.ToUnixTimeMilliseconds() < endTime)
            {
            }
        }

        /// <summary>
        ///     Function to test whether a site is working
        /// </summary>
        /// <param name="url">url to test</param>
        public bool IsSiteWorking(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.AllowAutoRedirect = true;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Log(AventStack.ExtentReports.Status.Pass, url + " is working");
                    return true;
                }
                Log(AventStack.ExtentReports.Status.Warning, url + " is not working");
                return false;
            }
            catch(Exception e)
            {
                Log(AventStack.ExtentReports.Status.Warning, url + " is not working: " +e.Message);
                return false;
            }

        }
    }
}
