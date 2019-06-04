using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var driver = new ChromeDriver())
            {
                //  driver.Navigate().GoToUrl("http://tmparts.ru");
                driver.Navigate().GoToUrl("http://krsk.rossko.ru/");

                var searchFld = driver.FindElementByClassName("Eqbi2-7");
                var lookBtn = driver.FindElementByClassName("_3wDmteG");
                //var userPasswordField = driver.FindElementById("pwd");
                // var loginButton = driver.FindElementByXPath("//input[@value='Login']");

                // Type user name and password
                searchFld.SendKeys("cvm6");
                //userPasswordField.SendKeys("12345");

                // and click the login button
                lookBtn.Click();
                WaitForReady(driver, By.ClassName("_3fkU7Sg"));
                /*
                // Extract the text and save it into result.txt
                var result = driver.FindElementByXPath("//div[@id='case_login']/h3").Text;
                File.WriteAllText("result.txt", result);
                */
                // Take a screenshot and save it into screen.png
                driver.GetScreenshot().SaveAsFile(@"screen.png", ScreenshotImageFormat.Png);
            }
        }        
            private static void WaitForReady(IWebDriver drv, By what)
            {
                WebDriverWait wait = new WebDriverWait(drv, TimeSpan.FromSeconds(15));
                wait.Until(driver =>
                {
                    bool isAjaxFinished = (bool)((IJavaScriptExecutor)driver).
                        ExecuteScript("return jQuery.active == 0");
                    try
                    {
                        driver.FindElement(what);
                        return true;
                    }
                    catch
                    {
                        return isAjaxFinished;
                    }
                });
            
        }
    }
}
