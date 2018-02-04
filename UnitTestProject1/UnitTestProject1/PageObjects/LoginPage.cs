using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UnitTestProject1.Data;

namespace UnitTestProject1.PageObjects
{
    

    public class LoginPage
    {
        public LoginData LoginData = new LoginData();
        private IWebDriver driver;

        [FindsBy(How = How.Name, Using = "username")]
        [CacheLookup]
        private IWebElement UserName { get; set; }


        [FindsBy(How = How.Name, Using = "password")]
        [CacheLookup]
        private IWebElement Password { get; set; }

        [FindsBy(How = How.ClassName, Using = "button")]
        [CacheLookup]
        public IWebElement Submit { get; set; }

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Login(string Name)
        {
            var loginData = ExcellAcess.GetLoginData(Name);
            UserName.SendKeys(loginData.User);
            Password.SendKeys(loginData.Password);
            Submit.Submit();
            System.Threading.Thread.Sleep(5000);
            
        }


    }
}
