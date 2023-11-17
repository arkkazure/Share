using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowFramework.Utils
{
    public class DriverUtils
    {

        public static bool waitUntilCircleDisappears1(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8)); // Adjust the timeout as needed
            Thread.Sleep(1000);
            try
            {
                // Wait until the loader element with class name "loader" disappears
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.loader[style*='display: none; opacity: 0;']")));
               // wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("div.loader[style*='display: block;']")));

            }
            catch (WebDriverTimeoutException)
            {
                // Handle timeout exception if loader does not disappear within the specified time
                throw new TimeoutException("Timeout waiting for loader to disappear.");
            }
            return true;
        }


        public static void waitUntilCircleDisappears(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(9));

            // Wait until at least two elements are present in the DOM
            wait.Until(driver =>
            {
                IReadOnlyCollection<IWebElement> elements = driver.FindElements(By.CssSelector("div.loader[style*='display: none; opacity: 0;']"));

                // Adjust the condition based on your specific requirements
                return elements.Count >= 2;
            });

        }

    }

    }

