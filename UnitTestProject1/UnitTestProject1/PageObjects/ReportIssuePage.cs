
using OpenQA.Selenium;

namespace UnitTestProject1.PageObjects
{
    class ReportIssuePage
    {

        private IWebDriver driver;



        public ReportIssuePage(IWebDriver driver)
        {
            this.driver = driver;
            driver.FindElement(By.CssSelector("body > table.width100 > tbody > tr > td:nth-child(1) > a:nth-child(3)")).Click();
            System.Threading.Thread.Sleep(3000);  
            driver.FindElement(By.CssSelector("body > div:nth-child(6) > form > table > tbody > tr:nth-child(16) > td.center > input")).Click();
        }


    }

}
