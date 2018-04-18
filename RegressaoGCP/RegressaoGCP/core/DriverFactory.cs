﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;

namespace RegressaoGCP.core
{
    public class DriverFactory
    {
        private static IWebDriver driver;

        public static IWebDriver GetDriver()
        {

            if (driver == null)
            {
                ChromeOptions options = new ChromeOptions();
               // options.AddArguments("headless");
                options.AddArguments("window-size=1920x1080");
                driver = new ChromeDriver(options); ;
            }
            return driver;
        }

        public static void KillDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }
    }
}