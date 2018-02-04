using UnitTestProject1.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
namespace UnitTestProject1.PageObjects
{
    class RecPasswdPage
    {

        private IWebDriver driver;
        LoginData loginData = new LoginData();
        public void  RecLink(IWebDriver driver)
        { 
            driver.FindElement(By.CssSelector("body > div:nth-child(7) > span > a")).Click();
        }
        

        [FindsBy(How = How.Name, Using = "username")]
        [CacheLookup]
        private IWebElement UserName { get; set; }

        [FindsBy(How = How.Name, Using = "email")]
        [CacheLookup]
        private IWebElement Email { get; set; }

        [FindsBy(How = How.ClassName, Using = "button")]
        [CacheLookup]
        private IWebElement Submit { get; set; }

        public void RecPass(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }
        public void Recovery(string Name)
        {
            var loginData = ExcellAcess.GetLoginData(Name);
            UserName.SendKeys(loginData.User);
            Email.SendKeys(loginData.Email);
            Submit.Submit();
            System.Threading.Thread.Sleep(5000);
        }

    }
}
