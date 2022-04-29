using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CSharpAutomationFramework.reusable
{
    public abstract class WebReusableComponents : GenericReusableComponents
    {
        protected IWebDriver driver;
        protected (string websiteURL, string websiteTitle) homePage;

        public WebReusableComponents(IWebDriver driver, (string websiteURL, string websiteTitle) homePage)
        {
            this.driver = driver;
            this.homePage = homePage;
        }

        /// <summary>
        ///     Function to wait until the page loads completely
        /// </summary>
        /// <param name="timeOutInSeconds">The wait timeout in seconds</param>
        public void waitUntilPageReadyStateComplete(long timeOutInSeconds)
        {
            bool isPageReady(IWebDriver drv)
            {
                return ((IJavaScriptExecutor)drv).ExecuteScript("return document.readyState").Equals("complete");
            }
            (new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds))).Until(drv => isPageReady(drv));
        }

        /// <summary>
        ///     Can the specified element currently be located?
        /// </summary>
        /// <param name="by">The locator used to identify the element</param>
        /// <returns></returns>
        public bool canLocateElement(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
        }

        /// <summary>
        ///     Function to wait until the specified element is located
        /// </summary>
        /// <param name="by">The locator used to identify the element</param>
        /// <param name="timeOutInSeconds">The wait timeout in seconds</param>
        public void waitUntilElementLocated(By by, long timeOutInSeconds)
        {
            TimeSpan timeOut = TimeSpan.FromSeconds(timeOutInSeconds);
            (new WebDriverWait(driver, timeOut)).Until(_ => canLocateElement(by));
        }

        /// <summary>
        ///     Is the specified element currently visible?
        /// </summary>
        /// <param name="by">The locator used to identify the element</param>
        public bool isElementVisible(By by)
        {
            return canLocateElement(by) && driver.FindElement(by).Displayed;
        }

        /// <summary>
        ///     Function to wait until the specified element is visible
        /// </summary>
        /// <param name="by">The locator used to identify the element</param>
        /// <param name="timeOutInSeconds">The wait timeout in seconds</param>
        public void waitUntilElementVisible(By by, long timeOutInSeconds)
        {
            TimeSpan timeOut = TimeSpan.FromSeconds(timeOutInSeconds);
            (new WebDriverWait(driver, timeOut)).Until(_ => isElementVisible(by));
        }

        /// <summary>
        ///     Is the specified element currently enabled?
        /// </summary>
        /// <param name="by">The locator used to identify the element</param>
        public bool isElementEnabled(By by)
        {
            return isElementVisible(by) && driver.FindElement(by).Enabled;
        }

        /// <summary>
        ///     Function to wait until the specified element is enabled
        /// </summary>
        /// <param name="by">the locator used to identify the element</param>
        /// <param name="timeOutInSeconds">The wait timeout in seconds</param>
        public void waitUntilElementEnabled(By by, long timeOutInSeconds)
        {
            TimeSpan timeOut = TimeSpan.FromSeconds(timeOutInSeconds);
            (new WebDriverWait(driver, timeOut)).Until(_ => isElementEnabled(by));
        }


        public void navigateHome()
        {
            driver.Navigate().GoToUrl(homePage.websiteURL);
        }

        /// <summary>
        ///     Function to click element when it is visible
        /// </summary>
        /// <param name="by">The locator for the element we wish to click</param>
        /// The Qualiframe version of this method uses a try-catch block and the logger reports
        /// a status to which will determine whether the test is successful. For now, that
        /// functionality does not exist within this framework so the try-catch has been omitted.
        public void clickElement(By by)
        {

            waitUntilElementVisible(by, 3);
            driver.FindElement(by).Click();
            Hook.Log(AventStack.ExtentReports.Status.Pass, "Element clicked successfully");

        }

        /// <summary>
        ///     Function to enter text in element when it is visible
        /// </summary>
        /// <param name="by">The locator used to identify the element</param>
        /// <param name="valueToEnter">String to input into the element</param>
        public void enterText(By by, String valueToEnter)
        {
            waitUntilElementVisible(by, 3);
            driver.FindElement(by).SendKeys(valueToEnter);
            Hook.Log(AventStack.ExtentReports.Status.Pass, "Text '" +valueToEnter+"' entered successfully");

        }

        /// <summary>
        ///     Function to verify if element is redirected to correct URL
        /// </summary>
        /// <param name="expectedUrl">What we expect the url to be</param>
        public void verifyRedirect(String expectedUrl)
        {
            expectedUrl = expectedUrl.ToLower();
            string currentURL = driver.Url.ToLower();
            if (expectedUrl.Equals(currentURL))
            {
                Hook.Log(AventStack.ExtentReports.Status.Pass, "Redirect successful, current URL matches expected URL '" + expectedUrl + "'");
                return;
            }
            throw new Exception("Redirect failed, current URL '" + currentURL + "' does not match expected URL '" + expectedUrl + "'");

        }

        /// <summary>
        ///     Function to get list of WebElements that match the locator
        /// </summary>
        /// <param name="by">The locator used to identify elements</param>
        /// <returns></returns>
        public List<IWebElement> getWebElementList(By by)
        {
            waitUntilElementLocated(by, 3);
            var elements = driver.FindElements(by).ToList();
            return elements;
        }

        /// <summary>
        ///     Function to get text from an element
        /// </summary>
        /// <param name="by">The locator used to identify the element</param>
        /// <returns>Text within the element</returns>
        public string getTextFromElement(By by)
        {
            waitUntilElementLocated(by, 3);
            string text = driver.FindElement(by).Text;
            Hook.Log(AventStack.ExtentReports.Status.Pass, "Text retrieved successfully for " + by + ". The text is - " + text);
            return text;
        }


    }
}
