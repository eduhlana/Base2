using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UnitTestProject1.Data;
namespace UnitTestProject1.PageObjects
{

    
    public class ChangePass
    {
        private IWebDriver driver;

        public void MyAccount(IWebDriver driver) {
            this.driver = driver;
            driver.FindElement(By.XPath("/html/body/table[2]/tbody/tr/td[1]/a[8]")).Click();
        }

        public LoginData LoginData = new LoginData();
        [FindsBy(How = How.Name, Using = "password")]
        [CacheLookup]
        private IWebElement Password { get; set; }

        [FindsBy(How = How.Name, Using = "password_confirm")]
        [CacheLookup]
        public IWebElement PasswordConfirm { get; set; }

        [FindsBy(How = How.ClassName, Using = "button")]
        [CacheLookup]
        public IWebElement Submit { get; set; }
        

        public void changePass(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }
        public void ClickChange( IWebDriver driver, string Name)
        {
            var loginData = ExcellAcess.GetLoginData(Name);
            Password.SendKeys(loginData.Password);
            PasswordConfirm.SendKeys(loginData.Password);
            Submit.Submit();
            System.Threading.Thread.Sleep(5000);

        }
        
    }
    
}
