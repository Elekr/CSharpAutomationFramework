using CSharpAutomationFramework.reusable;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace CSharpAutomationFramework.Selenium
{

    public partial class WebReusableComponents : GenericReusableComponents
    {
        protected IWebDriver driver;
        protected (string websiteURL, string websiteTitle) homePage;

        public WebReusableComponents(IWebDriver driver, (string websiteURL, string websiteTitle) homePage)
        {
            this.driver = driver;
            this.homePage = homePage;
        }

        public override void Log(AventStack.ExtentReports.Status status, string message)
        {
            ReportSetup.Log(status, message);
        }

        /// <summary>
        ///     Function to wait until the page loads completely
        /// </summary>
        /// <param name="timeOutInSeconds">The wait timeout in seconds</param>
        public void WaitUntilPageReadyStateComplete(long timeOutInSeconds)
        {
            static bool isPageReady(IWebDriver drv)
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
        public bool CanLocateElement(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        ///     Function to wait until the specified element is located
        /// </summary>
        /// <param name="by">The locator used to identify the element</param>
        /// <param name="timeOutInSeconds">The wait timeout in seconds</param>
        public void WaitUntilElementLocated(By by, long timeOutInSeconds)
        {
            TimeSpan timeOut = TimeSpan.FromSeconds(timeOutInSeconds);
            (new WebDriverWait(driver, timeOut)).Until(_ => CanLocateElement(by));
        }

        /// <summary>
        ///     Is the specified element currently visible?
        /// </summary>
        /// <param name="by">The locator used to identify the element</param>
        public bool IsElementVisible(By by)
        {
            return CanLocateElement(by) && driver.FindElement(by).Displayed;
        }

        /// <summary>
        ///     Function to wait until the specified element is visible
        /// </summary>
        /// <param name="by">The locator used to identify the element</param>
        /// <param name="timeOutInSeconds">The wait timeout in seconds</param>
        public void WaitUntilElementVisible(By by, long timeOutInSeconds)
        {
            TimeSpan timeOut = TimeSpan.FromSeconds(timeOutInSeconds);
            (new WebDriverWait(driver, timeOut)).Until(_ => IsElementVisible(by));
        }

        /// <summary>
        ///     Is the specified element currently enabled?
        /// </summary>
        /// <param name="by">The locator used to identify the element</param>
        public bool IsElementEnabled(By by)
        {
            return IsElementVisible(by) && driver.FindElement(by).Enabled;
        }

        /// <summary>
        ///     Function to wait until the specified element is enabled
        /// </summary>
        /// <param name="by">the locator used to identify the element</param>
        /// <param name="timeOutInSeconds">The wait timeout in seconds</param>
        public void WaitUntilElementEnabled(By by, long timeOutInSeconds)
        {
            TimeSpan timeOut = TimeSpan.FromSeconds(timeOutInSeconds);
            (new WebDriverWait(driver, timeOut)).Until(_ => IsElementEnabled(by));
        }


        public void NavigateHome()
        {
            LaunchUrl(homePage.websiteURL);
        }

        /// <summary>
        ///     Function to click element when it is visible
        /// </summary>
        /// <param name="by">The locator for the element we wish to click</param>
        /// The Qualiframe version of this method uses a try-catch block and the logger reports
        /// a status to which will determine whether the test is successful. For now, that
        /// functionality does not exist within this framework so the try-catch has been omitted.
        public void ClickElement(By by)
        {

            WaitUntilElementVisible(by, 3);
            driver.FindElement(by).Click();
            Log(AventStack.ExtentReports.Status.Pass, "Element clicked successfully");

        }

        /// <summary>
        ///     Function to enter text in element when it is visible
        /// </summary>
        /// <param name="by">The locator used to identify the element</param>
        /// <param name="valueToEnter">String to input into the element</param>
        public void EnterText(By by, String valueToEnter)
        {
            WaitUntilElementVisible(by, 3);
            driver.FindElement(by).SendKeys(valueToEnter);
            Log(AventStack.ExtentReports.Status.Pass, "Text '" + valueToEnter + "' entered successfully");

        }

        /// <summary>
        ///     Function to verify if element is redirected to correct URL
        /// </summary>
        /// <param name="expectedUrl">What we expect the url to be</param>
        public void VerifyRedirect(String expectedUrl)
        {
            expectedUrl = expectedUrl.ToLower();
            string currentURL = GetCurrentUrl();
            if (expectedUrl.Equals(currentURL))
            {
                Log(AventStack.ExtentReports.Status.Pass, "Redirect successful, current URL matches expected URL '" + expectedUrl + "'");
                return;
            }
            throw new Exception("Redirect failed, current URL '" + currentURL + "' does not match expected URL '" + expectedUrl + "'");

        }

        /// <summary>
        ///     Function to get list of WebElements that match the locator
        /// </summary>
        /// <param name="by">The locator used to identify elements</param>
        /// <returns></returns>
        public List<IWebElement> GetWebElementList(By by)
        {
            WaitUntilElementLocated(by, 3);
            var elements = driver.FindElements(by).ToList();
            return elements;
        }

        /// <summary>
        ///     Function to get text from an element
        /// </summary>
        /// <param name="by">The locator used to identify the element</param>
        /// <returns>Text within the element</returns>
        public string GetTextFromElement(By by)
        {
            string text = driver.FindElement(by).Text;
            Log(AventStack.ExtentReports.Status.Pass, "Text retrieved successfully for " + by + ". The text is - " + text);
            return text;
        }

        /// <summary>
        ///     Method to get the current url
        /// </summary>
        /// <returns>Current url</returns>
        public string GetCurrentUrl()
        {
            string currentURL = driver.Url.ToLower();
            Log(AventStack.ExtentReports.Status.Pass, "Successfully retrieved current url '" + currentURL + "'");
            return currentURL;
        }

        /// <summary>
        ///     Method to switch to latest window
        /// </summary>
        public void SwitchToLatestWindow()
        {
            string handle = driver.WindowHandles.Last();
            driver.SwitchTo().Window(handle);
            Log(AventStack.ExtentReports.Status.Pass, "Window switched successfully. Window - " + handle);
        }

        /// <summary>
        ///     Method to switch to default window
        /// </summary>
        public void SwitchToParentWindow()
        {
            driver.SwitchTo().DefaultContent();
            Log(AventStack.ExtentReports.Status.Pass, "Window switched to parent successfully");
        }

        /// <summary>
        ///     Method to wait until the new tab loads -- assumes you only had one tab open before opening the new one
        /// </summary>
        public void WaitUntilNewTabLoads()
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
        public bool IsPageLoaded(string url)
        {
            return ExecuteScript("return document.URL").Equals(url);

        }

        /// <summary>
        ///     Method to wait until the page loads
        /// </summary>
        /// <param name="url">Url to wait for</param>
        public void WaitUntilPageLoads(string url)
        {
            TimeSpan timeout = TimeSpan.FromSeconds(10);
            new WebDriverWait(driver, timeout).Until(_ => IsPageLoaded(url));
        }

        /// <summary>
        ///     Method to get the value of an attribute from an element
        /// </summary>
        /// <param name="by">The locator that identifies the element</param>
        /// <param name="attributeName">Name of the attribute we wish to get the value of</param>
        public string GetAttribute(By by, string attributeName)
        {
            string value = GetElement(by).GetAttribute(attributeName);
            Log(AventStack.ExtentReports.Status.Pass, "Got value '" + value + "' from attribute '" + attributeName + "' of element '" + by + "'");
            return value;
        }

        /// <summary>
        ///     Method to open a new tab
        /// </summary>
        /// <exception cref="Exception">Failed to create window</exception>
        public void OpenNewTab()
        {
            int startingWindowCount = driver.WindowHandles.Count;
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;

            jse.ExecuteScript("window.open()");
            if (driver.WindowHandles.Count != startingWindowCount + 1)
            {
                throw new Exception("Failed to create new window -- unknown error");
            }
            Log(AventStack.ExtentReports.Status.Pass, "New tab opened successfully");
        }

        /// <summary>
        ///     Can an element not be found or is not visible
        /// </summary>
        /// <param name="by">The locator for the element</param>
        public bool IsElementInvisible(By by)
        {
            return !IsElementVisible(by);
        }


        /// <summary>
        ///     Function to wait untilan element either become invisible or cannot be located
        /// </summary>
        /// <param name="by">The locator used to identify the element</param>
        /// <param name="timeOutInSeconds">The wait timeout in seconds</param>
        public void WaitUntilInvisibilityOfElementLocated(By by, long timeOutInSeconds)
        {
            TimeSpan timeOut = TimeSpan.FromSeconds(timeOutInSeconds);
            (new WebDriverWait(driver, timeOut)).Until(_ => IsElementInvisible(by));
            Log(AventStack.ExtentReports.Status.Pass, "Element is now invisible");
        }

        /// <summary>
        ///     Function to switch to a window by using its title name
        /// </summary>
        /// <param name="titleName">Title of the window</param>
        public void SwitchToWindow(string titleName)
        {
            titleName = titleName.ToLower();
            string currentHandle = driver.CurrentWindowHandle;
            foreach (string windowHandle in driver.WindowHandles)
            {
                if (driver.SwitchTo().Window(windowHandle).Title.ToLower().Contains(titleName))
                {
                    break;
                }
            }
            if (!driver.Title.ToLower().Contains(titleName))
            {
                driver.SwitchTo().Window(currentHandle);
                throw new NoSuchWindowException("No window with a matching title was found");
            }
            Log(AventStack.ExtentReports.Status.Pass, "Switched to window '" + driver.CurrentWindowHandle + "' with title '" + driver.Title + "'");
        }


        /// <summary>
        ///     Function to click on an element using the action builder class
        /// </summary>
        /// <param name="by">The locator for the element</param>
        public void ClickOnElementaction(By by)
        {
            IWebElement element = GetElement(by);
            Actions action = new Actions(driver);
            action.MoveToElement(element).Click().Perform();
            Log(AventStack.ExtentReports.Status.Pass, "The element - " + by + " is clicked successfully");
        }

        /// <summary>
        ///     Method to launch url
        /// </summary>
        /// <param name="url">Web address that we wish to navigate to</param>
        public void LaunchUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
            Log(AventStack.ExtentReports.Status.Pass, "Navigated to " + url);

        }

        /// <summary>
        ///     Method to maxmize the window
        /// </summary>
        public void MaximizeWindow()
        {
            // May need to update if/when Appium integration is added
            driver.Manage().Window.Maximize();
            Log(AventStack.ExtentReports.Status.Pass, "Window Maximized Successfully");
        }

        /// <summary>
        ///     Method to switch window by providing its index
        /// </summary>
        /// <param name="index">Window index</param>
        public void SwitchToWindowIndex(int index)
        {
            string handle = driver.WindowHandles[index];
            driver.SwitchTo().Window(handle);
            Log(AventStack.ExtentReports.Status.Pass, "Switched to window index " + index);
        }

        /// <summary>
        ///     Method to set implicit wait
        /// </summary>
        /// <param name="timeInSeconds">Implicit wait time in seconds</param>
        public void SetImplicitWait(long timeInSeconds)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeInSeconds);
            Log(AventStack.ExtentReports.Status.Pass, "Implicit wait set successfully");
        }


        /// <summary>
        ///     Function to select the specified value from a listbox
        /// </summary>
        /// <param name="by">The locator used to identify the listbox</param>
        /// <param name="value">The value we wish to select</param>
        public void SelectByValue(By by, string value)
        {
            IWebElement listbox = GetElement(by);
            SelectElement select = new SelectElement(listbox);
            select.SelectByText(value);
            Log(AventStack.ExtentReports.Status.Pass, "The value " + value + " is selected");
        }

        /// <summary>
        ///     Function to get the options from a select
        /// </summary>
        /// <param name="by">The locator used to identify the listbox</param>
        public List<string> GetSelectOptions(By by)
        {
            IWebElement listbox = GetElement(by);
            SelectElement select = new SelectElement(listbox);
            List<string> optionStrings = new List<string>();
            foreach (IWebElement option in select.Options)
            {
                optionStrings.Add(option.Text);
            }
            return optionStrings;
        }

        /// <summary>
        ///     Function to get a string representing the currently selected option within a static dropdown
        /// </summary>
        /// <param name="by">The locator used to identify the listbox</param>
        public string GetSelectSelected(By by)
        {
            IWebElement listbox = GetElement(by);
            SelectElement select = new SelectElement(listbox);
            return select.SelectedOption.Text;
        }

        /// <summary>
        ///     Function to switch to a frame
        /// </summary>
        /// <param name="by">The locator used to identify the frame</param>
        public void SwitchToframe(By by)
        {
            IWebElement frame = GetElement(by);
            driver.SwitchTo().Frame(frame);
        }

        public static class Table
        {

        }

        /// <summary>
        ///     Function to get the number of rows in a given table
        /// </summary>
        /// <param name="by">The locator that identifies the table</param>
        public int CountTableRows(By by)
        {
            IWebElement table = GetElement(by);
            return table.FindElements(By.TagName("tr")).Count;
        }


        /// <summary>
        ///     Function to get the number of columns in a given table -- assumes that the table has the same number of cells in every row and that all columns have a heading
        /// </summary>
        /// <param name="by">The locator that identifies the table</param>
        /// <returns></returns>
        public int CountTableColumns(By by)
        {
            IWebElement table = GetElement(by);
            return table.FindElements(By.TagName("th")).Count;
        }



        /// <summary>
        ///     Fuction to get the total of a column of a table
        /// </summary>
        /// <param name="by">The locator that identifies the table</param>
        /// <param name="columnName">The name of the column we want to total</param>
        public int TotalTableColumn(By by, string columnName)
        {
            IWebElement table = GetElement(by);
            IList<IWebElement> headingsElementList = table.FindElements(By.TagName("th"));
            IList<string> headingsList = new List<string>();
            foreach (IWebElement headingElement in headingsElementList)
            {
                headingsList.Add(headingElement.Text);
            }
            int columnIndex = headingsList.IndexOf(columnName);
            return TotalTableColumn(by, columnIndex);
        }


        /// <summary>
        ///     Fuction to get the total of a column of a table
        /// </summary>
        /// <param name="by">The locator that identifies the table</param>
        /// <param name="columnIndex">The index of the column we want to total</param>
        public int TotalTableColumn(By by, int columnIndex)
        {
            IWebElement table = GetElement(by);
            IList<IWebElement> column = table.FindElements(By.XPath("tbody/tr/td[" + (columnIndex + 1).ToString() + "]"));
            int total = 0;
            foreach (IWebElement columnElement in column)
            {
                Log(AventStack.ExtentReports.Status.Info, columnElement.Text);
                int value = int.Parse(columnElement.Text);
                total += value;
            }
            return total;
        }


        /// <summary>
        ///     Function to get to the specified WebElement
        /// </summary>
        /// <param name="by">The locator for the element</param>
        public IWebElement GetElement(By by)
        {
            WaitUntilElementLocated(by, 3);
            return driver.FindElement(by);
        }


        public object ExecuteScript(string script)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            return jse.ExecuteScript(script);
        }



        // findJsonFilesInFolder and runAutomationTests will need major changes to layout and functionality of the framework before
        // they will work so that is why they have not yet been implemented
    }
}
