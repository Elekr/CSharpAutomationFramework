using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
            launchUrl(homePage.websiteURL);
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
            Hook.Log(AventStack.ExtentReports.Status.Pass, "Text '" + valueToEnter + "' entered successfully");

        }

        /// <summary>
        ///     Function to verify if element is redirected to correct URL
        /// </summary>
        /// <param name="expectedUrl">What we expect the url to be</param>
        public void verifyRedirect(String expectedUrl)
        {
            expectedUrl = expectedUrl.ToLower();
            string currentURL = getCurrentUrl();
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

        /// <summary>
        ///     Method to get the current url
        /// </summary>
        /// <returns>Current url</returns>
        public string getCurrentUrl()
        {
            string currentURL = driver.Url.ToLower();
            Hook.Log(AventStack.ExtentReports.Status.Pass, "Successfully retrieved current url '" + currentURL + "'");
            return currentURL;
        }

        /// <summary>
        ///     Method to switch to latest window
        /// </summary>
        public void switchToLatestWindow()
        {
            string handle = driver.WindowHandles.Last();
            driver.SwitchTo().Window(handle);
            Hook.Log(AventStack.ExtentReports.Status.Pass, "Window switched successfully. Window - " + handle);
        }

        /// <summary>
        ///     Method to switch to default window
        /// </summary>
        public void switchToParentWindow()
        {
            driver.SwitchTo().DefaultContent();
            Hook.Log(AventStack.ExtentReports.Status.Pass, "Window switched to parent successfully");
        }

        /// <summary>
        ///     Method to wait until the new tab loads -- assumes you only had one tab open before opening the new one
        /// </summary>
        public void waitUntilNewTabLoads()
        {
            while (!(driver.WindowHandles.Count > 1))
            {

            }
        }


        /// <summary>
        ///     Is the page loaded to the expected url?
        /// </summary>
        /// <param name="url">url we expect</param>
        /// <returns>Is the page loaded</returns>
        public bool isPageLoaded(string url)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            return jse.ExecuteScript("return document.URL").Equals(url);

        }

        /// <summary>
        ///     Method to wait until the page loads
        /// </summary>
        /// <param name="url">Url to wait for</param>
        public void waitUntilPageLoads(string url)
        {
            TimeSpan timeout = TimeSpan.FromSeconds(10);
            new WebDriverWait(driver, timeout).Until(_ => isPageLoaded(url));
        }

        /// <summary>
        ///     Method to get the value of an attribute from an element
        /// </summary>
        /// <param name="by">The locator that identifies the element</param>
        /// <param name="attributeName">Name of the attribute we wish to get the value of</param>
        public string getAttribute(By by, string attributeName)
        {
            string value = driver.FindElement(by).GetAttribute(attributeName);
            Hook.Log(AventStack.ExtentReports.Status.Pass, "Got value '" + value + "' from attribute '" + attributeName + "' of element '" + by + "'");
            return value;
        }

        /// <summary>
        ///     Method to open a new tab
        /// </summary>
        /// <exception cref="Exception">Failed to create window</exception>
        public void openNewTab()
        {
            int startingWindowCount = driver.WindowHandles.Count;
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;

            jse.ExecuteScript("window.open()");
            if (driver.WindowHandles.Count != startingWindowCount + 1)
            {
                throw new Exception("Failed to create new window -- unknown error");
            }
            Hook.Log(AventStack.ExtentReports.Status.Pass, "New tab opened successfully");
        }

        /// <summary>
        ///     Can an element not be found or is not visible
        /// </summary>
        /// <param name="by">The locator for the element</param>
        public bool isElementInvisible(By by)
        {
            return !isElementVisible(by);
        }


        /// <summary>
        ///     Function to wait untilan element either become invisible or cannot be located
        /// </summary>
        /// <param name="by">The locator used to identify the element</param>
        /// <param name="timeOutInSeconds">The wait timeout in seconds</param>
        public void waitUntilInvisibilityOfElementLocated(By by, long timeOutInSeconds)
        {
            TimeSpan timeOut = TimeSpan.FromSeconds(timeOutInSeconds);
            (new WebDriverWait(driver, timeOut)).Until(_ => isElementInvisible(by));
            Hook.Log(AventStack.ExtentReports.Status.Pass, "Element is now invisible");
        }

        /// <summary>
        ///     Function to switch to a window by using its title name
        /// </summary>
        /// <param name="titleName">Title of the window</param>
        public void switchToWindow(string titleName)
        {
            titleName = titleName.ToLower();
            string currentHandle = driver.CurrentWindowHandle;
            foreach(string windowHandle in driver.WindowHandles)
            {
                if (driver.SwitchTo().Window(windowHandle).Title.ToLower().Contains(titleName))
                {
                    break;
                }
            }
            if(!driver.Title.ToLower().Contains(titleName))
            {
                driver.SwitchTo().Window(currentHandle);
                throw new NoSuchWindowException("No window with a matching title was found");
            }
            Hook.Log(AventStack.ExtentReports.Status.Pass, "Switched to window '" + driver.CurrentWindowHandle + "' with title '" + driver.Title + "'");
        }


        /// <summary>
        ///     Function to click on an element using the action builder class
        /// </summary>
        /// <param name="by">The locator for the element</param>
        public void  clickOnElementaction(By by)
        {
            waitUntilElementLocated(by, 3);
            IWebElement element = driver.FindElement(by);
            Actions action = new Actions(driver);
            action.MoveToElement(element).Click().Perform();
            Hook.Log(AventStack.ExtentReports.Status.Pass, "The element - " + by + " is clicked successfully");
        }

        /// <summary>
        ///     Method to launch url
        /// </summary>
        /// <param name="url">Web address that we wish to navigate to</param>
        public void launchUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
            Hook.Log(AventStack.ExtentReports.Status.Pass, "Navigated to " + url);

        }

        /// <summary>
        ///     Method to maxmize the window
        /// </summary>
        public void maximizeWindow()
        {
            // May need to update if/when Appium integration is added
            driver.Manage().Window.Maximize();
            Hook.Log(AventStack.ExtentReports.Status.Pass, "Window Maximized Successfully");
        }

        /// <summary>
        ///     Method to switch window by providing its index
        /// </summary>
        /// <param name="index">Window index</param>
        public void switchToWindowIndex(int index)
        {
            string handle = driver.WindowHandles[index];
            driver.SwitchTo().Window(handle);
            Hook.Log(AventStack.ExtentReports.Status.Pass, "Switched to window index "+index);
        }

    }
}
